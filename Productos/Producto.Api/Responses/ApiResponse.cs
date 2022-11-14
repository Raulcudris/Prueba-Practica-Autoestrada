﻿using Producto.Core.CustomEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Producto.Api.Responses
{
    public class ApiResponse<T>
    {
      
            public ApiResponse(T data)
            {
                Data = data;
            }

            public T Data { get; set; }

            public Metadata Meta { get; set; }
   
    }
}
