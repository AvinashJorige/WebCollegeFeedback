using DomainLayer;
using System.Collections.Generic;

namespace ServiceLayer.Interfaces
{
    public interface IStudentService
    {
        IList<StudentModel> GetStudentUsers();

        /// <summary>
        /// Validating the student login
        /// </summary>
        /// <param name="userid">student login id</param>
        /// <param name="password">student password(encryption is done at service level)</param>
        /// <returns>return object of the valid student else return null</returns>
        StudentModel ValidateUser(string clgCode, string userid, string password);

        /// <summary>
        /// Registing the new students
        /// </summary>
        /// <param name="student">parameter of the student object</param>
        /// <returns>Returns true if saved to db is success</returns>
        bool RegisterStudent(StudentModel student);
    }
}
