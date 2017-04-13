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
    [Route("api/[controller]")]
    public class TrainingController : Controller
    {
        private readonly IUnitOfWork _iUnitOfWork;
        public TrainingController(IUnitOfWork iUnitOfWork)
        {
            _iUnitOfWork = iUnitOfWork;

        }
        // GET: api/Training/GetAllTrainings
        [HttpGet]
        public IEnumerable<Training> GetAllTrainings()
        {
            return _iUnitOfWork.TrainingRepository.GetAll();
        }

        // GET api/Training/GetAllTrainings/5
        [HttpGet("{id}")]
        public string GetTrainingsById(int id)
        {
            return "value 1";
        }
        // GET api/Training/GetAllTrainingsByDate/10/10/2017,11/10/2017
        [HttpGet("{Fromdate}/{Todate}")]
        public string GetAllTrainingsByDate(DateTime Fromdate, DateTime Todate)
        {
            return "value 2";
        }

        // GET api/Training/GetAllEnrolledTrainingsByUserId/10
        [HttpGet("{empId}")]
        public string GetAllEnrolledTrainingsByUserId(int empId)
        {
            return "value 3";
        }
        // GET api/Training/GetAllEnrolledTrainingsHistory/10
        [HttpGet]
        public string GetAllEnrolledTrainingsHistory()
        {
            return "value 4";
        }


        // POST api/Training/PostAllTrainings
        [HttpPost]
        public void PostAllTrainings([FromBody]Training value)
        {
        }

        // PUT api/Training/PutTrainings/5
        [HttpPut("{id}")]
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
