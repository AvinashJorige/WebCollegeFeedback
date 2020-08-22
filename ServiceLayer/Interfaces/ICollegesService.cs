using System.Collections.Generic;
using DomainLayer;

namespace ServiceLayer.Interfaces
{
    public interface ICollegesService
    {
        IList<CollegesModel> GetCollegesList();

        object SaveCollegeDetails(CollegesModel colleges);
        object UpdateCollegeDetails(CollegesModel colleges);
        object DeleteCollegeDetails(string CollegeId);
    }
}
