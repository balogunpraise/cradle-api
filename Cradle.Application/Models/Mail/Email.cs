﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cradle.Application.Models.Mail
{
    public class Email
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Body { get; set; }
    }
}
