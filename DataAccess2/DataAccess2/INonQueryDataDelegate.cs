﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess2
{
    public interface INonQueryDataDelegate<out T> : IDataDelegate
    {
        T Translate(Command command);
    }
}
