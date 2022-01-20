using System.Threading.Tasks;
using practice.Common;

namespace practice.BusinessLogic.Interfaces
{
    public interface INinService
    {
        Task<NinResponseModel> GetNinData(string nin);
        bool isNinValid(PersonaViewModel PVM, NinResponseModel NRM);
    }
}