using Experion.Marina.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experion.Marina.Business.Services.Contracts
{
    public interface IDirectoryService
    {
        bool AddDirectory(DirectoryDto directoryDetail);
        DirectoryDto GetDirectory(int id);
        bool EditDirectory(DirectoryDto directoryDetail);
        IEnumerable<DirectoryDto> GetAllDirectory();
    }
}
