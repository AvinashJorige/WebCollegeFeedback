using DatabaseLayer.Extensions;
using DomainLayer;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DatabaseLayer.Repositories
{
    public class RolesRepository: Repository<RolesModel>
    {
        private DbContext _context;
        public RolesRepository(DbContext context) : base(context)
        {
            this._context = context;
        }

        public IList<RolesModel> GetRoles()
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "select RoleId, RoleName from tbl_Roles_M with(nolock) where IsActive = 1";
                return this.ToList(command).ToList();
            }
        }
    }
}
