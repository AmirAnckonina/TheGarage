using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public static class Parser
    {
        public static bool EnumRangeValidation(int i_MinValue, int i_MaxValue, int i_ColorChoice)
        {
            bool inRange;

            if (i_ColorChoice >= i_MinValue && i_ColorChoice <= i_MaxValue)
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
