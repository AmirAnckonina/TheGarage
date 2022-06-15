using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public static class EnumValidator
    {
        public static bool EnumRangeValidation(int i_MinValue, int i_MaxValue, int i_InsertedValue)
        {
            bool inRange;

            if (i_InsertedValue >= i_MinValue && i_InsertedValue <= i_MaxValue)
            {
                inRange = true;
            }

            else
            {
                inRange = false;
            }

            return inRange;
        }
    }
}
