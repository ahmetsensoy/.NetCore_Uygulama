using EmlakOfisi.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EmlakOfisi.Business.Abstract
{
    public interface IAdvertisementService
    {
        Advertisement GetAdvertisementByExpression(Expression<Func<Advertisement,bool>> expression);
        List<Advertisement> GetAdvertisements();
        Advertisement CreateAdvertisement(Advertisement advertisement);
        Advertisement UpdateAdvertisement(Advertisement advertisement);
        void DeleteAdvertisement(int id);
    }
}
