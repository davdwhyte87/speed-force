using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Service;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Collections;
using Assets.Scripts.Network.Models;

namespace Assets.Scripts
{
    class NetworkTest : MonoBehaviour
    {

         void  Start()
        {
           StartCoroutine(SignUp());
        }
        public void  Connect()
        {
            //var result  = Service.AuthService.SignUp();
            //Debug.Log(result.);
        }

        IEnumerator Login()
        {
            LoginRequest loginRequest = new LoginRequest();
            loginRequest.email = "email";
            loginRequest.code = "code";
            string json = JsonConvert.SerializeObject(loginRequest);
            var unityWeb = new UnityWebRequest(APIData.GetURL()+"/user", json);
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            unityWeb.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            unityWeb.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            unityWeb.SetRequestHeader("Content-Type", "application/json");
            yield return unityWeb.SendWebRequest();


            if (unityWeb.isNetworkError || unityWeb.isHttpError)
            {
                Debug.Log("Error While Sending: " + unityWeb.error);
            }
            else
            {
                Debug.Log(unityWeb.downloadHandler.text);
            }
        }

        IEnumerator SignUp()
        {
            SignupRequest signupRequest = new SignupRequest();
            signupRequest.email = "email12@x.com";
            signupRequest.user_type = "Player";
            signupRequest.name = "John bot";
            string json = JsonConvert.SerializeObject(signupRequest);
            var unityWeb = new UnityWebRequest(APIData.GetURL() + "/user", "POST");
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            unityWeb.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            unityWeb.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            unityWeb.SetRequestHeader("Content-Type", "application/json");
            yield return unityWeb.SendWebRequest();


            if (unityWeb.isNetworkError || unityWeb.isHttpError)
            {
                Debug.Log("Error While Sending: " + unityWeb.error);
               
            }
            else
            {
                Debug.Log(unityWeb.downloadHandler.text);
                var text = unityWeb.downloadHandler.text;
                SignupResponse result = JsonUtility.FromJson<SignupResponse>(text);
                Debug.Log(result);
            }
        }
    }


    

 

    class SignupRequest
    {
        public string email { get; set; }
        public string name { get; set; }
        public string user_type { get; set; }
    }

    class SignupResponse
    {
        public string message { get; set; }
    }
}
