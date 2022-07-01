using Microsoft.AspNetCore.Mvc;

namespace CodingTest.Data
{
    public class Repository<TEntity> where TEntity : class
    {
       private List<TEntity> _entities;

       public Repository(List<TEntity> entities)
        {
            _entities = entities;
            _entities.Sort();
        }

        public List<TEntity> GetEntities()
        {
            return _entities;
        }

        public void AddEntity(TEntity entity)
        {
            _entities.Add(entity);
            _entities.Sort();
        }

        public bool RemoveEntity(TEntity entity)
        {
            return _entities.Remove(entity);
        }

        public void UpdateEntity(TEntity entity)
        {
            _entities.Remove(entity);
            _entities.Add(entity);
            _entities.Sort();
        }
    }
}
