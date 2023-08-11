using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DAL
{
    public class XmlRepository<T> where T : Entity
    {
        private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "data.xml");
        protected XDocument _xmlDocument;

        public XmlRepository()
        {
            if (File.Exists(_filePath))
            {
                _xmlDocument = XDocument.Load(_filePath);
            }
            else
            {
                _xmlDocument = new XDocument(new XElement("root"));
            }
        }

        public void Create(T entity)
        {
            _xmlDocument.Element("root").Add(CreateElement(entity));
            _xmlDocument.Save(_filePath);
        }

        public T GetById(string entityId)
        {
            if(entityId == null)
            {
                return null;
            }

            XElement element = _xmlDocument.Descendants(typeof(T).Name).FirstOrDefault(e => e.Element("Id").Value == entityId);
            if (element != null)
            {
                return Deserialize<T>(element);
            }
            return null;
        }

        public List<T> GetAll()
        {
            List<T> entities = new List<T>();
            foreach (XElement element in _xmlDocument.Descendants(typeof(T).Name))
            {
                entities.Add(Deserialize<T>(element));
            }
            return entities;
        }

        public void Update(T entity)
        {
            XElement element = _xmlDocument.Descendants(typeof(T).Name).FirstOrDefault(e => e.Element("Id").Value == entity.Id);
            if (element != null)
            {
                element.Remove();
                _xmlDocument.Element("root").Add(CreateElement(entity));
                _xmlDocument.Save(_filePath);
            }
        }

        public void Delete(string entityId)
        {
            XElement element = _xmlDocument.Descendants(typeof(T).Name).FirstOrDefault(e => e.Element("Id").Value == entityId);
            if (element != null)
            {
                element.Remove();
                _xmlDocument.Save(_filePath);
            }
        }

        private XElement CreateElement<U>(U entity) where U: Entity
        {
            entity.Id = Guid.NewGuid().ToString();
            XmlSerializer serializer = new XmlSerializer(typeof(U));
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, entity);
                return XElement.Parse(writer.ToString());
            }
        }

        protected U Deserialize<U>(XElement element)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(U));
            using (var reader = new StringReader(element.ToString()))
            {
                return (U)serializer.Deserialize(reader);
            }
        }
    }
}
