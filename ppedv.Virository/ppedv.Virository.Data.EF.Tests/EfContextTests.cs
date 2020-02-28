using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.Virository.Model;
using System;
using System.Linq;

namespace ppedv.Virository.Data.EF.Tests
{
    [TestClass]
    public class EfContextTests
    {
        [TestMethod]
        public void EfContext_can_create_database()
        {
            using var con = new EfContext();
            if (con.Database.Exists())
                con.Database.Delete();

            Assert.IsFalse(con.Database.Exists());
            con.Database.CreateIfNotExists();
            Assert.IsTrue(con.Database.Exists());
        }

        [TestMethod]
        public void EfContext_can_add_Virus()
        {
            var virus = new Virus() { Name = $"TestZero_{Guid.NewGuid()}", Inkubationszeit = 12 };
            using (var con = new EfContext())
            {
                con.Viren.Add(virus);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Viren.Find(virus.Id);
                Assert.AreEqual(virus.Name, loaded.Name);

                //var result = con.Viren.Where(x => x.Inkubationszeit > 4 && x.Laender.Count > 4).ToList();
            }
        }
    }
}
