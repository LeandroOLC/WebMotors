using System.Collections.Generic;
using System.Threading.Tasks;
using WM.Vitrine.API.Models;

namespace WM.Vitrine.API.Services
{
    public interface ICarsService
    {
        Task<List<Make>> GetMake();
        Task<List<Model>> GetModels(int id);
        Task<List<Vehicle>> GetVehicles(int page);
        Task<List<Versions>> GetVersion(int id);
    }
}