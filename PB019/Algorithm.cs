using System;

namespace ProjectEuler
{
    public class Algorithm : IProblem
    {
        public string compute()
        {
            int cnt = 0;
            for (int year = 1901; year <= 2000; year++)
                for (int month = 1; month <= 12; month++)
                    if (new DateTime(year, month, 1).DayOfWeek == DayOfWeek.Sunday)
                        cnt++;
            return cnt.ToString(); 
        }

        public bool prepare()
        {
            return true;
        }
    }
}
