﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Controllers.Filters
{
    public class PagingModel
    {
        public int PageSize { get; set; }
        public int PageNo { get; set; }
    }
}