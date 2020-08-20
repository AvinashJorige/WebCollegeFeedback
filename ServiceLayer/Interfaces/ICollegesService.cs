using System.Collections.Generic;
using DomainLayer;

namespace ServiceLayer.Interfaces
{
    public interface ICollegesService
    {
        IList<CollegesModel> GetCollegesList();
    }
}
