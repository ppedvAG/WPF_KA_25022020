using ppedv.Virository.Model;
using System.Data.Entity;

namespace ppedv.Virository.Data.EF
{
    public class EfContext : DbContext
    {
        public DbSet<Virus> Viren { get; set; }
        public DbSet<Land> Laender { get; set; }
        public DbSet<Patient> Patienten { get; set; }
        public DbSet<Symptom> Symptome { get; set; }

        public EfContext(string conString) : base(conString)
        { }
        public EfContext() : this("Server=.;Database=Virository_dev;Trusted_Connection=true")
        { }
    }
}
