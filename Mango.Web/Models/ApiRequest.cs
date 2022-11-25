using Microsoft.AspNetCore.Mvc;
using static Mango.Web.SD;

namespace Mango.Web.Models
{
    public class ApiRequest
    {
        //Model that hold API request
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string ApiUrl { get; set; }//Url to send API
        public object Data { get; set; }
        public string AccessToken { get; set; }// we used them when we have authedication
    }
}
