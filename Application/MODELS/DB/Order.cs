using System;
using System.Collections.Generic;
using System.Text;

namespace MODELS.DB
{
    public class Order
    {
        public int Id { get; set; }

        public Car Car { get; set; }

        public bool IsConfirmed { get; set; }

        public DateTime DataOrder { get; set; }

        public DateTime DataConfirmed { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public RequiredInformation RequiredInformation { get; set; }

        public int RequiredInformationId { get; set; }
    }
}
