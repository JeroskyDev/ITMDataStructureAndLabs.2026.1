using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public class DateUtilities
    {
        public static bool IsLeapYear(int year)
        {
            //if it´s a multiple of 4 then look if it´s multiple of a 100 and if it is, then it isnt a leap year
            if (year % 4 == 0)
            {
                //with just multiple of 4 it could probably be a leap year
                //if it´s a multiple of 4 and of 100 then it isnt a leap year
                if (year % 100 == 0)
                {
                    //if it is a multiple of 400, then it checks all the conditions and the year is definetely a leap year.
                    if (year % 400 == 0)
                    {
                        return true;
                    }
                    return false;  
                }
                return true;
            }
            return false;
        }
    }
}
