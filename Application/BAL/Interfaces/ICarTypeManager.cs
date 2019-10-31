using MODELS.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Interfaces
{
    public interface ICarTypeManager
    {
        IEnumerable<CarTypeViewModel> GetCarTypes();

        CarTypeViewModel GetById(int id); 



        void Insert(CarTypeViewModel item);  

        void Update(CarTypeViewModel item); 

        void Delete(int id); 
    }
}
