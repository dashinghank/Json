using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Utilities;

namespace JSONS
{
    internal class Program
    {
        private static void Main(string[] args)
        {
           /* string URL = "http://175.98.160.67/vuewstest/WeatherForecast";
            WebRequest request = WebRequest.Create(URL);
            request.ContentType = "application/json; charset=utf-8";
            WebResponse response = request.GetResponse() as WebResponse;
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
            Console.WriteLine(reader.ReadToEnd());
           */
            HttpRequestTool tool = new HttpRequestTool();
            string v = tool.Post("http://175.98.160.67/vuewstest/chat/GetUserInfo", new { userId = "Player001" });
            GetUserInfo user = JsonConvert.DeserializeObject<GetUserInfo>(v);

        }

        class UserList
        {
           public List<GetUserInfo> users;
        }
        class GetUserInfo
        {
         public   string state;
            public object details;
        }
        
        

    }
    
}