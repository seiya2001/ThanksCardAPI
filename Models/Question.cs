﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThanksCardAPI.Models
{
    public class Question
    {
        public long Id { get; set; }
        public string Mondai { get; set; }
        public string Answer { get; set; }
    }
}
