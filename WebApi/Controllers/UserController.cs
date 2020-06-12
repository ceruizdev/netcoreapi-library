using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models;
using UnitOfWork;

namespace WebApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        [EnableCors("CORS")]
        public IActionResult GetById(int id) {
            return Ok(_unitOfWork.User.GetById(id));
        }

        [HttpGet("{page:int}/{rows:int}")]
        [EnableCors("CORS")]
        public IActionResult GetList(int page, int rows)
        {
            if (page == 0 && rows == 0)
            {
                return Ok(_unitOfWork.User.GetList());
            }
            else {
                return Ok(_unitOfWork.User.UserPageList(page, rows));
            }
            
        }

        [HttpPost]
        [EnableCors("CORS")]
        public IActionResult Post([FromBody] Users user) {
            if (ModelState.IsValid)
            {
                return Ok(_unitOfWork.User.Insert(user));
            }
            else {
                return BadRequest();
            }
        }

        [HttpPut]
        [EnableCors("CORS")]
        public IActionResult Put([FromBody] Users user) {
            if (ModelState.IsValid && _unitOfWork.User.Update(user)) {
                return Ok(new { Message = "The user was updated!!"});
            }
            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        [EnableCors("CORS")]
        public IActionResult Delete(int id)
        {
            var user = _unitOfWork.User.GetById(id);
            if (user.Id > 0) {
                return Ok(_unitOfWork.User.Delete(user));
            }
            return BadRequest();
        }

        }
}
