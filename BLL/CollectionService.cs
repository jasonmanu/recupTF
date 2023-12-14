using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ICollectionService : IBaseService<Collection>
    {
    }

    public class CollectionService : BaseService<Collection>, ICollectionService
    {
        private readonly ICollectionRepository collectionRepository;

        public CollectionService(ICollectionRepository collectionRepository) : base(collectionRepository)
        {
            this.collectionRepository = collectionRepository;
        }
    }
}
