using System.Collections.Generic;

namespace ppedv.Virository.Model
{
    public class Symptom : Entity
    {
        public string Beschreibung { get; set; }
        public string Farbe { get; set; }
        public virtual HashSet<Virus> Viren { get; set; } = new HashSet<Virus>();
    }
}
