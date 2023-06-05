﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.API.Domain.Core
{
    public abstract class BaseEntity<TId>         
    {
        public TId Id { get; set; }

       
    }
}
