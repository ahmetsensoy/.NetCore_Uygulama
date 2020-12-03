using EmlakOfisi.Business.Abstract;
using EmlakOfisi.DataAccess.Abstract;
using EmlakOfisi.DataAccess.Concrete;
using EmlakOfisi.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EmlakOfisi.Business.Concrete
{
    public class AgentManager : IAgentService
    {
        private IAgentRepository _agentRepository;
        public AgentManager()
        {
            _agentRepository = new AgentRepository();
        }
        public Agent CreateAgent(Agent agent)
        {
            return _agentRepository.CreateAgent(agent);
        }

        public void DeleteAgent(int id)
        {
            _agentRepository.DeleteAgent(id);
        }

        public List<Advertisement> GetAdvertisementsList(Expression<Func<Advertisement, bool>> expression)
        {
            return _agentRepository.GetAdvertisementsList(expression);
        }

        public Agent GetAgentById(int id)
        {
            if (id>0)
            {
                return _agentRepository.GetAgentById(id);
            }
            throw new Exception("Id can't be less than 0");
        }

        public List<Agent> GetAgents()
        {
            return _agentRepository.GetAgents();
        }

        public Agent UpdateAgent(Agent agent)
        {
            return _agentRepository.UpdateAgent(agent);
        }
    }
}
