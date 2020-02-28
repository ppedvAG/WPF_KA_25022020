using System.Collections.Generic;

namespace ppedv.Virository.Model
{
    public class Land : Entity
    {
        public string Name { get; set; }
        public int Einwohner { get; set; }
        public virtual HashSet<Virus> Viren { get; set; } = new HashSet<Virus>();
    }
}
