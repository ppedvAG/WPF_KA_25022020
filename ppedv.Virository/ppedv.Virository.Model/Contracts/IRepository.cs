using System;
using System.Collections.Generic;
using System.Text;

namespace ppedv.Virository.Model.Contracts
{
    public interface IRepository
    {
        T GetById<T>(int id) where T : Entity;
        IEnumerable<T> GetAll<T>() where T : Entity;

        void Add<T>(T entity) where T : Entity;
        void Delete<T>(T entity) where T : Entity;
        void Update<T>(T entity) where T : Entity;

        int SaveChanges();
    }
}
