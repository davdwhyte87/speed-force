using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json.Converters;
using UnityEngine;


namespace Assets.Scripts.Network.Models
{
    [System.Serializable]
    class Wallet
    {
        [MongoDB.Bson.Serialization.Attributes.BsonElement("_id")]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonConverter(typeof(BsonObjectIdConverter))]
        public ObjectId  _id { get; set; }
        public string user_email { get; set; }
        public string created_at { get; set; }
        public int amount { get; set; }
    }

   

    

    [System.Serializable]
    class GetWalletResponse 
    { 
        public Wallet wallet { get; set; }
    }


    [System.Serializable]
    class BuyCoinRequest
    {
        public string amount { get; set; }
    }

    class GeneralResponse
    {
        public string message { get; set; }
    }

}
