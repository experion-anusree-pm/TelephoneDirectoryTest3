using Experion.Marina.Data.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experion.Marina.Data.Services.Entities
{
    public class Directory : IDirectory, IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
