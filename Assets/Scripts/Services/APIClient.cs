using System;
using System.Net.Http;
using System.Net.Http.Headers;
using UnityEngine;

namespace Service
{

    public static  class APIClient{
        public static HttpClient client = new HttpClient();
        private static  string  URL = APIData.GetURL();
         
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

        public static void PostRequest()
        {
            LoginRequest loginRequest = new LoginRequest();
            loginRequest.Email = "email";
            loginRequest.Code = "code";
            //string json = JsonConvert.SerializeObject(loginRequest);
        }
        
    }   

    class LoginRequest
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }
}