
namespace BigonApp.Helpers.Services
{
    public class DatetimeService : IDatetimeService
    {
        public DateTime ExecutingTime { get => DateTime.Now; }
    }
}
