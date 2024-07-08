﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Player
    {
        public int PlayerId { get; set; }

        public string PlayerName { get; set; }

        public string Role { get; set; }

        public int Runs { get; set; }

        public int Wickets { get; set; }
    }
}