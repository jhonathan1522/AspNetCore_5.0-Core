using AspNetCore.Abstractions;
using AspNetCore.Repository;
using System;
using System.Collections.Generic;

namespace AspNetCore.Application
{
    public interface IApplication<T>: ICrud<T>
    {
        
    }

    public class Application<T> : IApplication<T> where T: IEntity
    {

        private readonly IRepository<T> _repository;
    
        public Application(IRepository<T> repository)
        {
            _repository = repository;
        }


        public void Delete(int id)
        {
            // Utilizamos el patrón adapter, vamos adaptar la aplicación al repositorio en las operaciones CRUD
            _repository.Delete(id);
        }

        public IList<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(int id)
        {
           return  _repository.GetById(id);
        }

        public T Save(T entity)
        {
            return _repository.Save(entity);
        }
    }
}
