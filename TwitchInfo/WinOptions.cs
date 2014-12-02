using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;

namespace TwitchInfo
{
    public partial class WinOptions : Form
    {
        public WinOptions()
        {
            InitializeComponent();
        }

        private void OptionsTwitchCheck_B_Click(object sender, EventArgs e)
        {
            string username = OptionsTwitchUsername_T.Text;

            bool check = this.CheckUsername(username);

            if (check)
                OptionsTwitchCheck_L.Text = "Correct!";
            else
                OptionsTwitchCheck_L.Text = "Invalid!";
        }

        private bool CheckUsername(string username)
        {

            try
            {
                WebRequest request = WebRequest.Create("https://api.twitch.tv/kraken/users/" + username);
                // If required by the server, set the credentials.
                request.Credentials = CredentialCache.DefaultCredentials;
                request.ContentType = "application/vnd.twitchtv.v3+json";
                request.Method = "GET";

                WebResponse resp = request.GetResponse();

                resp.Close();
            }
            catch (WebException e)
            {
                string msg = e.Message;

                if (Regex.Match(msg, "404").Success)
                    return false;
            }

            return true;

        }
    }
}
