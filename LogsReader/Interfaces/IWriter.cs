﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsReader.Interfaces
{
   public interface IWriter
    {
        void Write(string message);
    }
}
