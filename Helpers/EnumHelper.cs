using System;
using System.Collections.Generic;
using System.Linq;

namespace BudgetTracker.Helpers
{
    public static class EnumHelper
    {
        public static Array GetValues(Type enumType)
        {
            return Enum.GetValues(enumType);
        }
    }
}
