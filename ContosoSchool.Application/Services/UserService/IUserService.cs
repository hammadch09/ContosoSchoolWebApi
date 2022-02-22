using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoSchool.Application.Services.UserService
{
    public interface IUserService
    {
        string GetMyName();
        string GetAnyName(string hammad);
    }
}
