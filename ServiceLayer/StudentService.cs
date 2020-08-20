using DatabaseLayer;
using DatabaseLayer.Repositories;
using DomainLayer;
using ServiceLayer.Interfaces;
using System.Collections.Generic;
using Utility;

namespace ServiceLayer
{
    public class StudentService : IStudentService
    {
        #region objecct Declaraction
        private readonly IConnectionFactory connectionFactory;
        readonly DbContext context;
        StudentsRepository studentsRepository;
        #endregion

        public StudentService()
        {
            connectionFactory = ConnectionHelper.GetConnection();
            context = new DbContext(connectionFactory);
            studentsRepository = new StudentsRepository(context);
        }

        public IList<StudentModel> GetStudentUsers()
        {
            return studentsRepository.GetStudentUsers();
        }

        /// <summary>
        /// Validating the student login
        /// </summary>
        /// <param name="userid">student login id</param>
        /// <param name="password">student password(encryption is done at service level)</param>
        /// <returns>return object of the valid student else return null</returns>
        public StudentModel ValidateUser(string clgCode, string userid, string password)
        {
            if (string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(clgCode))
            {
                return null;
            }

            password = EncryptDecryptAES.Encrypt(password);

            return studentsRepository.ValidateLogin(clgCode, userid, password);
        }
    }
}
