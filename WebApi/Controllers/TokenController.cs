using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models;
using UnitOfWork;
using WebApi.Authentication;

namespace WebApi.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : Controller
    {
        private ITokenProvider _tokenProvider;
        private IUnitOfWork _unitOfWork;
        public TokenController(ITokenProvider tokenProvider, IUnitOfWork unitOfWork) {
            _tokenProvider = tokenProvider;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [EnableCors("CORS")]
        public JsonWebToken Post([FromBody]Users userLogin) {
            var user = _unitOfWork.User.ValidateUser(userLogin.Email, userLogin.Password);
            if (user == null) {
                return null;
            }
            var token = new JsonWebToken { 
                AccessToken = _tokenProvider.CreateToken(user, DateTime.UtcNow.AddHours(1)),
                ExpiresIn = 60          
            };
            return token;
        }
    }
}