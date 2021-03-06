﻿using DataLayer;
using DataLayer.Repositories;
using DomainLayer;
using ServiceLayer.Interfaces;
using System.Collections.Generic;

namespace ServiceLayer
{
    public class CollegesService : ICollegesService
    {
        #region objecct Declaraction
        private readonly IConnectionFactory connectionFactory;
        readonly DbContext context;
        CollegesRepository collegesRepository;
        #endregion

        public CollegesService()
        {
            connectionFactory = ConnectionHelper.GetConnection();
            context = new DbContext(connectionFactory);
            collegesRepository = new CollegesRepository(context);
        }

        public IList<CollegesModel> GetCollegesList()
        {
            return collegesRepository.GetCollegesList();
        }
    }
}
