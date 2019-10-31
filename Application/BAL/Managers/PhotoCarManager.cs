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
    public class PhotoCarManager: GenericManager, IPhotoCarManager
    {
        private readonly IImageWrapper fileIo;
        public PhotoCarManager(IUnitOfWork unitOfWork, IMapper mapper, IImageWrapper fileIo) : base(unitOfWork, mapper)
        {
            this.fileIo = fileIo;
        }

        public DTOImages AddImage(ImageCarViewModel item)
        {
            if (item.PhotoFile == null)
                return new DTOImages() { Success = false, Details = "No logo sent" };

            if (item.CarId == 0)
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
                fileIo.SaveBitmap(image, "wwwroot/images/CommodityPhotos/Photo_Id=" + Convert.ToString(item.CarId) + ".png"
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
            PhotoCar photo = unitOfWork.PhotosCar.GetById(id);
            unitOfWork.PhotosCar.Delete(photo);
            unitOfWork.Save();
        }

        public PhotoCarViewModel GetById(int id)
        {
            PhotoCar photo = unitOfWork.PhotosCar.GetById(id);
            return mapper.Map<PhotoCar, PhotoCarViewModel>(photo);
        }

        public IEnumerable<PhotoCarViewModel> GetPhotosCar()
        {
            IEnumerable<PhotoCar> photos = unitOfWork.PhotosCar.GetAll();

            return mapper.Map<IEnumerable<PhotoCar>, List<PhotoCarViewModel>>(photos);
        }

        public void Update(PhotoCarViewModel item)
        {
            PhotoCar photo = mapper.Map<PhotoCarViewModel, PhotoCar>(item);

            unitOfWork.PhotosCar.Update(photo);
            unitOfWork.Save();
        }
    }
}
