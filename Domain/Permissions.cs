﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums;

namespace Domain
{
    public class Permissions
    {
        public string Name { get; set; }
        public EnSecurityPermissionState PermissionState { get; set; }
    }
}
