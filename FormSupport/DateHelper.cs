using System;

namespace FormSupport
{
    public static class DateHelper
    {
        public static bool GetOfferStatusByCurrentDate(DateTime startDate, DateTime endDate)
        {
            DateTime currentDate = DateTime.Now;

            if (currentDate >= startDate && currentDate <= endDate)
                return true;

            return false;
        }
    }
}
