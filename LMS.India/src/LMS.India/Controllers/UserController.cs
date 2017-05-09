using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LMS.India.Repository;
using LMS.India.Models.Entities;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LMS.India.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Authorize(Policy = "AuthorizeUser")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _iUnitOfWork;
        public UserController(IUnitOfWork iUnitOfWork)
        {
            _iUnitOfWork = iUnitOfWork;

        }
        // GET: api/values
        [HttpGet]
       
        public IEnumerable<Users> Get()
        {

            //var allUser = _iUnitOfWork.UsersRepository.GetAll().ToList(); 
            //return allUser;
            return new List<Users>();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            //var specificUser = _iUnitOfWork.UsersRepository.GetById(id);
            //return Json(specificUser);
            return Content("not implmented");
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Users value)
        {
            //_iUnitOfWork.UserRepository.Insert(value);
            //_iUnitOfWork.SaveDataToDataBase();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Users value)
        {
            //var specificUser = _context.Users.Find(id);
            //specificUser.UserName = value.UserName;
            //_context.Users.Update(specificUser);
            //_context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //var specificUser = _context.Users.Find(id);
            //_context.Users.Remove(specificUser);
            //_context.SaveChanges();
        }
    }
}
