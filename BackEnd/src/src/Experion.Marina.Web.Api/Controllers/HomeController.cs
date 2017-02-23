using Autofac;
using Experion.Marina.Business.Services.Contracts;
using Experion.Marina.Dto;
using System;
using System.Web.Http;

namespace Experion.Marina.Web.Api.Controllers
{
    public class HomeController : ApiController
    {
        private readonly IComponentContext _iocContext;

        public HomeController(IComponentContext iocContext)
        {
            _iocContext = iocContext;
        }


        [HttpPost]
        [Route("login")]
        public ResponseDto<UserValidDto> IsValidUser(UserDto user)
        {
            var userService = _iocContext.Resolve<IUserService>();
            var responseDto = new ResponseDto<UserValidDto>();

            try
            {
                var validUser = userService.IsValidUser(user);
                responseDto.Data = validUser ?? null;
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
