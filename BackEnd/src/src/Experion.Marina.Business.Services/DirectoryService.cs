using Autofac;
using Experion.Marina.Business.Services.Contracts;
using Experion.Marina.Core;
using Experion.Marina.Data.Contracts;
using Experion.Marina.Data.Contracts.Entities;
using Experion.Marina.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experion.Marina.Business.Services
{
    public class DirectoryService : BusinessService, IDirectoryService
    {
        private readonly IComponentContext _iocContext;

        public DirectoryService(IComponentContext iocContext)
        {
            _iocContext = iocContext;
        }

        //Add Directory
        public bool AddDirectory(DirectoryDto directoryDetail)
        {
            var directoryDataService = _iocContext.Resolve<IDirectoryDataService>();
            var directory = _iocContext.Resolve<IDirectory>();

            directory.Name = directoryDetail.Name;

            var directoryExist = directoryDataService.AddDirectory(directory);
            return directoryExist;
        }

        //Fetch Directory Details
        public DirectoryDto GetDirectory(int id)
        {
            var directoryDataService = _iocContext.Resolve<IDirectoryDataService>();

            var directory = directoryDataService.GetDirectory(id);

            return new DirectoryDto
            {
                Name = directory.Name
            };
        }


        //Edit Directory
        public bool EditDirectory(DirectoryDto directoryDetail)
        {
            var directoryDataService = _iocContext.Resolve<IDirectoryDataService>();
            var directory = _iocContext.Resolve<IDirectory>();
            directory.Id = directoryDetail.Id;
            directory.Name = directoryDetail.Name;

            var directoryExist = directoryDataService.EditDirectory(directory);
            return directoryExist;

        }


        //List Directory
        public IEnumerable<DirectoryDto> GetAllDirectory()
        {
            var directoryDataService = _iocContext.Resolve<IDirectoryDataService>();
            var directories = directoryDataService.GetAllDirectories();

            if (directories == null)
            {
                return null;
            }

            return directories.Select(d => new DirectoryDto
            {
                Id = d.Id,
                Name = d.Name
            });

            //List<DirectoryDto> directoryList = new List<DirectoryDto>();
            //foreach (var data in directories)
            //{
            //    directoryList.Add(new DirectoryDto
            //    {
            //        Id = data.Id,
            //        Name = data.Name
            //    });
            //}
            
        }

    }
}
