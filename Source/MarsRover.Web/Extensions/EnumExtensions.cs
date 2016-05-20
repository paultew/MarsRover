using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace MarsRover.Web.Extensions
{
    public static class EnumExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectList(this Enum value)
        {
            var type = value.GetType();
            foreach (var enumName in Enum.GetNames(type))
            {
                var enumValue = Enum.Parse(type, enumName, true);
                var idValue = ((int) enumValue).ToString(CultureInfo.CurrentUICulture);
                var displayValue = enumName;

                // get the corresponding enum field using reflection
                var field = type.GetField(enumName);
                var display =
                    ((DisplayAttribute[]) field.GetCustomAttributes(typeof(DisplayAttribute), false)).FirstOrDefault();
                if (display != null)
                {
                    // The enum field is decorated with the DisplayAttribute =>
                    // use its value
                    displayValue = display.Name;
                }

                var description =
                    ((DescriptionAttribute[]) field.GetCustomAttributes(typeof(DescriptionAttribute), false))
                        .FirstOrDefault();
                if (description != null && !string.IsNullOrEmpty(description.Description))
                {
                    // The enum field is decorated with the DescriptionAttribute =>
                    // use its value
                    displayValue = description.Description;
                }

                yield return
                    new SelectListItem() {Value = idValue, Text = displayValue, Selected = (Equals(enumValue, value))};
            }
        }
    }
}
