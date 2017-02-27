using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;

namespace SecureCloud
{

    public partial class Browser : Form
    {

        public string code;
        public string current;

        public Browser()
        {
            InitializeComponent();
        }

        public Browser(string uri, string current)
        {
            InitializeComponent();
            webBrowser.Url = new Uri(uri);
            this.current = current;
        }

        // Navigates to the given URL if it is valid.
        private void Navigate(String address)
        {
            if (String.IsNullOrEmpty(address)) return;
            if (address.Equals("about:blank")) return;
            if (!address.StartsWith("http://") &&
                !address.StartsWith("https://"))
            {
                address = "http://" + address;
            }
            try
            {
                webBrowser.Navigate(new Uri(address));
            }
            catch (System.UriFormatException)
            {
                return;
            }
        }

        private void viewUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Navigate(viewUrl.Text);
            }
        }

        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            viewUrl.Text = webBrowser.Url.ToString();
            if (webBrowser.Url.Host == "www.google.com")
            {
                if (current == "Copy")
                {
                    code = HttpUtility.ParseQueryString(webBrowser.Url.Query).Get("oauth_verifier");
                }
                else
                {
                    code = HttpUtility.ParseQueryString(webBrowser.Url.Query).Get("code");
                }
                this.Close();
            }
        }
    }
}
