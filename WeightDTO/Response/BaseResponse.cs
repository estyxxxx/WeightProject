﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightCORE.Response
{
    public class BaseResponse
    {
        public bool Succeed { get; set; }
        public string Status { get; set; }
        public BaseResponse()
        {
            Succeed = true;
        }
    }
}
