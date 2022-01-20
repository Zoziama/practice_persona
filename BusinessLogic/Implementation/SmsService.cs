using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using practice.BusinessLogic.Interfaces;
using practice.Common;

namespace practice.BusinessLogic.Implementation
{
    public class SmsService : ISmsService
    {
        public async Task<SmsResponseModel> SendSms(string phoneno)
        {
            //string url = "https://www.bulksmsnigeria.com/api/v1/sms/create";
            var smsRequest = new SmsRequestModel
            {
                from = "Zaiman",
                to = phoneno,
                body = "I love you ho, don't be sad, ho, get the bag, ho",
                api_Token = "Bc2P8aP3AseLjxH7xJkCmnTjuWWXhYmtpocG2N92FkU1VOIWLbWDpV0kOOEs"
            };
            string queryurl = "https://www.bulksmsnigeria.com/api/v1/sms/create?" +
                              $"api_token={smsRequest.api_Token}&from={smsRequest.from}&to={smsRequest.to}&body={smsRequest.body}&dnd=2";
            var result = await queryurl.GetJsonAsync<SmsResponseModel>();
            return result;
        } 
    }
}