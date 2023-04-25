using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Assets.Scripts.Network.Models
{
    internal class Player
    {
    }


    public class GetPlayerInfoResponse
    {
        public RunInfo run_info { get; set; }
    }

    public class UpdateRunResponse
    {
        public RunInfo run_info { get; set; }
    }

    public class RunInfo
    {
        public ObjectId _id { get; set; }
        public string user_email { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }

        public int distance { get; set; }

        public int high_score { get; set; }

    }

    class UpdateRunRequest
    {public int distance { get; set; }

    }

    class UpdateAccountInfoRequest
    {
        public string account_name { get; set; }
        public string account_number { get; set; }
        public string bank_name { get; set; }
    }
}
