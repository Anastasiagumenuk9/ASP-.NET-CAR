using AutoMapper;
using BAL.Interfaces;
using MODELS.DB;
using MODELS.Interfaces;
using MODELS.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Managers
{
    public class ColorManager : GenericManager, IColorManager
    {
        public ColorManager(IUnitOfWork unitOfWork, IMapper mapper): base(unitOfWork, mapper)
        {

        }

        public void Delete(int id)
        {
            Color color = unitOfWork.Colors.GetById(id);
            unitOfWork.Colors.Delete(color);
            unitOfWork.Save();
        }

        public ColorViewModel GetById(int id)
        {
            Color color = unitOfWork.Colors.GetById(id);
            return mapper.Map<Color, ColorViewModel>(color);
        }

        public IEnumerable<ColorViewModel> GetColors()
        {
            IEnumerable<Color> colors = unitOfWork.Colors.GetAll();
            return mapper.Map<IEnumerable<Color>, List<ColorViewModel>>(colors);
        }

        public void Insert(ColorViewModel item)
        {
            Color color = mapper.Map<ColorViewModel, Color>(item);
            unitOfWork.Colors.Insert(color);
            unitOfWork.Save();
        }

        public void Update(ColorViewModel item)
        {
            Color color = mapper.Map<ColorViewModel, Color>(item);
            unitOfWork.Colors.Update(color);
            unitOfWork.Save();
        }
    }
}
