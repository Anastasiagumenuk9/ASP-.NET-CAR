using MODELS.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Interfaces
{
    public interface ICarManager
    {
       // CarViewModel Get(int id);
     
        IEnumerable<CarViewModel> GetCars(int page, int countOnPage, string searchValue);//paging

        IEnumerable<CarViewModel> GetCarsWithColor(int color); //filter with color

        IEnumerable<CarViewModel> GetCarsWithtransmission(int trans); //filter with transmission

        CarViewModel GetById(int id);


        IEnumerable<CarViewModel> GetCars();

        void Insert(CarViewModel item);

        void Update(CarViewModel item);

        void Delete(int id);
    }
}
