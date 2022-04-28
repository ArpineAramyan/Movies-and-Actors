using System.Collections.Generic;

namespace WebApplication3.Data.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string AboutActor { get; set; }
        public string Movies { get; set; }
    }
}
