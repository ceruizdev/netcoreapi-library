using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models;
using UnitOfWork;

namespace WebApi.Controllers
{
    [Route("api/author")]
    [ApiController]
    [Authorize]
    public class AuthorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        [EnableCors("CORS")]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.Author.GetById(id));
        }

        [HttpGet("{page:int}/{rows:int}")]
        [EnableCors("CORS")]
        public IActionResult GetList(int page, int rows)
        {
            if (page == 0 && rows == 0) {
                return Ok(_unitOfWork.Author.GetList());
            }else {
                return Ok(_unitOfWork.Author.AuthorPagedList(page, rows));
            }
            
        }

        [HttpPost]
        [EnableCors("CORS")]
        public IActionResult Post([FromBody] Authors author)
        {
            if (ModelState.IsValid)
            {
                return Ok(_unitOfWork.Author.Insert(author));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [EnableCors("CORS")]
        public IActionResult Put([FromBody] Authors author)
        {
            if (ModelState.IsValid && _unitOfWork.Author.Update(author))
            {
                return Ok(new { Message = "The author was updated!!" });
            }
            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        [EnableCors("CORS")]
        public IActionResult Delete(int id)
        {
            var author = _unitOfWork.Author.GetById(id);
            if (author.Id > 0)
            {
                return Ok(_unitOfWork.Author.Delete(author));
            }
            return BadRequest();
        }

    }
}