using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace WebApplication7.Data
{
    public interface IAdultService
    {
        Task<IList<Adult>> getAdultsAsync();
        Task AddAdultAsync(Adult adult);
        Task RemoveAdultAsync(int adultID);
        
        
        
    }
}