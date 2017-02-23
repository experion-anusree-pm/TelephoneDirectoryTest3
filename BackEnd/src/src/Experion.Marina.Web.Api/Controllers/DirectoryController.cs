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
    public class DirectoryController :ApiController
    {
        private readonly IComponentContext _iocContext;

        public DirectoryController(IComponentContext iocContext)
        {
            _iocContext = iocContext;
        }

        //Add Directory
        [HttpPost]
        [Route("api/AddDirectory")]
        public bool AddDirectory(DirectoryDto directoryDetail)
        {
            var directoryService = _iocContext.Resolve<IDirectoryService>();
            var directoyExistOrNot = directoryService.AddDirectory(directoryDetail);
            return directoyExistOrNot;
        }

        //Edit Directory Fetch and return Details to view
        [HttpGet]
        [Route("api/EditDirectory/{id}")]
        public ResponseDto<DirectoryDto> GetDirectory(int id)
        {
            var directoryService = _iocContext.Resolve<IDirectoryService>();
            var responseDto = new ResponseDto<DirectoryDto>();

            try
            {
                var sample = directoryService.GetDirectory(id);
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



        //Updating
        [HttpPost]
        [Route("api/EditDirectory")]
        public bool EditDirectory(DirectoryDto directoryDetail)
        {
            var editService = _iocContext.Resolve<IDirectoryService>();
            var directoyExistOrNot = editService.EditDirectory(directoryDetail);
            return directoyExistOrNot;
        }

        //List Directory
        [HttpGet]
        [Route("api/listDirectory")]
        public ResponseDto<IEnumerable<DirectoryDto>> GetAllDirectory()
        {
            var listService = _iocContext.Resolve<IDirectoryService>();
            var responseDto = new ResponseDto<IEnumerable<DirectoryDto>>();

            try
            {
                var sample = listService.GetAllDirectory();
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