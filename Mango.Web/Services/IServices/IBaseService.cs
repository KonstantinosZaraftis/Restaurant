using Mango.Web.Models;

namespace Mango.Web.Services.IServices
{
    public interface IBaseService: IDisposable 
    {
        Task<T> SendAsync<T>(ApiRequest apiRequest);// the method to send API request

    }
}
