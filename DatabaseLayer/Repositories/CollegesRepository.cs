using DatabaseLayer.Extensions;
using DomainLayer;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DatabaseLayer.Repositories
{
    public class CollegesRepository : Repository<CollegesModel>
    {
        private DbContext _context;
        public CollegesRepository(DbContext context) : base(context)
        {
            this._context = context;
        }

        public IList<CollegesModel> GetCollegesList()
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "select CollgId, CollegeName, Link, Address, Image, AboutCollege from tbl_Colleges_T with(nolock) where IsActive = 1";
                return this.ToList(command).ToList();
            }
        }

    }
}
