using DomainLayer;
using System.Collections.Generic;

namespace ServiceLayer.Interfaces
{
    public interface IRolesService
    {
        IList<RolesModel> GetRoles();
    }
}
