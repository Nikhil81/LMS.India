using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LMS.India.Repository;
using LMS.India.Models.Entities;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LMS.India.Controllers
{
    [Route("api/FeedBack/[action]")]
    public class FeedBackController : Controller
    {
        private readonly IUnitOfWork _iUnitOfWork;
        public FeedBackController(IUnitOfWork iUnitOfWork)
        {
            _iUnitOfWork = iUnitOfWork;

        }

        // GET: api/values
        [HttpGet(Name = "GetAllFeedbacks")]
        public IEnumerable<FeedBack> GetAllFeedbacks()
        {
           return _iUnitOfWork.FeedBackRepository.GetAll(m => m.QuestionAndRating);

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]FeedBack feedBack)
        {
            _iUnitOfWork.FeedBackRepository.Add(feedBack);
            return Ok(); 

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
