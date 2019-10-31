using MODELS.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Interfaces
{
    public interface ILocationManager
    {
        LocationViewModel GetById(int id);


        IEnumerable<LocationViewModel> GetLocations();

        void Insert(LocationViewModel item);

        void Update(LocationViewModel item);

        void Delete(int id);
    }
}
