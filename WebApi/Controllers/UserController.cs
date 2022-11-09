using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("CRUD Operations")]
    public class UserController : Controller
    {
        /// <summary>
        /// This is to Fetch details
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpGet("Fetch User Details")]
        public User FetchUserDetails(User employee)
        {
            employee.userCurrentProject = "";
            return employee;
        }

        /// <summary>
        /// This is to add details
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost("Add User Details")]
        public User AddUserDetails(User employee)
        {
            employee.userName = "Nirav";
            employee.userDoJ = "June 16rd, 2000";
            employee.userId = 1405;
            employee.userCurrentProject = "None";

            return employee;
        }

        /// <summary>
        /// This is to update details
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut("Update User Details")]
        public User UpdateUserDetails(User employee)
        {
            employee.userName = "Nirav Patel";

            return employee;
        }

        /// <summary>
        /// This is to remove details
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpDelete("Remove User Details")]
        public User RemoveEmployeeDetails(User employee)
        {
            employee.userName = "Nirav";
            employee.userDoJ = "June 16rd, 2000";
            employee.userId = 1405;

            return employee;
        }
    }
}
