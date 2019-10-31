using MODELS.DTOs.ImagesDTOs;
using MODELS.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Interfaces
{
    public interface IPhotoCarManager
    {
        PhotoCarViewModel GetById(int id);

        IEnumerable<PhotoCarViewModel> GetPhotosCar();

        DTOImages AddImage(ImageCarViewModel item);

        void Update(PhotoCarViewModel item);

        void Delete(int id);
    }
}
