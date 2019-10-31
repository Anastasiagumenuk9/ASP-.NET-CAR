using MODELS.DTOs.ImagesDTOs;
using MODELS.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Interfaces
{
    public interface IPhotoUserManager
    {
        PhotoUserViewModel GetById(int id);


        IEnumerable<PhotoUserViewModel> GetPhotosUser();

        DTOImages AddImage(ImageUserViewModel item);

        void Update(PhotoUserViewModel item);

        void Delete(int id);
    }
}
