﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Financial_Calculator
{
    interface IFormula
    {
        public void InputValues(string text);
        public decimal Result();
    }
}
