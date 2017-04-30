using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace WowheadParser
{
    public class JsonUtilities
    {
        /// <summary>
        /// Helper function to remove the var = part of the json file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string FromJavascript(string fileName)
        {
            return File.ReadAllText(fileName);
        }

        /// <summary>
        /// Fetch JSON from a web api/website
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string FetchJson(string url)
        {
            var req = (HttpWebRequest)WebRequest.Create(url);
            req.ContentType = "text/html";
            req.Accept = "Accept: text/html,application/xhtml+xml,application/xml";
            req.Proxy = null;

            // Get the stream from the returned web response
            var stream = new StreamReader(req.GetResponse().GetResponseStream());
        
            // Get the stream from the returned web response
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string strLine;
            // Read the stream a line at a time and place each one
            // into the stringbuilder
            while ((strLine = stream.ReadLine()) != null)
            {
                // Ignore blank lines
                if (strLine.Length > 0)
                    sb.Append(strLine);
            }
            // Finished with the stream so close it now
            stream.Close();

            return sb.ToString();
        }
    }
}