﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Model
{
    public class UserSingleton
    {
        public static bool isAuth = false;
        public static UserModel User { get; set; }
    }
}
