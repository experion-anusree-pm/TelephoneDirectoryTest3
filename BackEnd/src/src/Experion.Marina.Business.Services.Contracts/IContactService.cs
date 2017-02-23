using Experion.Marina.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experion.Marina.Business.Services.Contracts
{
    public interface IContactService
    {
        bool AddContact(ContactDto ContactDetail);
        ContactDto ContactDetail(int id);
        bool EditContact(ContactDto ContactDetail);
        IEnumerable<ContactDto> GetAllContact(int DirectoryId);
        IEnumerable<ContactDto> Search(string search);
    }
}
