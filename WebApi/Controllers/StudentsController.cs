using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.DBModels;
using WebApi.RequestModel;
using WebApi.ResponseModel;

namespace WebApi.Controllers
{
    /// <summary>
    /// Implementing WebAPI using on DB 
    /// </summary>
    [ApiController]
    [Route("students/api")]
    public class StudentsController : ControllerBase
    {
        private readonly WebapiContext context;

        /// <summary>
        /// DB context object for Request and Response
        /// </summary>
        /// <param name="context"></param>
        public StudentsController(WebapiContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get all students  
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<StudentDTO>> GetAllStudents()
        {
            List<StudentDTO> students = await context.Students.Select(s => new StudentDTO()
            {
                Id = s.Id,
                Studentname = s.Studentname,
                Mobilenumber = s.Mobilenumber,
                Companyname = s.Companyname
            }).ToListAsync();

            return students;
        }

        /// <summary>
        /// Create students details
        /// </summary>
        /// <param name="studentCreateRequest"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<StudentDTO> CreateStudent(StudentCreateRequest studentCreateRequest)
        {
            Student student = new Student()
            {
                Studentname = studentCreateRequest.Studentname,
                Mobilenumber = studentCreateRequest.Mobilenumber,
                Companyname = studentCreateRequest.Companyname
            };
            context.Students.Add(student);
            await context.SaveChangesAsync();

            StudentDTO studentDTO = new StudentDTO()
            {
                Id = student.Id,
                Studentname = student.Studentname,
                Mobilenumber = student.Mobilenumber,
                Companyname = student.Companyname
            };

            return studentDTO;

        }

        /// <summary>
        /// Student Update details
        /// </summary>
        /// <param name="studentDTO"></param>
        /// <returns></returns>
        [HttpPut("update/{ID}")]
        public async Task<StudentDTO> StudentUpdateRequest(int ID, StudentDTO studentDTO)
        {
            var existingStudent = context.Students.Where(i => i.Id == studentDTO.Id).FirstOrDefault<Student>();
            
            if (existingStudent != null)
            {
                existingStudent.Studentname = studentDTO.Studentname;
                existingStudent.Mobilenumber = studentDTO.Mobilenumber;
                existingStudent.Companyname = studentDTO.Companyname;
                
                await context.SaveChangesAsync();
            }
            else
            {
                return studentDTO;
            }
            return studentDTO;
        }


        /// <summary>
        /// Student delete details
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpDelete("delete")]

        public async Task<string> RemoveStudentDetails(int ID)
        {
            var student = await context.Students.FindAsync(ID);

            if (student == null)
                return "Student NOT Found.";

            context.Students.Remove(student);
            await context.SaveChangesAsync();

            return "Student Details Removed.";
        }


    }
}
