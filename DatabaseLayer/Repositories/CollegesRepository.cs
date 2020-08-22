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

        public object SaveCollegeDetails(CollegesModel colleges)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_College_SaveDetails";

                command.Parameters.Add(command.CreateParameter("@name",     colleges.CollegeName));
                command.Parameters.Add(command.CreateParameter("@link",     colleges.Link));
                command.Parameters.Add(command.CreateParameter("@address",  colleges.Address));
                command.Parameters.Add(command.CreateParameter("@image",    colleges.Image));
                command.Parameters.Add(command.CreateParameter("@about",    colleges.AboutCollege));

                // return this.ToList(command).FirstOrDefault();
                return this.ToList(command).SingleOrDefault();
            }
        }

        public object UpdateCollegeDetails(CollegesModel colleges)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_College_UpdateDetails";

                command.Parameters.Add(command.CreateParameter("@clgId", colleges.CollgId));
                command.Parameters.Add(command.CreateParameter("@name", colleges.CollegeName));
                command.Parameters.Add(command.CreateParameter("@link", colleges.Link));
                command.Parameters.Add(command.CreateParameter("@address", colleges.Address));
                command.Parameters.Add(command.CreateParameter("@image", colleges.Image));
                command.Parameters.Add(command.CreateParameter("@about", colleges.AboutCollege));

                // return this.ToList(command).FirstOrDefault();
                return this.ToList(command).SingleOrDefault();
            }
        }

        public object DeleteCollegeDetails(string CollegeId)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_College_DeActivateDetails";

                command.Parameters.Add(command.CreateParameter("@clgId", CollegeId));

                // return this.ToList(command).FirstOrDefault();
                return this.ToList(command).SingleOrDefault();
            }
        }
    }
}
