using System;
using System.Collections.Generic;

namespace ppedv.Virository.Model
{
    public class Patient : Entity
    {
        public string Name { get; set; }
        public DateTime GebDatum { get; set; }
        public virtual HashSet<Virus> Viren { get; set; } = new HashSet<Virus>();
    }
}
