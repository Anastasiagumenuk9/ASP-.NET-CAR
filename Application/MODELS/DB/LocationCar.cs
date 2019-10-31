using System;
using System.Collections.Generic;
using System.Text;

namespace MODELS.DB
{
    public class LocationCar
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public int LocationId { get; set; }

        public Location Location { get; set; }

        public Car Car { get; set; }
    }
}
