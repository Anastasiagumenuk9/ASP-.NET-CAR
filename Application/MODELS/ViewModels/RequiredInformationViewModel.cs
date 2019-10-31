using System;
using System.Collections.Generic;
using System.Text;

namespace MODELS.ViewModels
{
    public class RequiredInformationViewModel
    {
        public int Id { get; set; }

        public string City { get; set; }

        public string Name { get; set; }

        public string Surame { get; set; }

        public string Address { get; set; }

        public string PostalCode { get; set; }

        public Gender Gender { get; set; }

        public string PhoneNumber { get; set; }

        public Payment PaymentMethod { get; set; }

        public string ApplicationUserId { get; set; }

    }
}
