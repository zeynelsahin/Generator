using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.Entities
{
    public class Profile
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public ObjectEntity ObjectEntity { get; set; }
    }
}