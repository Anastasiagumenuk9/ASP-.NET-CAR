using AutoMapper;
using BAL.Interfaces;
using BAL.Wrappers;
using MODELS.DB;
using MODELS.DTOs.ImagesDTOs;
using MODELS.Interfaces;
using MODELS.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace BAL.Managers
{
    public class PhotoUserManager : GenericManager, IPhotoUserManager
    {
        private readonly IImageWrapper fileIo;
        public PhotoUserManager(IUnitOfWork unitOfWork, IMapper mapper, IImageWrapper fileIo) : base(unitOfWork, mapper)
        {
            this.fileIo = fileIo;

        }


        public DTOImages AddImage(ImageUserViewModel item)
        {
            if (item.PhotoFile == null)
                return new DTOImages() { Success = false, Details = "No logo sent" };

            if (item.ApplicationUserId == 0)
                return new DTOImages() { Success = false, Details = "Empty operator id" };

            // Create bitmap
            var stream = item.PhotoFile.OpenReadStream();
            Bitmap image;
            try
            {
                image = new Bitmap(stream);
                image = new Bitmap(image, 1000, 1000);
                // .setResolution() doesnt work. Bug, possibly
            }
            catch (ArgumentException)
            {
                return new DTOImages() { Success = false, Details = "Image data corrupted" };
            }
            catch (Exception)
            {
                return new DTOImages() { Success = false, Details = "Image can't be resized" };
            }

            if (!fileIo.Exists("wwwroot/images/CommodityPhotos/"))
            {
                try
                {
                    fileIo.CreateDirectory("wwwroot/images/CommodityPhotos/");
                }
                catch (Exception)
                {
                    return new DTOImages() { Success = false, Details = "Can't create directory for logos" };
                }
            }

            try
            {
                fileIo.SaveBitmap(image, "wwwroot/images/CommodityPhotos/Photo_Id=" + Convert.ToString(item.ApplicationUserId) + ".png"
                    , ImageFormat.Png);
            }
            catch (ArgumentNullException)
            {
                return new DTOImages() { Success = false, Details = "Internal error" };
            }
            catch (System.Runtime.InteropServices.ExternalException)
            {
                return new DTOImages() { Success = false, Details = "Saving destination cannot be reached" };
            }
            catch (Exception)
            {
                return new DTOImages() { Success = false, Details = "Internal error" };
            }

            return new DTOImages() { Success = true };

        }

        public void Delete(int id)
        {
            PhotoUser photo = unitOfWork.PhotosUser.GetById(id);
            unitOfWork.PhotosUser.Delete(photo);
            unitOfWork.Save();
        }

        public PhotoUserViewModel GetById(int id)
        {
            PhotoUser photo = unitOfWork.PhotosUser.GetById(id);
            return mapper.Map<PhotoUser, PhotoUserViewModel>(photo);
        }


        public IEnumerable<PhotoUserViewModel> GetPhotosUser()
        {
            IEnumerable<PhotoUser> photos = unitOfWork.PhotosUser.GetAll();

            return mapper.Map<IEnumerable<PhotoUser>, List<PhotoUserViewModel>>(photos);
        }


        public void Update(PhotoUserViewModel item)
        {
            PhotoUser photo = mapper.Map<PhotoUserViewModel, PhotoUser>(item);

            unitOfWork.PhotosUser.Update(photo);
            unitOfWork.Save();
        }

    }
}
