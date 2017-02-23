using Autofac;
using Experion.Marina.Data.Contracts.Entities;
using Experion.Marina.Data.Contracts.Services;
using Experion.Marina.Data.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experion.Marina.Data.Services.Services
{
    public class ContactDataService : DataService<MarinaContext>, IContactDataService
    {
        private IRepository<Contact, int> ContactRepository => DataContext.GetRepository<Contact, int>();

        public ContactDataService(IComponentContext iocContext, IRepositoryContext context)
            : base(iocContext, context)
        {
        }

        //Add new Directory
        public bool AddContact(IContact contactDetail)
        {

            var param = new Specification<Contact>(x => ((x.PhoneNumber == contactDetail.PhoneNumber)
            && (x.DirectoryId == contactDetail.DirectoryId)));
            var contacts = ContactRepository.GetBySpecification(param);
            if (contacts.Count == 0)
            {
                var contact = new Contact
                {
                    FirstName = contactDetail.FirstName,
                    LastName = contactDetail.LastName,
                    PhoneNumber = contactDetail.PhoneNumber,
                    Address = contactDetail.Address,
                    DirectoryId = contactDetail.DirectoryId
                };
                ContactRepository.Add(contact);
                Save();
                return false;
            }
            else
                return true;

        }


        //View Contact Details
        public IContact GetContactDetail(int id)
        {
            var entity = ContactRepository.GetById(id);
            return entity;

        }

        public bool EditContact(IContact ContactDetail)
        {
            Contact editted = ContactRepository.GetById(ContactDetail.Id);
            var param = new Specification<Contact>(x => (
            (x.PhoneNumber == ContactDetail.PhoneNumber) &&
            (x.DirectoryId == ContactDetail.DirectoryId) &&
            (x.Id != ContactDetail.Id)
            ));
            var operators = ContactRepository.GetBySpecification(param);
            if (operators.Count == 0)
            {
                editted.FirstName = ContactDetail.FirstName;
                editted.LastName = ContactDetail.LastName;
                editted.PhoneNumber = ContactDetail.PhoneNumber;
                editted.Address = ContactDetail.Address;
                //editted.DirectoryId = ContactDetail.DirectoryId;

                ContactRepository.Update(editted);
                Save();
                return false;
            }
            else
                return true;
        }

        //List
        public IEnumerable<IContact> GetAllContactsByDirectory(int DirectoryId)
        {

            var param = new Specification<Contact>(x => (x.DirectoryId == DirectoryId));
            var contacts = ContactRepository.GetBySpecification(param);
            return contacts;
        }

        //Search
        public IEnumerable<IContact> Search(string searchTerm)
        {
            var param = new Specification<Contact>(x => (
            (x.PhoneNumber.Contains(searchTerm)) ||
            (x.FirstName.Contains(searchTerm))
            ));
            var contacts = ContactRepository.GetBySpecification(param).
                OrderBy(c => c.DirectoryId);
            return contacts;
        }

    }
}
