using DataLayer.Extensions;
using DomainLayer;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DataLayer.Repositories
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
    }
}
