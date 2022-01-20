namespace practice.Common
{
    public class SmsRequestModel
    {
        public string api_Token { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string body { get; set; }
    }
}