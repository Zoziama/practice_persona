using System.Threading.Tasks;
using practice.Common;

namespace practice.BusinessLogic.Interfaces
{
    public interface ISmsService
    {
        Task<SmsResponseModel> SendSms(string phoneno);
    }
}