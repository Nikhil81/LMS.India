using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LMS.India.Repository;
using LMS.India.Models.Entities;
using System.Linq.Expressions;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LMS.India.Controllers
{
    [Route("api/Training/[action]")]
    public class TrainingController : Controller
    {
        private readonly IUnitOfWork _iUnitOfWork;
        public TrainingController(IUnitOfWork iUnitOfWork)
        {
            _iUnitOfWork = iUnitOfWork;

        }

        // GET: api/Training/GetAllTrainings
        [HttpGet(Name = "GetAllTrainings")]
        public IEnumerable<Training> GetAllTrainings()
        {
            //TODO : Bad Practice refactor it
            //return _iUnitOfWork.TrainingRepository.GetAll(x => x.Sessions, a=> a.Sessions.Select(b => b.Audiences), c => c.Sessions.Select(d => d.Trainer));
            return _iUnitOfWork.TrainingRepository.GetAll("Sessions", "Sessions.Audiences", "Sessions.Trainer");
        }


        // GET api/Training/GetAllTrainings/5
        [HttpGet("{id}", Name = "GetTrainingsById")]
        public Training GetTrainingsById(int id)
        {
            return _iUnitOfWork.TrainingRepository.Find(id);
        }

        //GET api/Training/GetAllTrainingsByDate/10/10/2017,11/10/2017
        [HttpGet("{Fromdate}/{Todate}", Name = "GetAllTrainingsByDate")]
        public string GetAllTrainingsByDate(DateTime Fromdate, DateTime Todate)
        {
           return "value 2";
        }

        //GET api/Training/GetAllEnrolledTrainingsByUserId/10
        [HttpGet("{empId}", Name = "GetAllEnrolledTrainingsByUserId")]
        public string GetAllEnrolledTrainingsByUserId(int empId)
        {
            return "value 3";
        }

        // GET api/Training/GetAllEnrolledTrainingsHistory/10
        [HttpGet(Name = "GetAllEnrolledTrainingsHistory")]
        public string GetAllEnrolledTrainingsHistory()
        {
            return "value 4";
        }


        // POST api/Training/PostAllTrainings
        [HttpPost(Name = "PostAllTrainings")]
        public IActionResult PostAllTrainings([FromBody]Training value)
        {
            _iUnitOfWork.TrainingRepository.Add(value);
            return Ok();
        }

        // PUT api/Training/PutTrainings/5
        [HttpPut("{id}", Name = "PutTrainings")]
        public void PutTrainings(int id, [FromBody]Training value)
        {
        }

        // DELETE api/Training/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
