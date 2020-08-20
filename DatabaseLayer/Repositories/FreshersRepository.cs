using DatabaseLayer.Extensions;
using DomainLayer;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DatabaseLayer.Repositories
{
    public class FreshersRepository : Repository<FreshersModel>
    {
        private DbContext _context;
        public FreshersRepository(DbContext context) : base(context)
        {
            this._context = context;
        }


        public IList<FreshersModel> GetUsers()
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "select FRSHCODE, CollegeCode, UserName, Email, DOB, Address, ContactNo, Image from TBL_FRESHERS_T with(nolock) where IsActive = 1";
                return this.ToList(command).ToList();
            }
        }


        public FreshersModel ValidateLogin(string userid, string password)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "USP_FRESHER_VALIDATE";

                command.Parameters.Add(command.CreateParameter("@USERID", userid));
                command.Parameters.Add(command.CreateParameter("@PASSWORD", password));

                return this.ToList(command).FirstOrDefault();
            }
        }
    }
}
