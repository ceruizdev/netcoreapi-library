using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using UnitOfWork;

namespace WebApi.Controllers
{
    [Route("api/book")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        [EnableCors("CORS")]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.Book.GetById(id));
        }


        [HttpGet("filter/{type:int}/{filter}")]
        [EnableCors("CORS")]
        public IActionResult GetList(int type, string filter)
        {
                return Ok(_unitOfWork.Book.FilterQuery(type, filter));
        }

        [HttpGet("{page:int}/{rows:int}")]
        [EnableCors("CORS")]
        public IActionResult GetList(int page, int rows)
        {
            if (page == 0 && rows == 0)
            {
                return Ok(_unitOfWork.Book.GetList());
            }
            else {
                return Ok(_unitOfWork.Book.BookPagedList(page, rows));
            }
                
        }

        [HttpPost]
        [EnableCors("CORS")]
        public IActionResult Post([FromBody] Books book)
        {
            if (ModelState.IsValid)
            {
                return Ok(_unitOfWork.Book.Insert(book));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [EnableCors("CORS")]
        public IActionResult Put([FromBody] Books book)
        {
            if (ModelState.IsValid && _unitOfWork.Book.Update(book))
            {
                return Ok(new { Message = "The book was updated!!" });
            }
            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        [EnableCors("CORS")]
        public IActionResult Delete(int id)
        {
            var book = _unitOfWork.Book.GetById(id);
            if (book.Id > 0)
            {
                return Ok(_unitOfWork.Book.Delete(book));
            }
            return BadRequest();
        }
    }
}