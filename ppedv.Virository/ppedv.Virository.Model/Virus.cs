using System.Collections.Generic;

namespace ppedv.Virository.Model
{
    public class Virus : Entity
    {
        public string Name { get; set; }
        public int Inkubationszeit { get; set; }
        public double Tödlichkeit { get; set; }
        public virtual HashSet<Land> Laender { get; set; } = new HashSet<Land>();
        public virtual HashSet<Symptom> Symptome { get; set; } = new HashSet<Symptom>();
        public virtual Patient PatientZero { get; set; }
    }
}
