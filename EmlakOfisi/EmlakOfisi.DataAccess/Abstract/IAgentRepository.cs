using EmlakOfisi.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EmlakOfisi.DataAccess.Abstract
{
    public interface IAgentRepository
    {
        Agent GetAgentById(int id);
        List<Agent> GetAgents();
        Agent CreateAgent(Agent agent);
        Agent UpdateAgent(Agent agent);
        List<Advertisement> GetAdvertisementsList(Expression<Func<Advertisement,bool>> expression);
        void DeleteAgent(int id);
    }
}
