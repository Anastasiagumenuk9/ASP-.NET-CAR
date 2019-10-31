using MODELS.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Interfaces
{
    public interface ILocationCarManager
    {
        LocationCarViewModel GetById(int id);


        IEnumerable<LocationCarViewModel> GetLocationCars();

        void Insert(LocationCarViewModel item);

        void Update(LocationCarViewModel item);

        void Delete(int id);
    }
}
