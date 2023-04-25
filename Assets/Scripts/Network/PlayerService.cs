using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Network.Models;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using Service;

namespace Assets.Scripts.Network
{
    class PlayerService : MonoBehaviour
    {

        private static string APIKEY;
        public void Start()
        {
            APIKEY = APIClient.APIKEY;

            StartCoroutine(UpdateAccountInfo());

        }


        // get player statistics and info form server
        static public IEnumerator GetPlayerStats()
        {
            
            var unityWeb = new UnityWebRequest(APIData.GetURL() + "/api/v1/auth/player/get_stats", "GET");
            //byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            //unityWeb.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            unityWeb.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            unityWeb.SetRequestHeader("Content-Type", "application/json");
            unityWeb.SetRequestHeader("Authorization", APIKEY);
            yield return unityWeb.SendWebRequest();


            if (unityWeb.isNetworkError || unityWeb.isHttpError)
            {
                Debug.Log("Error While Sending: " + unityWeb.error);
            }
            else
            {
                Debug.Log(unityWeb.downloadHandler.text);
                var text = unityWeb.downloadHandler.text;
                var bsonDocument = BsonDocument.Parse(text);
                var result = BsonSerializer.Deserialize<GetPlayerInfoResponse>(text);
                Debug.Log(result.run_info.distance);
            }
        }



        // update player run information on the server
        static public IEnumerator UpdateRunInfo()
        {
            UpdateRunRequest updateRunRequest = new UpdateRunRequest();
            updateRunRequest.distance = 720;

            string json = JsonConvert.SerializeObject(updateRunRequest);
            var unityWeb = new UnityWebRequest(APIData.GetURL() + "/api/v1/auth/player/update_stats", "POST");
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            unityWeb.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            unityWeb.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            unityWeb.SetRequestHeader("Content-Type", "application/json");
            unityWeb.SetRequestHeader("Authorization", APIKEY);
            yield return unityWeb.SendWebRequest();


            if (unityWeb.isNetworkError || unityWeb.isHttpError)
            {
                Debug.Log("Error While Sending: " + unityWeb.error);
            }
            else
            {
                Debug.Log(unityWeb.downloadHandler.text);
                var text = unityWeb.downloadHandler.text;
                //GetWalletResponse result = JsonUtility.FromJson<GetWalletResponse>(text);
                //var bsonDocument = BsonDocument.Parse(text);
                var result = BsonSerializer.Deserialize<UpdateRunResponse>(text);
                Debug.Log(result.run_info.high_score);
            }
        }


        static public IEnumerator UpdateAccountInfo()
        {
            UpdateAccountInfoRequest updateAccountInfoRequest = new UpdateAccountInfoRequest();
            updateAccountInfoRequest.bank_name = "Deutchet bank";
            updateAccountInfoRequest.account_name = "John Perry";
            updateAccountInfoRequest.account_number = "09283094";

            string json = JsonConvert.SerializeObject(updateAccountInfoRequest);
            var unityWeb = new UnityWebRequest(APIData.GetURL() + "/api/v1/auth/player/add_account_details", "POST");
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            unityWeb.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            unityWeb.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            unityWeb.SetRequestHeader("Content-Type", "application/json");
            unityWeb.SetRequestHeader("Authorization", APIKEY);
            yield return unityWeb.SendWebRequest();


            if (unityWeb.isNetworkError || unityWeb.isHttpError)
            {
                Debug.Log("Error While Sending: " + unityWeb.error);
            }
            else
            {
                Debug.Log(unityWeb.downloadHandler.text);
                var text = unityWeb.downloadHandler.text;
                //GetWalletResponse result = JsonUtility.FromJson<GetWalletResponse>(text);
                //var bsonDocument = BsonDocument.Parse(text);
                var result = BsonSerializer.Deserialize<GeneralResponse>(text);
                Debug.Log(result.message);
            }
        }
    }
}
