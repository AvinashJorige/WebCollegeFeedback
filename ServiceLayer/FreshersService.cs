using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer;
using DatabaseLayer.Repositories;
using Utility;
using DomainLayer;
using ServiceLayer.Interfaces;

namespace ServiceLayer
{
    public class FreshersService : IFreshersService
    {
        #region objecct Declaraction
        private readonly IConnectionFactory connectionFactory;
        readonly DbContext context;
        FreshersRepository freshersRepository;
        #endregion

        public FreshersService()
        {
            connectionFactory   = ConnectionHelper.GetConnection();
            context             = new DbContext(connectionFactory);
            freshersRepository  = new FreshersRepository(context);
        }

        public IList<FreshersModel> GetFresherUsers()
        {
            return freshersRepository.GetUsers();
        }

        /// <summary>
        /// Validating the fresher login
        /// </summary>
        /// <param name="userid">fresher login id</param>
        /// <param name="password">fresher password(encryption is done at service level)</param>
        /// <returns>return object of the valid fresher else return null</returns>
        public FreshersModel ValidateUser(string userid, string password)
        {
            if (string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            password = EncryptDecryptAES.Encrypt(password);

            return freshersRepository.ValidateLogin(userid, password);
        }
    }
}
