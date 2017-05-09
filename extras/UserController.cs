using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataModel.Data.Context;
using DataModel.Data.Model;
using DataModel.UnitOfWork.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private DataModel.UnitOfWork.Classes.UnitOfWorkClass _UnitOfWork = null;
        private static readonly ILogger _log = Startup.LoggerFactory.CreateLogger<UserController>();
        public UserController(WebApiDBContext context)
        {
            _UnitOfWork = new DataModel.UnitOfWork.Classes.UnitOfWorkClass(context);
        }
        // GET: api/values
        [HttpGet]
        [Authorize(Policy = "DisneyUser")]
        public async Task<IActionResult> Get()
        {
            _log.LogInformation("This is first log.....");
            var allUser = _UnitOfWork.UserRepository.GetAll().ToList(); 
            return Json(allUser);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var specificUser = _UnitOfWork.UserRepository.GetById(id);
            return Json(specificUser);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Users value)
        {
            _UnitOfWork.UserRepository.Insert(value);
            _UnitOfWork.SaveDataToDataBase();
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
