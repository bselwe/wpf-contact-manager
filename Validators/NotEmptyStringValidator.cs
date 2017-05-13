﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Contact_Manager.Validators
{
    public class NotEmptyStringValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!String.IsNullOrEmpty(value.ToString()))
                return new ValidationResult(true, null);

            return new ValidationResult(false, "Length too short");
        }
    }
}
