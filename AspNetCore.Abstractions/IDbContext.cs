﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Abstractions
{
    public interface IDbContext<T>: ICrud<T>
    {

    }
}
