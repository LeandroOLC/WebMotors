using System.Threading.Tasks;

namespace WM.WebAPI.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}