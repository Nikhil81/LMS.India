using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LMS.India.Repository;
using LMS.India.Models.Entities;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LMS.India.Controllers
{
    [Route("api/Training/[action]")]
    //[Authorize(Policy = "AuthorizeUser")]
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

        // GET api/Training/GetTrainingsByEmail/nikhil.kumar2@globallogic.com
        [HttpGet("{email}", Name = "GetTrainingsByEmail")]
        public IEnumerable<Training> GetTrainingsByEmail(string email)
        {
            List<Training> _traingings = new List<Training>();
            var _alltraingings = _iUnitOfWork.TrainingRepository.GetAll("Sessions", "Sessions.Audiences", "Sessions.Trainer");
            foreach (var _eachTrainging in _alltraingings)
            {
                var _selectedtraingings = _eachTrainging.Sessions.SelectMany(x => x.Audiences).Where(x => x.Emails == email);
                if (_selectedtraingings.Any())
                {
                    _traingings.Add(_eachTrainging);

                }

            }
            return _traingings;

        }

        //GET api/Training/GetAllTrainingsByDate/nikhil.kumar2@globallogic.com/10/10/2017,11/10/2017
        [HttpGet("{email}/{Fromdate}/{Todate}", Name = "GetAllSessionByDate")]
        public IEnumerable<Sessions> GetAllSessionByDate(string email, DateTime Fromdate, DateTime Todate)
        {
            //todo refactor
            List<Sessions> _sessions = new List<Sessions>();
            var _allTraining = _iUnitOfWork.TrainingRepository.GetAll("Sessions", "Sessions.Audiences", "Sessions.Trainer");
            foreach (var _traingings in _allTraining)
            {
                var _selectedSessions = _traingings.Sessions.Where(x => (x.Sessiondate >= Fromdate && x.Sessiondate <= Todate));
                if (_selectedSessions.Any() && _selectedSessions.SelectMany(x =>x.Audiences.Where(y => y.Emails == email)).Any())
                {
                    //TODO : return selected sessions
                   // _sessions.Add(_selectedSessions);

                }

            }
            return _sessions;


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
