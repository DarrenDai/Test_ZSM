﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace DDSoft.Common.Validations
{
    public class NotNullValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty(value as string) || string.IsNullOrWhiteSpace(value as string))
            {
                return new ValidationResult(false, "不能为空！");
            }

            return new ValidationResult(true, null);
        }
    }
}
