﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm.Core.Model
{
    public class SearchCustomerOptions
    {
        public int? Id { get; set; }
        public decimal VatNumber { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
