namespace DaysOfWeekServices
{
    using System;

    public class DaysOfWeekService : IDaysOfWeekService
    {
        public string GetDayOfWeek(DateTime inputDate)
        {
            var dayOfWeek = inputDate.DayOfWeek;
            var result = "";

            switch (dayOfWeek)
            {
                case DayOfWeek.Friday:
                    result = "Петък";
                    break;
                case DayOfWeek.Monday:
                    result = "Понделеник";
                    break;
                case DayOfWeek.Saturday:
                    result = "Събота";
                    break;
                case DayOfWeek.Sunday:
                    result = "Неделя";
                    break;
                case DayOfWeek.Thursday:
                    result = "Четвъртък";
                    break;
                case DayOfWeek.Tuesday:
                    result = "Вторник";
                    break;
                case DayOfWeek.Wednesday:
                    result = "Сряда";
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
