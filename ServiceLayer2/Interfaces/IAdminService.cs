using DomainLayer;
using System.Collections.Generic;

namespace ServiceLayer.Interfaces
{
    public interface IAdminService
    {
        IList<AdminModel> GetAdminUsers();

        /// <summary>
        /// Validating the admin login
        /// </summary>
        /// <param name="userid">admin login id</param>
        /// <param name="password">admin password(encryption is done at service level)</param>
        /// <returns>return object of the valid admin else return null</returns>
        AdminModel ValidateUser(string userid, string password);
    }
}
