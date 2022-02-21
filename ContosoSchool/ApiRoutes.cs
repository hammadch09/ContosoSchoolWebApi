namespace ContosoSchool
{
    public class ApiRoutes
    {
        public const string VersioningBaseRoute = "api/v{version:ApiVersion}/[controller]";
        public const string BaseRoute = "api/[controller]";

        public class Student
        {
            public const string IdRoute = "{id}";
            public const string GetAllRoute = "getAll";
            public const string UpdateRoute = "update/{id}";
            public const string CreateRoute = "create";
            public const string DeleteRoute = "delete/{id}";
        }
    }
}
