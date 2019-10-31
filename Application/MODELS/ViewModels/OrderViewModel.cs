using System;
using System.Collections.Generic;
using System.Text;

namespace MODELS.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public bool IsConfirmed { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
