using MODELS.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Interfaces
{
    public interface ICityManager
    {
        CityViewModel GetById(int id);


        IEnumerable<CityViewModel> GetCities();

        void Insert(CityViewModel item);

        void Update(CityViewModel item);

        void Delete(int id);
    }
}
