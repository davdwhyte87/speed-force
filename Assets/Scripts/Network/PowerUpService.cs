using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Network.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Service;

namespace Assets.Scripts.Network
{
    class PowerUpService : MonoBehaviour
    {
        private static string APIKEY;
        public void Start()
        {
            APIKEY = APIClient.APIKEY;
            StartCoroutine(GetAllPowerUps());

        }


        static public IEnumerator BuyPowerUps()
        {

            // not: We should do a check locally to know how many coins a player has 
            // then we can make the call to buy
            BuyPowerUpRequest buyPowerUpRequest = new BuyPowerUpRequest();
            buyPowerUpRequest.amount = 1;
            buyPowerUpRequest.power_up_type = PowerUpType.Phasing.ToString();

            string json = JsonConvert.SerializeObject(buyPowerUpRequest);
            var unityWeb = new UnityWebRequest(APIData.GetURL() + "/api/v1/auth/power_up/buy", "POST");
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            unityWeb.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            unityWeb.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            unityWeb.SetRequestHeader("Content-Type", "application/json");
            unityWeb.SetRequestHeader("Authorization", APIKEY);
            yield return unityWeb.SendWebRequest();


            if (unityWeb.isNetworkError || unityWeb.isHttpError)
            {
                Debug.Log("Error While Sending: " + unityWeb.error);
                Debug.Log("Errro info  " + unityWeb.downloadHandler.text);
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


        public static IEnumerator UsePowerUp()
        {
            UsePowerUpRequest usePowerUpRequest = new UsePowerUpRequest();
            usePowerUpRequest.power_up_type = PowerUpType.Phasing.ToString();

            string json = JsonConvert.SerializeObject(usePowerUpRequest);
            var unityWeb = new UnityWebRequest(APIData.GetURL() + "/api/v1/auth/power_up/use", "POST");
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            unityWeb.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            unityWeb.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            unityWeb.SetRequestHeader("Content-Type", "application/json");
            unityWeb.SetRequestHeader("Authorization", APIKEY);
            yield return unityWeb.SendWebRequest();


            if (unityWeb.isNetworkError || unityWeb.isHttpError)
            {
                Debug.Log("Error While Sending: " + unityWeb.error);
                Debug.Log("Errro info  " + unityWeb.downloadHandler.text);
            }
            else
            {
                Debug.Log(unityWeb.downloadHandler.text);
                var text = unityWeb.downloadHandler.text;
                //GetWalletResponse result = JsonUtility.FromJson<GetWalletResponse>(text);
                //var bsonDocument = BsonDocument.Parse(text);
                var result = BsonSerializer.Deserialize<UsePowerUpResponse>(text);
                Debug.Log(result.power_up.amount);
            }

        }


        public static IEnumerator GetAllPowerUps()
        {
            var unityWeb = new UnityWebRequest(APIData.GetURL() + "/api/v1/auth/power_up/get_all", "GET");
         
            unityWeb.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            unityWeb.SetRequestHeader("Content-Type", "application/json");
            unityWeb.SetRequestHeader("Authorization", APIKEY);
            yield return unityWeb.SendWebRequest();


            if (unityWeb.isNetworkError || unityWeb.isHttpError)
            {
                Debug.Log("Error While Sending: " + unityWeb.error);
                Debug.Log("Errro info  " + unityWeb.downloadHandler.text);
            }
            else
            {
                Debug.Log(unityWeb.downloadHandler.text);
                var text = unityWeb.downloadHandler.text;
                //GetWalletResponse result = JsonUtility.FromJson<GetWalletResponse>(text);
                //var bsonDocument = BsonDocument.Parse(text);
                var result = BsonSerializer.Deserialize<GetAllPowerUpsResponse>(text);
                Debug.Log(result.power_ups.Count);
            }

        }
    }
}
