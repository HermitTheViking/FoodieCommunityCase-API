using System;

namespace FoodieCommunityCase.Domain.Time
{
    public interface ITimeService
    {
        DateTime Now { get; }
        DateTime Today { get; }
        DateTime UtcNow { get; }
    }
}
