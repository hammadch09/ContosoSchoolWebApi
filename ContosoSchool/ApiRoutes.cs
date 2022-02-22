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
        public class Auth
        {
            public const string Register = "register";
            public const string Login = "login";
        }
        public class Character
        {
            public const string AddWeapon = "AddWeapon";
            public const string AddCharacterSkill = "AddCharacterSkill";
            public const string AddCharacter = "AddCharacter";
            public const string GetCharacter = "Get";
        }
        public class Classroom
        {
            public const string GetById = "id";
            public const string GetAll = "Get";
            public const string AddClassroom = "AddClassroom";
        }
        public class School
        {
            public const string IdRoute = "{id}";
            public const string Update = "Update/id";
        }
        public class Teacher
        {
            public const string GetPaginatedRoute = "paginate/id";
            public const string UpdateRoute = "update/id";
            public const string AddRoute = "create";
            public const string DeleteRoute = "delete/id";
        }
    }
}
