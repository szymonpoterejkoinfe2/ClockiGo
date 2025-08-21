using ErrorOr;

namespace ClockiGo.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Organization
        {
            public static Error DuplicateEmail => Error.Conflict(code: "Organization.DuplicateEmail", description: "Organization with given email already exists");
            public static Error OrganizationNotFound => Error.Conflict(code: "Organization.OrganizationNotFound", description: "Organization was not found! ");
        }
    }
}
