using Experion.Marina.Data.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experion.Marina.Data.Contracts
{
    public interface IDirectoryDataService
    {
        bool AddDirectory(IDirectory s);
        bool EditDirectory(IDirectory s);
        IDirectory GetDirectory(int id);
        IEnumerable<IDirectory> GetAllDirectories();
    }
}
