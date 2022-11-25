using Mango.Web.Models;

namespace Mango.Web.Services
{
    public class BaseService : IBaseService
    {
        

        public Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
