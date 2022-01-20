using System.Collections.Generic;

namespace practice.Common
{
    public class NinResponseModel
    {
        public string responseCode { get; set; }
        public string description { get; set; }
        public string verificationType { get; set; }
        public string verificationStatus { get; set; }
        public string transactionStatus { get; set; }
        public string transactionReference { get; set; }
        public string transactionDate { get; set; }
        public string searchParameter { get; set; }
        public List<Response> response { get; set; }
    }
    
   // Root myDeserializedClass = JsonConvert.Deserializestring<Root>(myJsonResponse);
    public class Response
    {
        public string batchid { get; set; }
        public string birthcountry { get; set; }
        public string birthdate { get; set; }
        public string birthlga { get; set; }
        public string birthstate { get; set; }
        public string cardstatus { get; set; }
        public string centralID { get; set; }
        public string documentno { get; set; }
        public string educationallevel { get; set; }
        public string email { get; set; }
        public string emplymentstatus { get; set; }
        public string firstname { get; set; }
        public string gender { get; set; }
        public string heigth { get; set; }
        public string maidenname { get; set; }
        public string maritalstatus { get; set; }
        public string middlename { get; set; }
        public string nin { get; set; }
        public string nok_address1 { get; set; }
        public string nok_address2 { get; set; }
        public string nok_firstname { get; set; }
        public string nok_lga { get; set; }
        public string nok_middlename { get; set; }
        public string nok_postalcode { get; set; }
        public string nok_state { get; set; }
        public string nok_surname { get; set; }
        public string nok_town { get; set; }
        public string nspokenlang { get; set; }
        public string ospokenlang { get; set; }
        public string othername { get; set; }
        public string pfirstname { get; set; }
        public string photo { get; set; }
        public string pmiddlename { get; set; }
        public string profession { get; set; }
        public string psurname { get; set; }
        public string religion { get; set; }
        public string residence_AdressLine1 { get; set; }
        public string residence_AdressLine2 { get; set; }
        public string residence_Town { get; set; }
        public string residence_lga { get; set; }
        public string residence_postalcode { get; set; }
        public string residence_state { get; set; }
        public string residencestatus { get; set; }
        public string self_origin_lga { get; set; }
        public string self_origin_place { get; set; }
        public string self_origin_state { get; set; }
        public string signature { get; set; }
        public string surname { get; set; }
        public string telephoneno { get; set; }
        public string title { get; set; }
        public string trackingId { get; set; }
    }
}