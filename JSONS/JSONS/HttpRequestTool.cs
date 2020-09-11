using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Utilities
{
    public class HttpRequestTool
    {
        public async Task<string> PostAsync(string url, object data)
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(await request.GetRequestStreamAsync().ConfigureAwait(false)))
            {
                string json = JsonConvert.SerializeObject(data);
                //var json = Encoding.UTF8.GetBytes(data);
                await streamWriter.WriteAsync(json).ConfigureAwait(false);
            }

            var httpResponse = (HttpWebResponse)request.GetResponse();
            using var streamReader = new StreamReader(httpResponse.GetResponseStream());
            var result = await streamReader.ReadToEndAsync().ConfigureAwait(false);
            return result;
        }

        public string Post(string url, object data)
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(data);
                //var json = Encoding.UTF8.GetBytes(data);
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)request.GetResponse();
            using var streamReader = new StreamReader(httpResponse.GetResponseStream());
            return streamReader.ReadToEnd();
        }
    }
}