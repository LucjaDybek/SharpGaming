using System;

namespace IFlow.Testing.Utils.DataFactory
{
    public static class UserConsts
    {
        public static int[] RandomDay()
        { 
            DateTime start = new DateTime(DateTime.Now.Year - 65, DateTime.Now.Month, DateTime.Now.Day);
            DateTime end = new DateTime(DateTime.Now.Year - 18, DateTime.Now.Month, DateTime.Now.Day);

            var randomDate = new Random();

            TimeSpan timeSpan = end - start;
            TimeSpan newSpan = new TimeSpan(0, randomDate.Next(0, (int)timeSpan.TotalMinutes), 0);
            DateTime newDate = start + newSpan;
    
            return new int[] { int.Parse(newDate.ToString("dd")), int.Parse(newDate.ToString("MM")), int.Parse(newDate.ToString("yyyy")) };
        }
    }
}
