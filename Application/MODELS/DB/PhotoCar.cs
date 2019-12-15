using System;
using System.Collections.Generic;
using System.Text;

namespace MODELS.DB
{
    public class PhotoCar
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Paint { get; set; }

        public ICollection<Car> Cars { get; set; }

      
    }
}
