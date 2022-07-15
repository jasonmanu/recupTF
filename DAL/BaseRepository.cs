using Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DAL
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
    {
        private List<TEntity> entities;
        private string FilePath;

        public BaseRepository()
        {
            FilePath = $"..\\..\\..\\DAL\\Backup\\{typeof(TEntity).Name}.json";
            string dataString = File.ReadAllText(FilePath);
            entities = JsonConvert.DeserializeObject<List<TEntity>>(dataString);
        }

        public void Create(TEntity entity)
        {
            entity.Id = entities.Count + 1;
            entities.Add(entity);
            SaveChanges();
        }

        public void Delete(int id)
        {
            TEntity entityToDelete = entities.FirstOrDefault(x => x.Id == id);
            entities.Remove(entityToDelete);
            SaveChanges();
        }

        public List<TEntity> GetAll()
        {
            return entities;
        }

        public TEntity GetById(int id)
        {
            return entities.FirstOrDefault(x => x.Id == id);
        }

        public void Update(TEntity entity)
        {
            int indexToUpdate = entities.FindIndex(x => x.Id == entity.Id);

            if (indexToUpdate >= 0)
            {
                entities[indexToUpdate] = entity;
                SaveChanges();
            }
        }

        public void SaveChanges()
        {
            string json = JsonConvert.SerializeObject(entities);
            File.WriteAllText(FilePath, json);
        }
    }
}
