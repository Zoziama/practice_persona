using System.Collections.Generic;

namespace practice.Common
{
    public class SmsResponseModel
    {
        public Data data { get; set; }
        public int _0 { get; set; }
    }
    
    public class Data
    {
        public string status { get; set; }
        public string message { get; set; }
        public string message_id { get; set; }
        public double cost { get; set; }
        public string currency { get; set; }
        public string gateway_used { get; set; }
    }
    
}