using System;
using System.Collections.Generic;
using System.Text;

namespace MODELS.DB
{
    public class Car
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortDesc { get; set; }

        public string LongDesc { get; set; }

        public ushort Price { get; set; }

        public ushort Run { get; set; }

        public bool isFavourite { get; set; }

        public bool Available { get; set; }

        public int ColorId { get; set; }

        public int CarTypeId { get; set; }

        public int PhotoCarId { get; set; }

        public int TransmissionId { get; set; }

        public Color Color { get; set; }

        public CarType CarType { get; set; }

        public Transmission Transmission { get; set; }

        public PhotoCar PhotoCar { get; set; }

        public ICollection<LocationCar> LocationsCars { get; set; }

     
    

    }
}
