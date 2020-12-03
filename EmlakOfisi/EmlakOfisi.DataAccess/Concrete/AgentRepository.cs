using EmlakOfisi.DataAccess.Abstract;
using EmlakOfisi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EmlakOfisi.DataAccess.Concrete
{
    public class AgentRepository : IAgentRepository
    {
        public Agent CreateAgent(Agent agent)
        {
            using (var emlakOfiDbContext = new EmlakOfisiDbContext())
            {

                emlakOfiDbContext.Agents.Add(agent);
                emlakOfiDbContext.SaveChanges();
                return agent;
            }
        }

        public void DeleteAgent(int id)
        {
            using (var emlakOfiDbContext = new EmlakOfisiDbContext())
            {
                var deleted = GetAgentById(id);
                emlakOfiDbContext.Agents.Remove(deleted);
                emlakOfiDbContext.SaveChanges();

            }
        }

        public List<Advertisement> GetAdvertisementsList(Expression<Func<Advertisement, bool>> expression)
        {
            using (var emlakOfiDbContext = new EmlakOfisiDbContext())
            {
                return emlakOfiDbContext.Advertisements.Where(expression).ToList();
            }
        }

        public Agent GetAgentById(int id)
        {
            using (var emlakOfiDbContext = new EmlakOfisiDbContext())
            {
                return emlakOfiDbContext.Agents.Find(id);
            }
        }

        public List<Agent> GetAgents()
        {
            using (var emlakOfiDbContext = new EmlakOfisiDbContext())
            {
                return emlakOfiDbContext.Agents.ToList();
            }
        }

        public Agent UpdateAgent(Agent agent)
        {
            using (var emlakOfiDbContext = new EmlakOfisiDbContext())
            {
                emlakOfiDbContext.Agents.Update(agent);
                emlakOfiDbContext.SaveChanges();
                return agent;
            }
        }
    }
}
