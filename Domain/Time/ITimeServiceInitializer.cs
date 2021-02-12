namespace FoodieCommunityCase.Domain.Time
{
    public interface ITimeServiceInitializer
    {
        void SetTimeZone(string timeZoneId);
    }
}
