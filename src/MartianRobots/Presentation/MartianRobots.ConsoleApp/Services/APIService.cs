using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.ConsoleApp.Services
{
    internal class APIService
    {
        protected const string userName = "Admin";
        protected const string password = "Admin";
        protected const string apiPort = "44348";

        protected HttpRequestMessage GetHttpRequestMessage(HttpContent content, string ApiURL)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, ApiURL);
            content.Headers.ContentType.CharSet = "";
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var authenticationString = $"{userName}:{password}";
            var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.UTF8.GetBytes(authenticationString));

            httpRequestMessage.Content = content;

            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue(
                scheme: "Basic",
                parameter: base64EncodedAuthenticationString
            );

            return httpRequestMessage;
        }
    }
}
