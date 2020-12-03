using EmlakOfisi.DataAccess.Abstract;
using EmlakOfisi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EmlakOfisi.DataAccess.Concrete
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        public Advertisement CreateAdvertisement(Advertisement advertisement)
        {
            using (var emlakOfiDbContext = new EmlakOfisiDbContext())
            {

                emlakOfiDbContext.Advertisements.Add(advertisement);
                emlakOfiDbContext.SaveChanges();
                return advertisement;
            }
        }

        public void DeleteAdvertisement(int id)
        {
            using (var emlakOfisDbContext = new EmlakOfisiDbContext())
            {
                var deleted = GetAdvertisementByExpression(x=>x.Id ==id);
                emlakOfisDbContext.Advertisements.Remove(deleted);
                emlakOfisDbContext.SaveChanges();
            }
        }

        public Advertisement GetAdvertisementByExpression(Expression<Func<Advertisement, bool>> expression)
        {
            using (var emlakOfisDbContext = new EmlakOfisiDbContext())
            {
                return emlakOfisDbContext.Advertisements.Where(expression).FirstOrDefault();
            }
        }


        public List<Advertisement> GetAdvertisements()
        {
            using (var emlakOfisDbContext = new EmlakOfisiDbContext())
            {
                return emlakOfisDbContext.Advertisements.ToList();
            }
        }

        public Advertisement UpdateAdvertisement(Advertisement advertisement)
        {
            using (var emlakOfiDbContext = new EmlakOfisiDbContext())
            {
                emlakOfiDbContext.Advertisements.Update(advertisement);
                emlakOfiDbContext.SaveChanges();
                return advertisement;
            }
        }
    }
}
