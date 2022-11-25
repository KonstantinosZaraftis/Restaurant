using Mango.Web.Models;

namespace Mango.Web.Services
{
    public interface IBaseService:IDisposable
    {
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
