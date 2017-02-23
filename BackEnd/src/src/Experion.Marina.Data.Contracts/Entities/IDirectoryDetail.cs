using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experion.Marina.Data.Contracts.Entities
{
    public interface IDirectoryDetail
    {
        IContact Contact { get; set; }
        IDirectory Directory { get; set; }
    }
}
