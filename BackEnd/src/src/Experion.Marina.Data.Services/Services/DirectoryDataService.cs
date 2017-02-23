using Autofac;
using Experion.Marina.Data.Contracts;
using Experion.Marina.Data.Contracts.Entities;
using Experion.Marina.Data.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experion.Marina.Data.Services.Services
{
    public class DirectoryDataService : DataService<MarinaContext>, IDirectoryDataService
    {
        private IRepository<Directory, int> DirectoryRepository => DataContext.GetRepository<Directory, int>();

        public DirectoryDataService(IComponentContext iocContext, IRepositoryContext context)
            : base(iocContext, context)
        {
        }

        //Add new Directory
        public bool AddDirectory(IDirectory directoryDetail)
        {
            var param = new Specification<Directory>(x => (x.Name == directoryDetail.Name));
            var operators = DirectoryRepository.GetBySpecification(param);
            if (operators.Count == 0)
            {
                var directory = new Directory
                {
                    Name = directoryDetail.Name
                };
                DirectoryRepository.Add(directory);
                Save();
                return false;
            }
            else
                return true;

        }

        //Fetch Directory Details
        public IDirectory GetDirectory(int id)
        {
            var directory = DirectoryRepository.GetById(id);
            return directory;
        }

        //Update Directory
        public bool EditDirectory(IDirectory directoryDetail)
        {
            var directory = DirectoryRepository.GetById(directoryDetail.Id);
            var param = new Specification<Directory>(x => (x.Name == directoryDetail.Name));
            var operators = DirectoryRepository.GetBySpecification(param);
            if (operators.Count == 0)
            {
                directory.Name = directoryDetail.Name;
                DirectoryRepository.Update(directory);
                Save();
                return false;
            }
            return true;
        }

        //List all directory
        public IEnumerable<IDirectory> GetAllDirectories()
        {
            var directories = DirectoryRepository.GetAll();
            return directories;
        }
    }
}
