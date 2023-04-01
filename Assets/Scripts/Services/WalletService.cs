using System;
using System.Net.Http;

namespace Service
{
    public static class WalletService
    {
        
        
        public static void GetWallet()
        {
            String URL = APIData.GetURL();
            HttpResponseMessage response = APIClient.GetRequest("/wallet/get_wallet");
            
        }
    }
}


