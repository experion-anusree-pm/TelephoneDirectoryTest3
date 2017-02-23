using Experion.Marina.Data.Contracts.Entities;
using Experion.Marina.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experion.Marina.Data.Contracts.Services
{
    public interface IContactDataService
    {
        bool AddContact(IContact ContactDetail);
        IContact GetContactDetail(int id);
        bool EditContact(IContact ContactDetail);
        IEnumerable<IContact> GetAllContactsByDirectory(int DirectoryId);
        IEnumerable<IContact> Search(string search);
    }
}
