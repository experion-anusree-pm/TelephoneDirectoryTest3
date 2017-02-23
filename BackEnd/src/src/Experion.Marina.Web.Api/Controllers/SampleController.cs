using Autofac;
using Experion.Marina.Business.Services.Contracts;
using Experion.Marina.Dto;
using System;
using System.Web.Http;

namespace Experion.Marina.Web.Api.Controllers
{
    public class SampleController : ApiController
    {
        private readonly IComponentContext _iocContext;

        public SampleController(IComponentContext iocContext)
        {
            _iocContext = iocContext;
        }

        /// <summary>
        /// Gets the sample.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/service/{id}")]
        public ResponseDto<SampleDto> GetSample(long id)
        {
            var sampleService = _iocContext.Resolve<ISampleService>();
            var responseDto = new ResponseDto<SampleDto>();

            try
            {
                var sample = sampleService.GetSample(id);
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


        [HttpPost]
        [Route("service")]
        public IHttpActionResult SaveSample(SampleDto sample)
        {
            return Ok();
        }
    }
}
