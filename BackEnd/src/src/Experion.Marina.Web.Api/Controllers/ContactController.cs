using Autofac;
using Experion.Marina.Business.Services.Contracts;
using Experion.Marina.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Experion.Marina.Web.Api.Controllers
{
    public class ContactController : ApiController
    {
        private readonly IComponentContext _iocContext;

        public ContactController(IComponentContext iocContext)
        {
            _iocContext = iocContext;
        }

        //Add Contact
        [HttpPost]
        [Route("api/AddContact")]
        public bool AddContact(ContactDto ContactDetail)
        {
            var contactService = _iocContext.Resolve<IContactService>();
            var contactExistOrNot = contactService.AddContact(ContactDetail);
            return contactExistOrNot;
        }

        //View Contact Details & Fetch Details for editting Contact
        [HttpGet]
        [Route("api/ContactDetail/{id}")]
        public ResponseDto<ContactDto> ContactDetail(int id)
        {
            var contactService = _iocContext.Resolve<IContactService>();
            var responseDto = new ResponseDto<ContactDto>();

            try
            {
                var sample = contactService.ContactDetail(id);
                responseDto.Data = sample ?? null;
                responseDto.Messages = null;
            }
            catch (Exception)
            {
                responseDto = null;
                throw;
            }
            return responseDto;
        }

        //Update Contact after Edit
        [HttpPost]
        [Route("api/EditContact")]
        public bool EditContact(ContactDto contactDetail)
        {
            var editService = _iocContext.Resolve<IContactService>();
            var contactExistOrNot = editService.EditContact(contactDetail);

            return contactExistOrNot;
        }

        //List Contacts based on Directory Name
        [HttpGet]
        [Route("api/ListContact/{id}")]
        public ResponseDto<IEnumerable<ContactDto>> GetAllContact(int id)
        {
            var listService = _iocContext.Resolve<IContactService>();
            var responseDto = new ResponseDto<IEnumerable<ContactDto>>();

            try
            {
                var sample = listService.GetAllContact(id);
                responseDto.Data = sample ?? null;
                responseDto.Messages = null;
            }
            catch (Exception)
            {
                responseDto = null;
                throw;
            }
            return responseDto;
        }

        //Search 
        [HttpGet]
        [Route("api/SearchContact/{search}")]
        public ResponseDto<IEnumerable<ContactDto>> Search(string search)
        {
            var listService = _iocContext.Resolve<IContactService>();
            var responseDto = new ResponseDto<IEnumerable<ContactDto>>();

            try
            {
                var sample = listService.Search(search);
                responseDto.Data = sample ?? null;
                responseDto.Messages = null;
            }
            catch (Exception)
            {
                responseDto = null;
                throw;
            }
            return responseDto;
        }



    }
}
 