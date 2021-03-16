﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Services.Communication
{
    public abstract class BaseResponse
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public BaseResponse(bool success, string message)
        {
            this.Success = success;
            this.Message = message;
        }
    }
}
