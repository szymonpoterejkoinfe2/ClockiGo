using ErrorOr;

namespace ClockiGo.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Availability
        {
            public static Error AvailabilityNotFound =>  Error.Conflict(code: "Availability.AvailabilityNotFound", description: "Availability was not found!");
        }
    }
}
