﻿using Microsoft.AspNetCore.Mvc;
using static Mango.Web.SD;

namespace Mango.Web.Models
{
    public class ApiRequest
    {

        public ApiType ApiType { get; set; } = ApiType.GET;
        public string ApiUri { get; set; }
        public Object Data { get; set; }
    }
}
