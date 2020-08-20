using DatabaseLayer.Extensions;
using DomainLayer;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DatabaseLayer.Repositories
{
    public class StudentsRepository : Repository<StudentModel>
    {
        private DbContext _context;
        public StudentsRepository(DbContext context) : base(context)
        {
            this._context = context;
        }

        public IList<StudentModel> GetStudentUsers()
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "select StdCode, CollegeCode, UserName, Email, DOB, Address, ContactNo, Image from tbl_Student_T with(nolock) where IsActive = 1";
                return this.ToList(command).ToList();
            }
        }

        public StudentModel ValidateLogin(string clgCode, string userid, string password)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "USP_STUDENT_VALIDATE";

                command.Parameters.Add(command.CreateParameter("@USERID", userid));
                command.Parameters.Add(command.CreateParameter("@PASSWORD", password));
                command.Parameters.Add(command.CreateParameter("@CLGCODE", clgCode));

                return this.ToList(command).FirstOrDefault();
            }
        }

        public StudentModel RegisterStudent(StudentModel student)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "USP_STUDENT_REGISTRATION";

                command.Parameters.Add(command.CreateParameter("@CollegeCode", student.CollegeCode));
                command.Parameters.Add(command.CreateParameter("@UserName", student.UserName));
                command.Parameters.Add(command.CreateParameter("@Password", student.Password));
                command.Parameters.Add(command.CreateParameter("@Email", student.Email));
                command.Parameters.Add(command.CreateParameter("@Address", student.Address));
                command.Parameters.Add(command.CreateParameter("@DOB", student.DOB));
                command.Parameters.Add(command.CreateParameter("@ContactNo", student.ContactNo));
                command.Parameters.Add(command.CreateParameter("@Image", student.Image));

                return this.ToList(command).FirstOrDefault();
            }
        }
    }
}
