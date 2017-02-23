using Experion.Marina.Business.Services.Contracts;
using Experion.Marina.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experion.Marina.Dto;
using Autofac;
using Experion.Marina.Data.Services.Entities;
using Experion.Marina.Data.Contracts.Services;
using Experion.Marina.Data.Contracts.Entities;
using Experion.Marina.Data.Contracts;

namespace Experion.Marina.Business.Services
{
    public class ContactService : BusinessService, IContactService
    {
        private readonly IComponentContext _iocContext;

        public ContactService(IComponentContext iocContext)
        {
            _iocContext = iocContext;
        }

        //Add new Contact
        public bool AddContact(ContactDto contactDetail)
        {
            var contactDataService = _iocContext.Resolve<IContactDataService>();
            var contact = _iocContext.Resolve<IContact>();

            contact.FirstName = contactDetail.FirstName;
            contact.LastName = contactDetail.LastName;
            contact.PhoneNumber = contactDetail.PhoneNumber;
            contact.Address = contactDetail.Address;
            contact.DirectoryId = contactDetail.DirectoryId;
            //ContactDataService.AddContact(contact);
            var ContactExistInDirectory = contactDataService.AddContact(contact);
            return ContactExistInDirectory;
        }

        //View Contact Details
        public ContactDto ContactDetail(int id)
        {
            var contactDataService = _iocContext.Resolve<IContactDataService>();
            //var directoryName = _iocContext.Resolve<ISelectDirectoryName>();

            var contactEntity = contactDataService.GetContactDetail(id);

            return new ContactDto
            {
                Id = contactEntity.Id,
                FirstName = contactEntity.FirstName,
                LastName = contactEntity.LastName,
                PhoneNumber = contactEntity.PhoneNumber,
                Address = contactEntity.Address,
                DirectoryId = contactEntity.DirectoryId,
                Name = this.DirectoryName(contactEntity.DirectoryId)
            };
        }

        //EDIT Contact
        public bool EditContact(ContactDto contactDetail)
        {
            var contactDataService = _iocContext.Resolve<IContactDataService>();
            var contact = _iocContext.Resolve<IContact>();
            contact.Id = contactDetail.Id;
            contact.FirstName = contactDetail.FirstName;
            contact.LastName = contactDetail.LastName;
            contact.PhoneNumber = contactDetail.PhoneNumber;
            contact.Address = contactDetail.Address;
            // contact.DirectoryId = ContactDetail.DirectoryId;

            var contactExistInDirectory = contactDataService.EditContact(contact);
            return contactExistInDirectory;

        }

        //List Contact
        public IEnumerable<ContactDto> GetAllContact(int directoryId)
        {
            var contactDataService = _iocContext.Resolve<IContactDataService>();
            var contact = contactDataService.GetAllContactsByDirectory(directoryId);

            if(contact==null)
            {
                return null;
            }

            return contact.Select(c => new ContactDto
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Address = c.Address,
                PhoneNumber = c.PhoneNumber
            });

            //TODO: Change to LINQ

            //List<ContactDto> contactList = new List<ContactDto>();
            //foreach (var data in contact)
            //{
            //    contactList.Add(new ContactDto
            //    {
            //        Id = data.Id,
            //        FirstName = data.FirstName,
            //        LastName = data.LastName,
            //        Address = data.Address,
            //        PhoneNumber = data.PhoneNumber
            //    });
            //}
            //return contactList;
        }


        //Search
        public IEnumerable<ContactDto> Search(string search)
        {
            var contactDataService = _iocContext.Resolve<IContactDataService>();
            //var directoryName = _iocContext.Resolve<ISelectDirectoryName>();

            var contact = contactDataService.Search(search);


            if (contact == null)
            {
                return null;
            }

            return contact.Select(c => new ContactDto
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Address = c.Address,
                PhoneNumber = c.PhoneNumber,
                DirectoryId = c.DirectoryId,
                Name = this.DirectoryName(c.DirectoryId)
            });

            // TODO: Change to LINQ
            //List<ContactDto> contactList = new List<ContactDto>();
            //foreach (var data in contact)
            //{
            //    contactList.Add(new ContactDto
            //    {
            //        Id = data.Id,
            //        FirstName = data.FirstName,
            //        LastName = data.LastName,
            //        Address = data.Address,
            //        PhoneNumber = data.PhoneNumber,
            //        DirectoryId = data.DirectoryId,
            //        Name = this.DirectoryName(data.DirectoryId)
            //    });
            //}
            //return contactList;
        }


        private string DirectoryName(int directoryId)
        {
            var directoryDataService = _iocContext.Resolve<IDirectoryDataService>();
            var directoryEntity = directoryDataService.GetDirectory(directoryId);
            return directoryEntity.Name;
        }

    }
}
