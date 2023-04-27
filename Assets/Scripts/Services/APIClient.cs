using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;
using Assets.Scripts.Network.Models;

namespace Service
{

    public static  class APIClient{
        public static HttpClient client = new HttpClient();
        private static  string  URL = APIData.GetURL();
        public static string APIKEY = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJyb2xlIjoiUGxheWVyIiwiZW1haWwiOiJlbWFpbDEyQHguY29tIiwibmFtZSI6IkpvaG4gYm90IiwiZXhwIjoxNjgyNDM4ODUxfQ.dXy-R04GVZiRp1BLcD5ajPG-fVvZXksCQo18VCCaLqE";


        public  static HttpClient GetAPIClient(){
            // Debug.Log(URL);
            client.BaseAddress = new Uri(URL);
              // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Authorization",
                "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJyb2xlIjoiUGxheWVyIiwiZW1haWwiOiJvbGFib3NAeC5jb20iLCJuYW1lIjoib2xhYm9zdW4xMDAiLCJleHAiOjE2Nzg4MDE5MzB9.IXKtERjdyOZ5ypiS-6zgnFtcxsdABPwWdCiWgS_Px3c"
            );

            return client;
        }

        public static HttpResponseMessage GetRequest(string url){
            client = GetAPIClient();
            // client.PostAsync()     
            
            HttpResponseMessage response = client.GetAsync(url).Result; 
             if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                // var dataObjects = response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                // foreach (var d in dataObjects)
                // {
                //     Console.WriteLine("{0}", d.Name);
                // }

                Debug.Log("Successful request");
            }
            else
            {
                Debug.Log("Unsuccessful request");
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                Debug.Log(((int)response.StatusCode));
            }

            return response;
        }

        public static IEnumerator<HttpResponseMessage> PostRequest(string url)
        {
            Debug.Log("Sending post reuqest ");
            LoginRequest loginRequest = new LoginRequest();
            loginRequest.email = "email";
            loginRequest.code = "code";
            string json = JsonConvert.SerializeObject(loginRequest);
            var header = new Dictionary<string, string>()
            {
                {"Mkol","Value" }
            };
            Debug.Log(json);
            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Post;
            var finalUrl = APIData.GetURL() + url;
            httpRequestMessage.RequestUri = new Uri(finalUrl);
           



            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            httpRequestMessage.Content = httpContent;

            var _client = GetAPIClient();

            Debug.Log("Sending....");
            var result = _client.SendAsync(httpRequestMessage).Result;
            yield return result;
        }


        static async Task<HttpResponseMessage> Request(HttpMethod httpMethod, string pUrl, string requestContent, Dictionary<string, string> headers)
        {
            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = httpMethod;
            var finalUrl = APIData.GetURL() + pUrl;
            httpRequestMessage.RequestUri = new Uri(finalUrl);
            foreach (var head in headers)
            {
                httpRequestMessage.Headers.Add(head.Key, head.Value);
            }



            HttpContent httpContent = new StringContent(requestContent, Encoding.UTF8, "application/json");
            httpRequestMessage.Content = httpContent;

            var _client = GetAPIClient();

            Debug.Log("Sending....");
            var result =await _client.SendAsync(httpRequestMessage);
            return result; 
        }

    }   

 

  
}