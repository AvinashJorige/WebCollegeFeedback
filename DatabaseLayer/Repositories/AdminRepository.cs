using DatabaseLayer.Extensions;
using DomainLayer;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DatabaseLayer.Repositories
{
    public class AdminRepository : Repository<AdminModel>
    {
        private DbContext _context;
        public AdminRepository(DbContext context) : base(context)
        {
            this._context = context;
        }

        public IList<AdminModel> GetUsers()
        {
            using(var command = _context.CreateCommand())
            {
                command.CommandText = "select Name, UserId, Password from tbl_Admin_M with(nolock) where IsActive = 1";
                return this.ToList(command).ToList();
            }
        }


        public AdminModel ValidateLogin(string userid, string password)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "USP_ADMIN_VALIDATE";

                command.Parameters.Add(command.CreateParameter("@USERID", userid));
                command.Parameters.Add(command.CreateParameter("@PASSWORD", password));

                return this.ToList(command).FirstOrDefault();
            }
        }
    }
}
