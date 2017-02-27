using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DropboxRestAPI;
using System.Windows.Forms;
using DisComLib;
using Box.V2;
using Box.V2.Config;
using Box.V2.Auth;
using Box.V2.Models;
using Box.V2.Managers;
using Box.V2.Exceptions;
using CopySDK;
using CopySDK.Helper;
using CopySDK.Models;


namespace SecureCloud
{
    public partial class MainWindow : Form
    {

        private static String APPLICATION_NAME = "SecureCloud";
        private string[] outFileNames;
        private int countClouds = 0;
        private int thresholdVal;
        private string currentCloud;
        private string accName;
        private string inName;
        private string CloudPath = "/SecureCloud";

        public MainWindow()
        {
            InitializeComponent();
            using (SQLiteConnection conn = new SQLiteConnection("data source=SecureCloud.db"))
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();

                    SQLiteHelper sh = new SQLiteHelper(cmd);

                    for (int i = 0; i < 5; i++)
                    {
                        var dic = new Dictionary<string, object>();
                        dic["@aaa"] = i;
                        DataTable dt = sh.Select("select * from account where type = @aaa;", dic);
                        var state_name = getControlName(i);
                        var check_name = getControlName(10 + i);
                        PictureBox pbx = this.Controls.Find(state_name, true).FirstOrDefault() as PictureBox;
                        CheckBox chbx = this.Controls.Find(check_name, true).FirstOrDefault() as CheckBox;
                        if (dt.Rows.Count > 0)
                        {
                            pbx.Visible = true;
                            chbx.Enabled = true;
                        }
                        else
                        {
                            pbx.Visible = false;
                            chbx.Enabled = false;
                        }
                    }

                    // do something...

                    conn.Close();
                }
            }
        }

        private string getControlName(int n)
        {
            switch (n)
            {
                case 0: return "dropboxState";
                case 1: return "boxState";
                case 2: return "copyState";
                case 3: return "megaState";
                case 4: return "onedriveState";
                case 10: return "checkDropbox";
                case 11: return "checkBox";
                case 12: return "checkCopy";
                case 13: return "checkMega";
                case 14: return "checkOneDrive";
            }
            return "error";
        }

        private void inFileBrowse_Click(object sender, EventArgs e)
        {
            OpenFile("Open A File To Upload");
        }

        public void OpenFile(String title)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = title;
            fileDialog.Filter = "All Files(*.*)|*.*";

            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                inFilePath.Text = fileDialog.FileName;
            }
            else
            {
                return;
            }
        }

        private async void buttonUpload_Click(object sender, EventArgs e)
        {
            try
            {
                uploadState.ResetText();
                thresholdVal = (int)threshold.Value;
                if (thresholdVal < 2)
                {
                    MessageBox.Show("Threshold value should be a positive integer larger than 1.", APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (String.IsNullOrEmpty(inFilePath.Text))
                {
                    MessageBox.Show("Please input a file to distribute.", APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (countClouds < thresholdVal)
                {
                    MessageBox.Show("Threshold value can't be larger than the number of storages.", APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (checkLocal.Checked && localPath.Text == "")
                {
                    MessageBox.Show("Please input the local path to save a share.", APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                inName = inFilePath.Text.Substring(inFilePath.Text.LastIndexOf("\\") + 1);
                using (SQLiteConnection conn = new SQLiteConnection("data source=SecureCloud.db"))
                {
                    using (SQLiteCommand cmd = new SQLiteCommand())
                    {
                        cmd.Connection = conn;
                        conn.Open();

                        SQLiteHelper sh = new SQLiteHelper(cmd);

                        var dic = new Dictionary<string, object>();
                        dic["@aaa"] = inName;
                        DataTable dt = sh.Select("select * from account where type = @aaa;", dic);
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("Same name exists. Please select another name.", APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        // do something...

                        conn.Close();
                    }
                }

                DisEngine disEngine = new DisEngine();
                uploadState.AppendText("Upload started. The program may become unresponsive while uploading.\n Please wait...\nFile distribution started.\n");
                Stopwatch sw = Stopwatch.StartNew();
                disEngine.encrypt_stream(inFilePath.Text, countClouds, thresholdVal);
                uploadState.AppendText("The Files have been successfully distributed: " + sw.ElapsedMilliseconds.ToString() + "ms\n");
                sw.Restart();
                openOutputFiles();
                int num = 0;
                if (checkLocal.Checked)
                {
                    string filename = outFileNames[num].Substring(outFileNames[num].LastIndexOf("\\") + 1);
                    string destPath = Path.Combine(localPath.Text, filename);
                    File.Copy(outFileNames[num], destPath);
                    using (SQLiteConnection conn = new SQLiteConnection("data source=SecureCloud.db"))
                    {
                        using (SQLiteCommand cmd = new SQLiteCommand())
                        {
                            cmd.Connection = conn;
                            conn.Open();

                            SQLiteHelper sh = new SQLiteHelper(cmd);
                            var dic = new Dictionary<string, object>();
                            dic["type"] = -1;
                            dic["name"] = inName;
                            dic["info"] = destPath;
                            sh.Insert("information", dic);
                        }
                    }
                    num++;
                    uploadState.AppendText("The Files have been successfully saved in the local path: " + sw.ElapsedMilliseconds.ToString() + "ms\n");
                    sw.Restart();
                }
                if (checkDropbox.Checked)
                {
                    uploadState.AppendText("Dropbox Upload Started.\n");
                    using (SQLiteConnection conn = new SQLiteConnection("data source=SecureCloud.db"))
                    {
                        using (SQLiteCommand cmd = new SQLiteCommand())
                        {
                            cmd.Connection = conn;
                            conn.Open();

                            SQLiteHelper sh = new SQLiteHelper(cmd);
                            var dic = new Dictionary<string, object>();
                            dic["@aaa"] = 0;
                            DataTable dt = sh.Select("select * from account where type = @aaa;", dic);
                            string access_token;
                            if (dt.Rows.Count > 0)
                            {
                                var data = dt.Rows[0]["access_token"];
                                access_token = data.ToString();
                                var options = new Options
                                {
                                    ClientId = "3vf0djj7k3sp6u0",
                                    ClientSecret = "c7oca4aa2ya73dx",
                                    RedirectUri = "https://www.google.com",
                                    AccessToken = access_token
                                };

                                // Initialize a new Client (with an AccessToken)
                                var client = new Client(options);
                                string name;
                                DropboxRestAPI.Models.Core.MetaData file;
                                using (var fileStream = System.IO.File.OpenRead(outFileNames[num]))
                                {
                                    name = outFileNames[num].Substring(outFileNames[num].LastIndexOf("\\") + 1);
                                    file = await client.Core.Metadata.FilesPutAsync(fileStream, CloudPath + "/" + name);
                                }
                                dic.Remove("@aaa");
                                dic["type"] = 0;
                                dic["name"] = inName;
                                dic["info"] = file.path;
                                sh.Insert("information", dic);
                                num++;

                            }
                            conn.Close();
                        }
                    }
                    uploadState.AppendText("Dropbox Upload Succeed: " + sw.ElapsedMilliseconds.ToString() + "ms\n");
                    sw.Restart();
                }
                if (checkBox.Checked)
                {
                    uploadState.AppendText("Box Upload Started.\n");
                    using (SQLiteConnection conn = new SQLiteConnection("data source=SecureCloud.db"))
                    {
                        using (SQLiteCommand cmd = new SQLiteCommand())
                        {
                            cmd.Connection = conn;
                            conn.Open();

                            SQLiteHelper sh = new SQLiteHelper(cmd);
                            var dic = new Dictionary<string, object>();
                            dic["@aaa"] = 1;
                            DataTable dt = sh.Select("select * from account where type = @aaa;", dic);
                            string access_token;
                            string refresh_token;
                            if (dt.Rows.Count > 0)
                            {
                                var data = dt.Rows[0]["access_token"];
                                access_token = data.ToString();
                                data = dt.Rows[0]["refresh_token"];
                                refresh_token = data.ToString();
                                data = dt.Rows[0]["id"];
                                var id = data.ToString();

                                //refresh token
                                var config = new BoxConfig("g0ai2rnmuq3yi7amn3uqena5rzs3rghz", "CzdqnhlhRBQEgia8Xcgoat3zmerAmMN1", new Uri("https://www.google.com"));
                                var auth = new OAuthSession(access_token, refresh_token, 3600, "bearer");

                                var client = new BoxClient(config, auth);
                                var new_auth = await client.Auth.RefreshAccessTokenAsync(refresh_token);
                                var dicData = new Dictionary<string, object>();
                                dicData["access_token"] = new_auth.AccessToken;
                                dicData["refresh_token"] = new_auth.RefreshToken;

                                sh.Update("account", dicData, "type", 1);
                                var fileRequest = new BoxFileRequest()
                                {
                                    Name = outFileNames[num].Substring(outFileNames[num].LastIndexOf("\\") + 1),
                                    ContentCreatedAt = DateTime.Now,
                                    ContentModifiedAt = DateTime.Now,
                                    Parent = new BoxRequestEntity() { Id = id }
                                };
                                using (var fileStream = System.IO.File.OpenRead(outFileNames[num]))
                                {
                                    BoxFile f = await client.FilesManager.UploadAsync(fileRequest, fileStream);
                                    dic["info"] = f.Id;
                                }
                                dic.Remove("@aaa");
                                dic["type"] = 1;
                                dic["name"] = inName;
                                sh.Insert("information", dic);
                                num++;

                            }
                            conn.Close();
                        }
                    }
                    uploadState.AppendText("Box Upload Succeed: " + sw.ElapsedMilliseconds.ToString() + "ms\n");
                    sw.Restart();
                }
                if (checkCopy.Checked)
                {
                    uploadState.AppendText("Copy Upload Started.\n");
                    using (SQLiteConnection conn = new SQLiteConnection("data source=SecureCloud.db"))
                    {
                        using (SQLiteCommand cmd = new SQLiteCommand())
                        {
                            cmd.Connection = conn;
                            conn.Open();

                            SQLiteHelper sh = new SQLiteHelper(cmd);
                            var dic = new Dictionary<string, object>();
                            dic["@aaa"] = 2;
                            DataTable dt = sh.Select("select * from account where type = @aaa;", dic);
                            string access_token;
                            string refresh_token;
                            if (dt.Rows.Count > 0)
                            {
                                var data = dt.Rows[0]["access_token"];
                                access_token = data.ToString();
                                data = dt.Rows[0]["refresh_token"];
                                refresh_token = data.ToString();

                                var config = new Config { ConsumerKey = "euGvvY4EMzDGgHU3V2lBCaFlxdr0uBYb", ConsumerSecret = "d3qCKDVdXlDP9fj4vbHOnSTPKT37jowRpXr4z60De8gWR3a3" };
                                var auth = new OAuthToken { Token = access_token, TokenSecret = refresh_token };

                                var client = new CopyClient(config, auth);
                                byte[] file;
                                file = File.ReadAllBytes(outFileNames[num]);
                                string filename = outFileNames[num].Substring(outFileNames[num].LastIndexOf("\\") + 1);
                                var result = await client.FileSystemManager.UploadNewFileAsync("files/" + CloudPath, filename, file, true);
                                dic.Remove("@aaa");
                                dic["type"] = 2;
                                dic["name"] = inName;
                                dic["info"] = filename;
                                sh.Insert("information", dic);
                                num++;

                            }
                            conn.Close();
                        }
                    }
                    uploadState.AppendText("Copy Upload Succeed: " + sw.ElapsedMilliseconds.ToString() + "ms\n");
                    sw.Restart();
                }
                using (SQLiteConnection conn = new SQLiteConnection("data source=SecureCloud.db"))
                {
                    using (SQLiteCommand cmd = new SQLiteCommand())
                    {
                        cmd.Connection = conn;
                        conn.Open();

                        SQLiteHelper sh = new SQLiteHelper(cmd);
                        var dic = new Dictionary<string, object>();
                        dic["name"] = inName;
                        dic["n"] = countClouds;
                        dic["k"] = thresholdVal;
                        dic["Local"] = checkLocal.Checked ? 1 : 0;
                        dic["Dropbox"] = checkDropbox.Checked ? 1 : 0;
                        dic["Box"] = checkBox.Checked ? 1 : 0;
                        dic["Copy"] = checkCopy.Checked ? 1 : 0;
                        dic["Mega"] = checkMega.Checked ? 1 : 0;
                        dic["OneDrive"] = checkOneDrive.Checked ? 1 : 0;
                        sh.Insert("file", dic);
                    }
                }

                MessageBox.Show("Upload succeed!", APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async Task uploadFileToDropboxAsync(string access_token, int num)
        {

        }

        private void openOutputFiles()
        {
            int i;
            outFileNames = new string[countClouds];
            for (i = 0; i < countClouds; i++)
            {
                StringBuilder sb = new StringBuilder(inFilePath.Text);
                outFileNames[i] = sb.Append(i + 1).ToString();
            }
        }

        private void buttonCancelUpload_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cancelDownloadButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void outPathBrowseButton_Click(object sender, EventArgs e)
        {
            SelectPath("Select Output Path");
        }

        public void SelectPath(string title)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                outPath.Text = fbd.SelectedPath;
            }
        }

        private async void downloadButton_Click(object sender, EventArgs e)
        {
            try
            {
                var name = fileViewer.SelectedRows[0].Cells[1].FormattedValue.ToString();
                var n_str = fileViewer.SelectedRows[0].Cells[2].FormattedValue.ToString();
                var n = Int32.Parse(n_str);
                var k_str = fileViewer.SelectedRows[0].Cells[3].FormattedValue.ToString();
                var k = Int32.Parse(k_str);
                var local = fileViewer.SelectedRows[0].Cells[4].FormattedValue.ToString();
                var dropbox = fileViewer.SelectedRows[0].Cells[5].FormattedValue.ToString();
                var box = fileViewer.SelectedRows[0].Cells[6].FormattedValue.ToString();
                var copy = fileViewer.SelectedRows[0].Cells[7].FormattedValue.ToString();
                var mega = fileViewer.SelectedRows[0].Cells[8].FormattedValue.ToString();
                var onedrive = fileViewer.SelectedRows[0].Cells[9].FormattedValue.ToString();
                string[] inFiles = new string[k];
                string basename = Path.Combine(outPath.Text, name);
                for (int i = 0; i < k; i++)
                {
                    StringBuilder sb = new StringBuilder(basename);
                    inFiles[i] = sb.Append(i + 1).ToString();
                }
                int num = 0;
                if (num < k && local.Equals("1"))
                {
                    string path;
                    using (SQLiteConnection conn = new SQLiteConnection("data source=SecureCloud.db"))
                    {
                        using (SQLiteCommand cmd = new SQLiteCommand())
                        {
                            cmd.Connection = conn;
                            conn.Open();

                            SQLiteHelper sh = new SQLiteHelper(cmd);
                            var dic = new Dictionary<string, object>();
                            dic["@aaa"] = name;
                            dic["@bbb"] = -1;
                            DataTable dt = sh.Select("select * from information where type = @bbb and name = @aaa;", dic);
                            if (dt.Rows.Count > 0)
                            {
                                path = dt.Rows[0]["info"].ToString();
                            }
                            else
                            {
                                path = "";
                            }
                            conn.Close();
                        }
                    }
                    if (path == "")
                    {

                    }
                    else
                    {
                        File.Copy(path, inFiles[num]);
                        num++;
                    }
                }
                if (num < k && dropbox.Equals("1"))
                {
                    string access_token;
                    string onName;
                    using (var conn = new SQLiteConnection("data source=SecureCloud.db"))
                    {
                        using (var cmd = new SQLiteCommand())
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            SQLiteHelper sh = new SQLiteHelper(cmd);
                            var dic = new Dictionary<string, object>();
                            dic["@aaa"] = 0;
                            DataTable dt = sh.Select("select * from account where type = @aaa;", dic);
                            if (dt.Rows.Count > 0)
                            {
                                access_token = dt.Rows[0]["access_token"].ToString();
                            }
                            else
                            {
                                access_token = "";
                            }
                            dic["@bbb"] = name;
                            dt = sh.Select("select * from information where type = @aaa and name = @bbb;", dic);
                            if (dt.Rows.Count > 0)
                            {
                                onName = dt.Rows[0]["info"].ToString();
                            }
                            else
                            {
                                onName = "";
                            }
                            conn.Close();
                        }
                    }
                    var options = new Options
                    {
                        ClientId = "3vf0djj7k3sp6u0",
                        ClientSecret = "c7oca4aa2ya73dx",
                        RedirectUri = "https://www.google.com",
                        AccessToken = access_token
                    };

                    // Initialize a new Client (with an AccessToken)
                    var client = new Client(options);
                    using (var fileStream = File.OpenWrite(inFiles[num]))
                    {
                        await client.Core.Metadata.FilesAsync(onName, fileStream);
                    }
                    num++;
                }
                if (num < k && copy.Equals("1"))
                {
                    string access_token;
                    string refresh_token;
                    string onName;
                    using (var conn = new SQLiteConnection("data source=SecureCloud.db"))
                    {
                        using (var cmd = new SQLiteCommand())
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            SQLiteHelper sh = new SQLiteHelper(cmd);
                            var dic = new Dictionary<string, object>();
                            dic["@aaa"] = 2;
                            DataTable dt = sh.Select("select * from account where type = @aaa;", dic);
                            if (dt.Rows.Count > 0)
                            {
                                access_token = dt.Rows[0]["access_token"].ToString();
                                refresh_token = dt.Rows[0]["refresh_token"].ToString();
                            }
                            else
                            {
                                access_token = "";
                                refresh_token = "";
                            }
                            dic["@bbb"] = name;
                            dt = sh.Select("select * from information where type = @aaa and name = @bbb;", dic);
                            if (dt.Rows.Count > 0)
                            {
                                onName = dt.Rows[0]["info"].ToString();
                            }
                            else
                            {
                                onName = "";
                            }
                            var config = new Config { ConsumerKey = "euGvvY4EMzDGgHU3V2lBCaFlxdr0uBYb", ConsumerSecret = "d3qCKDVdXlDP9fj4vbHOnSTPKT37jowRpXr4z60De8gWR3a3" };
                            var auth = new OAuthToken { Token = access_token, TokenSecret = refresh_token };

                            var client = new CopyClient(config, auth);
                            var buffer = await client.FileSystemManager.DownloadFileAsync("files/" + CloudPath + "/" + onName);
                            File.WriteAllBytes(inFiles[num], buffer);
                            conn.Close();
                        }
                    }

                }
                if (num < k && box.Equals("1"))
                {
                    string access_token;
                    string refresh_token;
                    string fileId;
                    string onName;
                    using (var conn = new SQLiteConnection("data source=SecureCloud.db"))
                    {
                        using (var cmd = new SQLiteCommand())
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            SQLiteHelper sh = new SQLiteHelper(cmd);
                            var dic = new Dictionary<string, object>();
                            dic["@aaa"] = 1;
                            DataTable dt = sh.Select("select * from account where type = @aaa;", dic);
                            if (dt.Rows.Count > 0)
                            {
                                access_token = dt.Rows[0]["access_token"].ToString();
                                refresh_token = dt.Rows[0]["refresh_token"].ToString();
                                fileId = dt.Rows[0]["id"].ToString();
                            }
                            else
                            {
                                access_token = "";
                                refresh_token = "";
                                fileId = "";
                            }
                            dic["@bbb"] = name;
                            dt = sh.Select("select * from information where type = @aaa and name = @bbb;", dic);
                            if (dt.Rows.Count > 0)
                            {
                                onName = dt.Rows[0]["info"].ToString();
                            }
                            else
                            {
                                onName = "";
                            }
                            var config = new BoxConfig("g0ai2rnmuq3yi7amn3uqena5rzs3rghz", "CzdqnhlhRBQEgia8Xcgoat3zmerAmMN1", new Uri("https://www.google.com"));
                            var auth = new OAuthSession(access_token, refresh_token, 3600, "bearer");

                            var client = new BoxClient(config, auth);
                            var new_auth = await client.Auth.RefreshAccessTokenAsync(refresh_token);
                            var dicData = new Dictionary<string, object>();
                            dicData["access_token"] = new_auth.AccessToken;
                            dicData["refresh_token"] = new_auth.RefreshToken;

                            sh.Update("account", dicData, "type", 1);

                            using (var stream = await client.FilesManager.DownloadStreamAsync(onName))
                            {
                                using (var fileStream = File.Create(inFiles[num], (int)stream.Length))
                                {
                                    byte[] bytesInStream = new byte[stream.Length];
                                    stream.Read(bytesInStream, 0, bytesInStream.Length);
                                    fileStream.Write(bytesInStream, 0, bytesInStream.Length);
                                }
                                stream.Close();
                            }
                            conn.Close();
                        }
                    }
                    num++;
                }
                ComEngine comEngine = new ComEngine();
                string outName = Path.Combine(outPath.Text, name);
                downloadState.ResetText();
                downloadState.AppendText("Download started. The program may become unresponsive while downloading.\n Please wait...\nFile combination started.\n");
                Stopwatch sw = Stopwatch.StartNew();
                countClouds = 5;
                comEngine.decrypt_stream(n, k, inFiles, outName);
                downloadState.AppendText("The File has been successfully combined: " + sw.ElapsedMilliseconds.ToString() + "ms\n");
                MessageBox.Show("Download succeed!", APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void checkLocal_CheckedChanged(object sender, EventArgs e)
        {
            if (checkLocal.Checked)
            {
                localPath.Enabled = true;
                localPathBrowse.Enabled = true;
                countClouds++;
            }
            else
            {
                localPathBrowse.Enabled = false;
                localPath.Enabled = false;
                countClouds--;
            }
        }

        private void localPathBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                localPath.Text = fbd.SelectedPath;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dropboxImg_Click(object sender, EventArgs e)
        {
            dropboxImg.BorderStyle = BorderStyle.Fixed3D;
            boxImg.BorderStyle = BorderStyle.None;
            copyImg.BorderStyle = BorderStyle.None;
            megaImg.BorderStyle = BorderStyle.None;
            onedriveImg.BorderStyle = BorderStyle.None;
            currentCloud = "Dropbox";
        }

        private void boxImg_Click(object sender, EventArgs e)
        {
            dropboxImg.BorderStyle = BorderStyle.None;
            boxImg.BorderStyle = BorderStyle.Fixed3D;
            copyImg.BorderStyle = BorderStyle.None;
            megaImg.BorderStyle = BorderStyle.None;
            onedriveImg.BorderStyle = BorderStyle.None;
            currentCloud = "Box";
        }

        private void copyImg_Click(object sender, EventArgs e)
        {
            dropboxImg.BorderStyle = BorderStyle.None;
            boxImg.BorderStyle = BorderStyle.None;
            copyImg.BorderStyle = BorderStyle.Fixed3D;
            megaImg.BorderStyle = BorderStyle.None;
            onedriveImg.BorderStyle = BorderStyle.None;
            currentCloud = "Copy";
        }

        private void megaImg_Click(object sender, EventArgs e)
        {
            dropboxImg.BorderStyle = BorderStyle.None;
            boxImg.BorderStyle = BorderStyle.None;
            copyImg.BorderStyle = BorderStyle.None;
            megaImg.BorderStyle = BorderStyle.Fixed3D;
            onedriveImg.BorderStyle = BorderStyle.None;
            currentCloud = "Mega";
        }

        private void onedriveImg_Click(object sender, EventArgs e)
        {
            dropboxImg.BorderStyle = BorderStyle.None;
            boxImg.BorderStyle = BorderStyle.None;
            copyImg.BorderStyle = BorderStyle.None;
            megaImg.BorderStyle = BorderStyle.None;
            onedriveImg.BorderStyle = BorderStyle.Fixed3D;
            currentCloud = "OneDrive";
        }

        private async void accountAdd_Click(object sender, EventArgs e)
        {
            if (accountName.Text == "")
            {
                MessageBox.Show("Please input the account name.", APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                accName = accountName.Text;
                using (SQLiteConnection conn = new SQLiteConnection("data source=SecureCloud.db"))
                {
                    using (SQLiteCommand cmd = new SQLiteCommand())
                    {
                        cmd.Connection = conn;
                        conn.Open();

                        SQLiteHelper sh = new SQLiteHelper(cmd);

                        var dic = new Dictionary<string, object>();
                        dic["@aaa"] = accountName.Text;
                        DataTable dt = sh.Select("select * from account where name = @aaa;", dic);
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("Same name already exist. Please input another one.", APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        conn.Close();
                    }
                }
            }
            if (currentCloud == "Dropbox")
            {
                await RunAuthDropboxAsync();
            }
            else if (currentCloud == "Box")
            {
                await RunAuthBoxAsync();
            }
            else if (currentCloud == "Copy")
            {
                await RunAuthCopyAsync();
            }
        }

        private async Task RunAuthCopyAsync()
        {
            Scope scope = new Scope()
            {
                FileSystem = new FileSystemPermission()
                {
                    Read = true,
                    Write = true
                },
                Profile = new ProfilePermission()
                {
                    Read = true,
                    Write = true,
                    Email = new EmailPermission()
                    {
                        Read = true,
                    }
                }
            };

            CopySDK.Authentication.CopyAuth copyConfig = new CopySDK.Authentication.CopyAuth("https://www.google.com", "euGvvY4EMzDGgHU3V2lBCaFlxdr0uBYb", "d3qCKDVdXlDP9fj4vbHOnSTPKT37jowRpXr4z60De8gWR3a3", scope);

            var authToken = await copyConfig.GetRequestTokenAsync();

            var url = string.Format("{0}?oauth_token={1}", URL.Authorize, authToken.Token);

            string verifier;
            using (Browser browser = new Browser(url, currentCloud))
            {
                browser.ShowDialog();
                verifier = browser.code;
            }

            var result = await copyConfig.GetAccessTokenAsync(verifier);

            using (SQLiteConnection conn = new SQLiteConnection("data source=SecureCloud.db"))
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();

                    SQLiteHelper sh = new SQLiteHelper(cmd);
                    var dic = new Dictionary<string, object>();
                    dic["type"] = 2;
                    dic["name"] = accountName.Text;
                    dic["access_token"] = result.AuthToken.Token;
                    dic["refresh_token"] = result.AuthToken.TokenSecret;

                    sh.Insert("account", dic);


                    // do something...

                    conn.Close();
                }
            }
            PictureBox pbx = this.Controls.Find("copyState", true).FirstOrDefault() as PictureBox;
            pbx.Visible = true;
            CheckBox chbx = this.Controls.Find("checkCopy", true).FirstOrDefault() as CheckBox;
            chbx.Enabled = true;

        }

        private async Task RunAuthBoxAsync()
        {
            var config = new BoxConfig("g0ai2rnmuq3yi7amn3uqena5rzs3rghz", "CzdqnhlhRBQEgia8Xcgoat3zmerAmMN1", new Uri("https://www.google.com"));
            var client = new BoxClient(config);
            string authUri = config.AuthCodeUri.AbsoluteUri;
            string code;
            using (Browser browser = new Browser(authUri, currentCloud))
            {
                browser.ShowDialog();
                code = browser.code;
            }
            var session = await client.Auth.AuthenticateAsync(code);
            var folderReq = new BoxFolderRequest()
            {
                Name = "SecureCloud",
                Parent = new BoxRequestEntity() { Id = "0" }
            };
            string id;
            try
            {
                BoxFolder f = await client.FoldersManager.CreateAsync(folderReq);
                id = f.Id;
            }
            catch (BoxConflictException<BoxFolder> ex)
            {
                BoxFolder f = ex.ConflictingItems.First();
                id = f.Id;
            }

            using (SQLiteConnection conn = new SQLiteConnection("data source=SecureCloud.db"))
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();

                    SQLiteHelper sh = new SQLiteHelper(cmd);
                    var dic = new Dictionary<string, object>();
                    dic["type"] = 1;
                    dic["name"] = accountName.Text;
                    dic["access_token"] = session.AccessToken;
                    dic["refresh_token"] = session.RefreshToken;
                    dic["id"] = id;

                    sh.Insert("account", dic);


                    // do something...

                    conn.Close();
                }
            }
            PictureBox pbx = this.Controls.Find("boxState", true).FirstOrDefault() as PictureBox;
            pbx.Visible = true;
            CheckBox chbx = this.Controls.Find("checkBox", true).FirstOrDefault() as CheckBox;
            chbx.Enabled = true;


        }

        private async Task RunAuthDropboxAsync()
        {
            var options = new Options
            {
                ClientId = "3vf0djj7k3sp6u0",
                ClientSecret = "c7oca4aa2ya73dx",
                RedirectUri = "https://www.google.com"
            };

            // Initialize a new Client (without an AccessToken)
            var client = new Client(options);

            // Get the OAuth Request Url
            var authRequestUrl = client.Core.OAuth2.Authorize("code");
            string code;
            using (Browser browser = new Browser(authRequestUrl.AbsoluteUri, currentCloud))
            {
                browser.ShowDialog();
                code = browser.code;
            }

            // Exchange the Authorization Code with Access/Refresh tokens
            var token = await client.Core.OAuth2.TokenAsync(code);
            using (SQLiteConnection conn = new SQLiteConnection("data source=SecureCloud.db"))
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();

                    SQLiteHelper sh = new SQLiteHelper(cmd);
                    var dic = new Dictionary<string, object>();
                    dic["type"] = 0;
                    dic["name"] = accountName.Text;
                    dic["access_token"] = token.access_token;

                    sh.Insert("account", dic);


                    // do something...

                    conn.Close();
                }
            }
            PictureBox pbx = this.Controls.Find("dropboxState", true).FirstOrDefault() as PictureBox;
            CheckBox chbx = this.Controls.Find("checkDropbox", true).FirstOrDefault() as CheckBox;
            chbx.Enabled = true;
            pbx.Visible = true;
        }

        private void checkDropbox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDropbox.Checked)
            {
                countClouds++;
            }
            else
            {
                countClouds--;
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked)
            {
                countClouds++;
            }
            else
            {
                countClouds--;
            }
        }

        private void checkCopy_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCopy.Checked)
            {
                countClouds++;
            }
            else
            {
                countClouds--;
            }
        }

        private void checkMega_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMega.Checked)
            {
                countClouds++;
            }
            else
            {
                countClouds--;
            }
        }

        private void checkOneDrive_CheckedChanged(object sender, EventArgs e)
        {
            if (checkOneDrive.Checked)
            {
                countClouds++;
            }
            else
            {
                countClouds--;
            }
        }

        private void threshold_ValueChanged(object sender, EventArgs e)
        {
            if (threshold.Value > 2 && threshold.Value > countClouds) threshold.Value--;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages[1])
            {
                fileViewer.Rows.Clear();
                fileViewer.Refresh();
                using (SQLiteConnection conn = new SQLiteConnection("data source=SecureCloud.db"))
                {
                    using (SQLiteCommand cmd = new SQLiteCommand())
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        SQLiteHelper sh = new SQLiteHelper(cmd);
                        DataTable dt = sh.Select("select * from file");
                        var i = 0;
                        foreach(DataRow row in dt.Rows)
                        {
                            fileViewer.Rows.Add(new object[]{
                                ++i,
                                row["name"],
                                row["n"],
                                row["k"],
                                row["Local"],
                                row["Dropbox"],
                                row["Box"],
                                row["Copy"],
                                row["Mega"],
                                row["OneDrive"]
                            });
                        }
                    }
                }
            }
        }
    }
}


