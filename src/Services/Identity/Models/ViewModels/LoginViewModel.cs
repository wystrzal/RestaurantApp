﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models.ViewModels
{
    public class LoginViewModel : LoginDto
    {
        public bool EnableLocalLogin { get; set; }
    }
}