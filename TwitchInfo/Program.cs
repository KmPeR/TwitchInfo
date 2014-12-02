using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Configuration;
using System.Web;
using System.IO;

namespace TwitchInfo
{
    class TwitchInfo
    {
        private static bool flag = false;

        public TwitchInfo()
        {
            
            string appKey = "58debv6ie7o70yzcsxgj2sz3ipbwhrg";

            string url = "https://api.twitch.tv/kraken/oauth2/authorize"+
                         "?response_type=code"+
                         "&client_id=" + appKey +
                         "&redirect_uri="+"http://localhost:8182/"+
                         "&scope=user_read";

            System.Diagnostics.Process.Start(url);

            WebServer ws = new WebServer(SendResponse, "http://localhost:8182/");
            ws.Run();
            while(flag != true);
            ws.Stop();

            // Create a request for the URL. 
            WebRequest request = WebRequest.Create("https://api.twitch.tv/kraken/users/kmper/follows/channels");
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            request.ContentType = "application/vnd.twitchtv.v3+json";
            request.Method = "GET";
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Clean up the streams and the response.
            reader.Close();
            response.Close();

            while (flag != true || true) ;

        }

        static string GetHTMLResult(HttpListenerRequest request)
        {
            string htmlTitle = "KmPeR | Twitch Info";
            string htmlStatus = "<< STATUS >>";
            string htmlDesc = "-== DESC ==-";
            string htmlClass = "";

            string error = request.QueryString["error"];
            string error_description = request.QueryString["error_description"];
            string code = request.QueryString["code"];
            string scope = request.QueryString["scope"];

            string e = request.QueryString["e"];
            string a = request.QueryString["a"];

            bool form = true;

            if (e != null || a != null)
            {
                htmlStatus = "Information";
                form = false;
                if(e!=null)
                {
                    htmlDesc = "You can close this window now, but 'Twitch Info' will be closed.";
                }
                else
                {
                    htmlDesc = "You can close this window now and return to 'Twitch Info'.";
                }
            }
            else
            {
                if (error != null)
                {
                    htmlClass = "fail";
                    htmlStatus = "Authentication error!";
                    htmlDesc = "Sorry, 'Twitch Info' may not work for you.";
                }
                else
                {
                    htmlClass = "success";
                    htmlStatus = "Authentication success!";
                    htmlDesc = "Thanks, 'Twitch Info' can works for You!";
                }
            }

            StringBuilder htmlBuilder = new StringBuilder();

            htmlBuilder.Append("<!DOCTYPE HTML>");
            htmlBuilder.Append("<html>");

            htmlBuilder.Append("<head>");
            htmlBuilder.Append(string.Format("<title>{0}</title>", htmlTitle));
            htmlBuilder.Append("<link href=\"http://www.kmper.ugu.pl/oauth/css/style.css\" rel=\"stylesheet\" type=\"text/css\" media=\"all\" />");
            htmlBuilder.Append("<link href='http://fonts.googleapis.com/css?family=Petit+Formal+Script' rel='stylesheet' type='text/css'>");
            htmlBuilder.Append("<link href='http://fonts.googleapis.com/css?family=Alegreya+Sans:300,400' rel='stylesheet' type='text/css'>");
            htmlBuilder.Append("<link href='http://fonts.googleapis.com/css?family=Titillium+Web:400,300' rel='stylesheet' type='text/css'>");
            htmlBuilder.Append("<link href='http://fonts.googleapis.com/css?family=Handlee' rel='stylesheet' type='text/css'>");
            htmlBuilder.Append("</head>");
            htmlBuilder.Append(string.Format("<body class=\"{0}\">", htmlClass));

            htmlBuilder.Append("<div class=\"content\">");
            htmlBuilder.Append("<div class=\"wrap\">");
            htmlBuilder.Append("<div class=\"content-grid\"></div>");
            htmlBuilder.Append("<div class=\"grid\">");
            htmlBuilder.Append(string.Format("<h3>{0}</h3>", htmlStatus));
            htmlBuilder.Append(string.Format("<h4>{0}</h4>", htmlDesc));
            htmlBuilder.Append("<div class=\"clear\"></div>");

            if(form)
            {
                htmlBuilder.Append("<form action=\"http://localhost:8182/\" method=\"GET\">");
                htmlBuilder.Append("<input id=\"cancelbutton\" name=\"e\" type=\"submit\" value=\"Cancel\" />&nbsp;");
                htmlBuilder.Append("<input id=\"gobutton\" name=\"a\" type=\"submit\" value=\"Go!\" />");
                htmlBuilder.Append("<form>");
            }

            htmlBuilder.Append("</div>");
            htmlBuilder.Append("<div class=\"clear\"></div>");
            htmlBuilder.Append("<div class=\"footer\">");
            htmlBuilder.Append("<p>Copyright 2013&nbspTemplate by <a href=\"http://w3layouts.com\"> w3layouts.com</a> </p>");
            htmlBuilder.Append("</div>");
            htmlBuilder.Append("<div class=\"clear\"></div>");
            htmlBuilder.Append("</div>");
            htmlBuilder.Append("</div>");
            htmlBuilder.Append("<div class=\"clear\"></div>");

            htmlBuilder.Append("</html>");
            htmlBuilder.Append("</body>");

            return htmlBuilder.ToString();
        }

        static string SendResponse(HttpListenerRequest request)
        {
            string e = request.QueryString["e"];
            string a = request.QueryString["a"];

            if (e != null || a != null)
                flag = true;

            return GetHTMLResult(request);
        }
    }
}
