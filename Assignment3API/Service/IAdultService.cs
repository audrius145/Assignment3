using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment3API.Model;

namespace Assignment3API.Service
{
    public interface IAdultService
    {
        Task<IList<Adult>> getAdultsAsync();
        Task<Adult> AddAdultAsync(Adult adult);
        Task RemoveAdultAsync(int adultID);
        
        
        
    }
}