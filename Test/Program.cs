using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Box.V2;
using Box.V2.Auth;
using Box.V2.Config;
using System.IO;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Run().Wait();
        }

        private static async Task Run()
        {
            var config = new BoxConfig("g0ai2rnmuq3yi7amn3uqena5rzs3rghz", "CzdqnhlhRBQEgia8Xcgoat3zmerAmMN1", new Uri("https://www.google.com"));
            var access_token = "tssRwyqaEPCduZDd4OYYziFgirdrIRbO";
            var refresh_token = "p40NGli6N4DGCKnoUCfs46FG2ITjOZ94rlyW7z8JWwesA1hWOJSwBMvk4ulz15J1";
            var auth = new OAuthSession(access_token, refresh_token, 3600, "bearer");

            var client = new BoxClient(config, auth);
            //var new_auth = await client.Auth.RefreshAccessTokenAsync(refresh_token);
            using (var stream = await client.FilesManager.DownloadStreamAsync("51550708361"))
            {
                using (var fileStream = File.Create("e:\\result\\test.txt10"))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    await stream.CopyToAsync(fileStream);
                    fileStream.Close();
                }
                stream.Close();
            }

        }
    }
}
