using System;

namespace IFlow.Testing.Utils.DataFactory
{
    public static class UserConsts
    {
        public const string key = "68cb8daf20msh72afcd9c94f4186p1a4129jsn069149a72101";
        public const string header = "x-rapidapi-key";

        public static int[] RandomDay()
        { 
            DateTime start = new DateTime(DateTime.Now.Year - 65, DateTime.Now.Month, DateTime.Now.Day);
            DateTime end = new DateTime(DateTime.Now.Year - 18, DateTime.Now.Month, DateTime.Now.Day);

            var randomTest = new Random();

            TimeSpan timeSpan = end - start;
            TimeSpan newSpan = new TimeSpan(0, randomTest.Next(0, (int)timeSpan.TotalMinutes), 0);
            DateTime newDate = start + newSpan;

            var date = new int[] { int.Parse(newDate.ToString("dd")), int.Parse(newDate.ToString("MM")), int.Parse(newDate.ToString("yyyy")) };
    

            return date;
        }
    }
}
