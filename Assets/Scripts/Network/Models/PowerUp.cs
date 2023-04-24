using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Numerics;

namespace Assets.Scripts.Network.Models
{
    internal class PowerUp
    {
    }

    [System.Serializable]
    class BuyPowerUpRequest
    {
        public string power_up_type;
        public int amount;
    }

    class UsePowerUpRequest
    {
        public string power_up_type;
    }

    class PlayerPowerUp
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonConverter(typeof(BsonObjectIdConverter))]
        public ObjectId _id { get; set; }
        public string user_email { get; set; }
        public string created_at { get; set; }
        public int amount { get; set; }

        public PowerUpType power_up_type { get; set; }
        public int in_game_amount { get; set; }
    }

    class UsePowerUpResponse
    {
        public PlayerPowerUp power_up;
    }

    class GetAllPowerUpsResponse
    {
        public List<PlayerPowerUp> power_ups;
    }


    [System.Serializable]
    enum PowerUpType
    {
        Phasing,
        Blast,
        SlowMotion

    }
}
