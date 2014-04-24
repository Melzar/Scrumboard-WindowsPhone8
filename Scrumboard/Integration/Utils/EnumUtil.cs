using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Scrumboard.Integration.Utils
{
    public class EnumUtil
    {

        /// <summary>
        /// Method for getting enum description by reflection
        /// </summary>
        /// <param name="e"></param>
        public static string GetEnumDescription(Enum e)
        {
            if (e == null)
                return "";

            FieldInfo field = e.GetType().GetField(e.ToString());
            DescriptionAttribute description = field.GetCustomAttribute(typeof(DescriptionAttribute), false) as DescriptionAttribute;
            return description != null ? description.Description : "";
        }

    }
}
