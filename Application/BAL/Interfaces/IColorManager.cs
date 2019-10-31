using MODELS.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Interfaces
{
    public interface IColorManager
    {
        ColorViewModel GetById(int id);


        IEnumerable<ColorViewModel> GetColors();

        void Insert(ColorViewModel item);

        void Update(ColorViewModel item);

        void Delete(int id);
    }
}
