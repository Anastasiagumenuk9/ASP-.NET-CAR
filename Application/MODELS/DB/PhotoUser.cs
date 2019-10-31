using System;
using System.Collections.Generic;
using System.Text;

namespace MODELS.DB
{
    public class PhotoUser
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Paint { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
