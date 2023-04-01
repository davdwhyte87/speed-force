using System;
using System.Net.Http;


namespace Service{
    public static class AuthService{
     
        // public  HttpClient client;
        // signs a new user up via the internet
        public static  void Signup(){
            HttpResponseMessage response  = APIClient.GetRequest("/signup");
            //var n = new FormUrlEncodedContent();
            // HttpResponseMessage response = client.GetAsync("/wallet").Result; 
            //  if (response.IsSuccessStatusCode)
            // {
            //     // Parse the response body.
            //     // var dataObjects = response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
            //     // foreach (var d in dataObjects)
            //     // {
            //     //     Console.WriteLine("{0}", d.Name);
            //     // }

            //     Debug.Log("Successful request");
            // }
            // else
            // {
            //     Debug.Log("Unsuccessful request");
            //     Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            //     Debug.Log(((int)response.StatusCode));
            // }
        }
    }
}