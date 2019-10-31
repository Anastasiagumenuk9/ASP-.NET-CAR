using System;
using System.Collections.Generic;
using System.Text;

namespace MODELS.DB
{
    public class Location
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }


        public ICollection<LocationCar> LocationsCars { get; set; }

      
    }
}
