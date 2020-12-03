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
    public class AdvertisementManager : IAdvertisementService
    {
        private IAdvertisementRepository _advertisementRepository;
        public AdvertisementManager(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }
        public Advertisement CreateAdvertisement(Advertisement advertisement)
        {
            return _advertisementRepository.CreateAdvertisement(advertisement);
        }

        public void DeleteAdvertisement(int id)
        {
            _advertisementRepository.DeleteAdvertisement(id);
        }

        public Advertisement GetAdvertisementByExpression(Expression<Func<Advertisement, bool>> expression)
        {
           return  _advertisementRepository.GetAdvertisementByExpression(expression);
        }

        public List<Advertisement> GetAdvertisements()
        {
            return _advertisementRepository.GetAdvertisements();
        }

        public Advertisement UpdateAdvertisement(Advertisement advertisement)
        {
            return _advertisementRepository.UpdateAdvertisement(advertisement);
        }
    }
}
