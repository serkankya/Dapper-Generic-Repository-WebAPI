using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Entities.Requests.UserRequest
{
    public record InsertUserRequest(string Username, string Password, string Email);
}
