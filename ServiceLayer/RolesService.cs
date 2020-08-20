using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer;
using DatabaseLayer.Repositories;
using DomainLayer;
using ServiceLayer.Interfaces;

namespace ServiceLayer
{
    public class RolesService : IRolesService
    {
        #region objecct Declaraction
        private readonly IConnectionFactory connectionFactory;
        readonly DbContext context;
        RolesRepository rolesRepo;
        #endregion

        private RolesService()
        {
            connectionFactory = ConnectionHelper.GetConnection();
            context = new DbContext(connectionFactory);
            rolesRepo = new RolesRepository(context);
        }

        private static readonly Lazy<RolesService> instance = new Lazy<RolesService>(() => new RolesService());

        public static RolesService GetInstance
        {
            get
            {
                return instance.Value;
            }
        }

        public IList<RolesModel> GetRoles()
        {
            return rolesRepo.GetRoles();
        }
    }
}
