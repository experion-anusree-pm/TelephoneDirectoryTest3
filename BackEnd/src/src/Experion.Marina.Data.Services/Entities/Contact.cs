using Experion.Marina.Data.Contracts.Entities;
using Experion.Marina.Data.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experion.Marina.Data.Services.Entities
{
    public class Contact : IContact, IEntity<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public int DirectoryId { get; set; }

        public virtual Directory Directory { get; set; }

    }
}
