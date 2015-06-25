using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Lalosoft.Controls.DateTimePicker
{
    public class LalosTimeIncrement
    {
       private int _increment;
        public static int defaultTimeIncrement = 1;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="increment">Increment value, Default is set to 1</param>
        public LalosTimeIncrement(LalosIncrementValues increment)
        {
          _increment = (int)increment;

          if (_increment <= 0)
            _increment = defaultTimeIncrement;
           // this._increment = increment;
        }

        public LalosTimeIncrement(int increment)
        {
          _increment = (int)increment;

          if (_increment <= 0)
            _increment = defaultTimeIncrement;
          // this._increment = increment;
        }

        public LalosIncrementValues IncrementBy
        {
          get { return (LalosIncrementValues)_increment; }
          set
          {
            _increment = (int)value;

            if (_increment <= 0)
              _increment = defaultTimeIncrement;
          }
        }
        /// <summary>
        /// returns the value +- increment
        /// </summary>
        /// <param name="NewTime"></param>
        /// <param name="OldTime"></param>
        /// <returns></returns>
        public DateTime IncrementTime(DateTime NewTime,  ref DateTime OldTime)
        {
            // if the increment is 1, we just return the new time
            if (_increment == 1)
                return NewTime;


            // The case where we do this by hand
            if (NewTime.Minute % _increment == 0)
                return NewTime;

            if (OldTime == DateTime.MinValue)
            {
                return DateTimeNowRound(NewTime);
            }


            // if the new time is equal to the old time, just return the old time
            if (NewTime.Minute == OldTime.Minute)
                return OldTime;


            // if the time is 59
            else if (NewTime.Minute == 59)
            {   
                OldTime = new DateTime(NewTime.Year, NewTime.Month, NewTime.Day, NewTime.Hour, 60 - _increment, 0);
                return OldTime;
            }
            // Time is going up
            else if (NewTime.Minute > OldTime.Minute)
            {
                if (OldTime.Minute + _increment == 60)
                {
                    OldTime = new DateTime(NewTime.Year, NewTime.Month, NewTime.Day, NewTime.Hour, 0, 0);
                     return  OldTime;
                }
                else
                {
                    OldTime = new DateTime(NewTime.Year, NewTime.Month, NewTime.Day, NewTime.Hour, OldTime.Minute + _increment, 0);
                    return OldTime;
                }
            }
            // Time is going down
            else if (NewTime.Minute < OldTime.Minute)
            {
                if (OldTime.Minute - _increment == 0)
                {
                    OldTime = new DateTime(NewTime.Year, NewTime.Month, NewTime.Day, NewTime.Hour, 0, 0);
                    return OldTime;
                }
                else
                {
                    int newMin = OldTime.Minute - _increment;
                    if (newMin < 0) newMin = 0;
                    OldTime = new DateTime(NewTime.Year, NewTime.Month, NewTime.Day, NewTime.Hour, newMin, 0);
                    return OldTime;
                }
            }

            return OldTime;
        }
        /// <summary>
        /// This method will round a DateTime to the nearest value based on the classes increment value. 
        /// Example: Increment value = 10; 
        ///     12:36:12 = 12:40:00
        ///     1:59:36 = 2:00:00
        ///     3:02:59 = 3:00:00
        /// </summary>
        /// <param name="now"></param>
        /// <returns></returns>
        public DateTime DateTimeNowRound(DateTime now)
        {
            decimal min, max;
            decimal increment = decimal.Parse(_increment.ToString());
            decimal divideByTwo = (decimal)2.0;
            //The currentMinute should be between the min and the max
            decimal currentMinute = decimal.Parse(now.Minute.ToString());

            min = 0;

            while (true)
            {
                if (min == currentMinute)
                    return new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0, 0);

                if (min < currentMinute)
                    min += increment;
                else
                {
                    max = min;
                    min = min - increment;
                    break;
                }
            }

            decimal midpoint = increment / divideByTwo;
            // if max is equal to 60, the min will equal to whatever  max - increment
            if (max == 60)
            {
                if (currentMinute < min + midpoint)
                {
                    return new DateTime(now.Year, now.Month, now.Day, now.Hour, int.Parse(min.ToString()), 0, 0);
                }
                else
                {
                    now = now.AddHours(1.0);
                    return new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0, 0);
                }
            }     
            

            if (currentMinute < min + midpoint)
            {
                return  new DateTime(now.Year, now.Month, now.Day, now.Hour, int.Parse(min.ToString()), 0, 0);
            }
            else
                return new DateTime(now.Year, now.Month, now.Day, now.Hour, int.Parse(max.ToString()), 0, 0);

        }
        


    }
}
