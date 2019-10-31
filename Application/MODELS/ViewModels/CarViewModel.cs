using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MODELS.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [StringLength(1000)]
        public string ShortDesc { get; set; }

        [StringLength(10000)]
        public string LongDesc { get; set; }

        [Required(ErrorMessage = "The Price field is required.")]
        [Display(Name = "Price")]
        public ushort Price { get; set; }

        public ushort Run { get; set; }

        public bool isFavourite { get; set; }

        public bool Available { get; set; }

        public int ColorId { get; set; }

        public int CarTypeId { get; set; }

        public int TransmissionId { get; set; }
    }
}
