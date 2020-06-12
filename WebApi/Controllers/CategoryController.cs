using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models;
using UnitOfWork;

namespace WebApi.Controllers
{
    [Route("api/category")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        [EnableCors("CORS")]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.Category.GetById(id));
        }

        [HttpGet("{page:int}/{rows:int}")]
        [EnableCors("CORS")]
        public IActionResult GetList(int page, int rows)
        {
            if (page == 0 && rows == 0)
            {
                return Ok(_unitOfWork.Category.GetList());
            }
            else {
                return Ok(_unitOfWork.Category.CategoryPagedList(page, rows));
            }
            
        }

        [HttpPost]
        [EnableCors("CORS")]
        public IActionResult Post([FromBody] Categories category)
        {
            if (ModelState.IsValid)
            {
                return Ok(_unitOfWork.Category.Insert(category));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [EnableCors("CORS")]
        public IActionResult Put([FromBody] Categories category)
        {
            if (ModelState.IsValid && _unitOfWork.Category.Update(category))
            {
                return Ok(new { Message = "The category was updated!!" });
            }
            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        [EnableCors("CORS")]
        public IActionResult Delete(int id)
        {
            var category = _unitOfWork.Category.GetById(id);
            if (category.Id > 0)
            {
                return Ok(_unitOfWork.Category.Delete(category));
            }
            return BadRequest();
        }

    }
}