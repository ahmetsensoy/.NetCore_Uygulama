using EmlakOfisi.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EmlakOfisi.Business.Abstract
{
    public interface IAgentService
    {
        Agent GetAgentById(int id);
        List<Agent> GetAgents();
        Agent CreateAgent(Agent agent);
        Agent UpdateAgent(Agent agent);
        void DeleteAgent(int id);
        List<Advertisement> GetAdvertisementsList(Expression<Func<Advertisement, bool>> expression);
    }
}
