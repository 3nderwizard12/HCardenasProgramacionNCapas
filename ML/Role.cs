﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Role
    {
        public byte IdRole { get; set; }
        public string Name { get; set; }

        public List<object> Roles { get; set; }
    }
}