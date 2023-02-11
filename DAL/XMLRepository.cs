using Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace DAL
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
    {
        //private List<TEntity> entities;
        private readonly XElement entities;
        private readonly string currentDirectory = Directory.GetCurrentDirectory();
        private string currentEntityName = typeof(TEntity).Name.ToLower();
        private string fileName = "context.xml";


        public BaseRepository()
        {
            //string filePath = Path.Combine(currentDirectory, fileName);

            //if (!File.Exists(filePath))
            //{
            //    //XDocument doc = new XDocument(new XElement("body", new XElement(typeof(TEntity).Name.ToLower())));
            //    XDocument doc = new XDocument(new XElement("body"));
            //    //XDocument doc = new XDocument(new XElement("body",
            //    //                           new XElement(typeof(TEntity).Name.ToLower(),
            //    //                               new XElement("level2", "text"),
            //    //                               new XElement("level2", "other text"))));
            //    doc.Save(filePath);
            //}

            //entities = XElement.Load(filePath);
        }

        public void Create(TEntity entity)
        {
            var xmldoc = XDocument.Load("D:/test.xml");

            var bind = xmldoc.Descendants(typeof(TEntity).Name).Select(p => new
            {
                Id = p.Element("id").Value,
                Name = p.Element("name").Value,
                Salary = p.Element("salary").Value,
                Email = p.Element("email").Value,
                Address = p.Element("address").Value
            }).OrderBy(p => p.Id);

            //entity.Id = entities.Count + 1;
            //entities.Add(entity);
            //SaveChanges();
        }

        public void Delete(int id)
        {
            //TEntity entityToDelete = entities.FirstOrDefault(x => x.Id == id);
            //entities.Remove(entityToDelete);
            //SaveChanges();
        }

        public List<TEntity> GetAll()
        {
            var data = entities.Descendants(currentEntityName).Select(x => x.Attribute("id")).ToList();
            return null;
        }

        public TEntity GetById(int id)
        {
            return null;
            //return entities.FirstOrDefault(x => x.Id == id);
        }

        public void Update(TEntity entity)
        {
            //int indexToUpdate = entities.FindIndex(x => x.Id == entity.Id);

            //if (indexToUpdate >= 0)
            //{
            //    entities[indexToUpdate] = entity;
            //    SaveChanges();
            //}
        }

        public void SaveChanges()
        {
            //string json = JsonConvert.SerializeObject(entities);
            //File.WriteAllText(FilePath, json);
        }
    }
}
