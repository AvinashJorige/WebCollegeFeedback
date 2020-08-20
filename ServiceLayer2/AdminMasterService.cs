using DataLayer;
using DataLayer.Repositories;
using DomainLayer;
using Utility;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;

namespace ServiceLayer
{
    // creating the singleton design pattern with lazy load
    public sealed class AdminMasterService : IAdminService
    {
        #region objecct Declaraction
        private readonly IConnectionFactory connectionFactory;
        readonly DbContext context;
        AdminRepository adminRepo; 
        #endregion

        private AdminMasterService()
        {
            connectionFactory = ConnectionHelper.GetConnection();
            context = new DbContext(connectionFactory);
            adminRepo = new AdminRepository(context);
        }

        private static readonly Lazy<AdminMasterService> instance = new Lazy<AdminMasterService>(() => new AdminMasterService());

        public static AdminMasterService GetInstance
        {
            get
            {
                return instance.Value;
            }
        }


        public IList<AdminModel> GetAdminUsers()
        {
            return adminRepo.GetUsers();
        }

        /// <summary>
        /// Validating the admin login
        /// </summary>
        /// <param name="userid">admin login id</param>
        /// <param name="password">admin password(encryption is done at service level)</param>
        /// <returns>return object of the valid admin else return null</returns>
        public AdminModel ValidateUser(string userid, string password)
        {
            if (string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            password = EncryptDecryptAES.Encrypt(password);

            return adminRepo.ValidateLogin(userid, password);
        }
    }
}
