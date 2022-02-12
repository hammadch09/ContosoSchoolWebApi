namespace ContosoSchool
{
    public class ApiRoutes
    {
        public const string BaseRoute = "api/v{version:ApiVersion}/[controller]";

        public class Student
        {
            public const string IdRoute = "{id}";
        }
    }
}
