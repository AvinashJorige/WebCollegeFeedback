using DomainLayer;
using System.Collections.Generic;

namespace ServiceLayer.Interfaces
{
    public interface IFreshersService
    {
        IList<FreshersModel> GetFresherUsers();

        /// <summary>
        /// Validating the fresher login
        /// </summary>
        /// <param name="userid">fresher login id</param>
        /// <param name="password">fresher password(encryption is done at service level)</param>
        /// <returns>return object of the valid fresher else return null</returns>
        FreshersModel ValidateUser(string userid, string password);
    }
}
