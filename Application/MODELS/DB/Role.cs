using System;
using System.Collections.Generic;
using System.Text;

namespace MODELS.DB
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<user> Users { get; set; }
        public Role()
        {
            Users = new List<user>();
        }
    }
}
