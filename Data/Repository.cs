using Microsoft.AspNetCore.Mvc;

namespace CodingTest.Data
{
    // Repository Level class, designed to abstract the data management away from the controllers
    // Currently uses a list as the data, to coordinate with FakeData.cs.
    // Could be redesigned to use a database with only minor changes to the Controller.
    // For purposes of the assignment, this design would allow new Models (e.g. Office to use their own
    // Repository instance and utilize the same functions.
    public class Repository<TEntity> where TEntity : class
    {
       private List<TEntity> _entities;

       // Constructor takes a List, which is the data in current implementation.
       // If hooked up to a DB, would likely take a DB connection and utilize that
       public Repository(List<TEntity> entities)
        {
            _entities = entities;
            _entities.Sort();
        }

        // Returns the List containing the TEntitys. 
        public List<TEntity> GetEntities()
        {
            return _entities;
        }

        // Adds new TEntity to the list
        public void AddEntity(TEntity entity)
        {
            _entities.Add(entity);
            _entities.Sort();
        }

        // Removes TEntity from the list
        // TODO: add ability to remove based on identifier (e.g. ID)
        // That functionality would not be used at present, so it is not included.
        public bool RemoveEntity(TEntity entity)
        {
            return _entities.Remove(entity);
        }

        // Edits an entity by removing the old one and adding a new one,
        // Based on an imutable characteristic like ID.
        // This is suboptimal, but given we are using a list for data,
        // I decided this was the easier option. Would change to a regular
        // Update method if a database was hooked up.
        public void UpdateEntity(TEntity entity)
        {
            _entities.Remove(entity);
            _entities.Add(entity);
            _entities.Sort();
        }
    }
}
