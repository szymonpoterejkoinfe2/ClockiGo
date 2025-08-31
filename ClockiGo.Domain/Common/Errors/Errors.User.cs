using ErrorOr;

namespace ClockiGo.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error DuplicateEmail => Error.Conflict(code: "User.DuplicateEmail", description: "Email duplicated");
            public static Error UserNotFound => Error.Conflict(code: "User.NotFound", description: "User was not found");
            public static Error WrongPassword => Error.Conflict(code: "User.WrongPassword", description: "Given password was incorrect");
            public static Error AccessDenied => Error.Conflict(code: "User.AccessDenied", description: "You do not have the required role to perform this operation.");

        }

    }
}
