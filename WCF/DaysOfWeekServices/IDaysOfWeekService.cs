namespace DaysOfWeekServices
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IDaysOfWeekService
    {
        [OperationContract]
        string GetDayOfWeek(DateTime inputDate);
    }
}
