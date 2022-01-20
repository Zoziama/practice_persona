using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl.Http;
using practice.BusinessLogic.Interfaces;
using practice.Common;

namespace practice.BusinessLogic.Implementation
{
    public class NinService : INinService
    {
        public async Task<NinResponseModel> GetNinData(string nin)
        {
            string url = "https://api.verified.africa/sfx-verify/v3/id-service/";
            var result = await url.WithHeaders(new Dictionary<string, string>
                {
                    { "apiKey", "gbP49e4EGNMo21dwrso2"},
                    { "userid", "1630360766695"}
                }).PostJsonAsync(new NinRequestModel
                {
                    searchParameter = nin, 
                    verificationType = "NIN-SEARCH", 
                    transactionReference = ""
                })
                .ReceiveJson<NinResponseModel>();
            return result;
        }

        public bool isNinValid(PersonaViewModel PVM, NinResponseModel NRM)
        {
            if (!PVM.Email.Equals(NRM.response[0].email, StringComparison.OrdinalIgnoreCase) 
            || !PVM.PhoneNumber.Equals(NRM.response[0].telephoneno, StringComparison.OrdinalIgnoreCase)
            || !PVM.FirstName.Equals(NRM.response[0].firstname, StringComparison.OrdinalIgnoreCase)
            || !PVM.MiddleName.Equals(NRM.response[0].middlename, StringComparison.OrdinalIgnoreCase)
            || !PVM.LastName.Equals(NRM.response[0].surname, StringComparison.OrdinalIgnoreCase) )
            {
                return false;
            }

            return true;
        }
    }
}