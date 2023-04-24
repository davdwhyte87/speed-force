using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Assets.Scripts.Network.Models;
using Newtonsoft.Json;
using Service;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Network
{
    public  class PlayerAuthService : MonoBehaviour
    {   

        public  void Start()
        {
            
           // StartCoroutine(PlayerService.Login());
        

        }
        static IEnumerator SignUp()
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


        static public  IEnumerator Login()
        {
           
            LoginRequest loginRequest = new LoginRequest();
            loginRequest.email = "email12@x.com";
            loginRequest.code = "49039";
            string json = JsonConvert.SerializeObject(loginRequest);
            var unityWeb = new UnityWebRequest(APIData.GetURL() + "/user/login", "POST");
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            unityWeb.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            unityWeb.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            unityWeb.SetRequestHeader("Content-Type", "application/json");
            yield return unityWeb.SendWebRequest();

            
            if (unityWeb.isNetworkError || unityWeb.isHttpError)
            {
                Debug.Log("Error While Sending: " + unityWeb.error);
                Debug.Log("Error Data: " + unityWeb.downloadHandler.text);
            }
            else
            {
                Debug.Log(unityWeb.downloadHandler.text);
                var text = unityWeb.downloadHandler.text;
                LoginResponse result = JsonUtility.FromJson<LoginResponse>(text);
                Debug.Log(result.ToString());
            }

           
        }

        static public IEnumerator GetCode()
        {
            GetCodeRequest getCodeRequest = new GetCodeRequest();
            getCodeRequest.email = "email12@x.com";
            
            string json = JsonConvert.SerializeObject(getCodeRequest);
            var unityWeb = new UnityWebRequest(APIData.GetURL() + "/user/get_code", "POST");
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
                GetCodeResponse result = JsonUtility.FromJson<GetCodeResponse>(text);
                Debug.Log(result.ToString());
            }
        }
    }
}
