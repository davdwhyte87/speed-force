using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Network.Models;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using Service;

namespace Assets.Scripts.Network
{
    class WalletService : MonoBehaviour
    {
        public static int WalletBalance;

        private static string APIKEY;
        // get wallet data
        // buy coins 

        public void Start()
        {
            APIKEY = APIClient.APIKEY;
            //StartCoroutine(GetWallet());
            
        }



        // get a players wallet infromation from server
        static public IEnumerator GetWallet()
        {
            GetCodeRequest getCodeRequest = new GetCodeRequest();
            getCodeRequest.email = "email12@x.com";

            string json = JsonConvert.SerializeObject(getCodeRequest);
            var unityWeb = new UnityWebRequest(APIData.GetURL() + "/api/v1/auth/wallet/get_wallet", "GET");
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
                var bsonDocument = BsonDocument.Parse(text);
                var result = BsonSerializer.Deserialize<GetWalletResponse>(text);
                Debug.Log(result.wallet.amount);
                WalletBalance = result.wallet.amount;
            }
        }


        // this allows a player purchase coins vai the API
        // TODO: Intergrate Payment Gateway
        static public IEnumerator BuyCoins()
        {
            BuyCoinRequest buyCoinRequest = new BuyCoinRequest();
            buyCoinRequest.amount = "200";

            string json = JsonConvert.SerializeObject(buyCoinRequest);
            var unityWeb = new UnityWebRequest(APIData.GetURL() + "/api/v1/auth/wallet/buy_coin", "POST");
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
                var result = JsonConvert.DeserializeObject<GeneralResponse>(text);
                Debug.Log(result.message);
            }
        }



    }
}
