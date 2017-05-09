using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.India.Models.Entities;

namespace LMS.India.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ILMSRepository<FeedBack> _feedBackRepository;
        private ILMSRepository<Questions> _questionsRepository;
        private ILMSRepository<Sessions> _sessionsRepository;
        private ILMSRepository<Trainees> _traineesRepository;
        private ILMSRepository<Trainer> _trainerRepository;
        private ILMSRepository<Training> _trainingRepository;
        private ILMSRepository<Users> _usersRepository;
        
        private EntityDBContext _context;

        public UnitOfWork(EntityDBContext context)
        {
            _context = context;
        }

        public ILMSRepository<FeedBack> FeedBackRepository
        {
            get
            {
                if (_feedBackRepository == null)
                {
                    _feedBackRepository = new GenericRepository<FeedBack>(_context);
                }
                return _feedBackRepository;
            }
        }

        public ILMSRepository<Questions> QuestionsRepository
        {
            get
            {
                if (_questionsRepository == null)
                {
                    _questionsRepository = new GenericRepository<Questions>(_context);
                }
                return _questionsRepository;
            }
        }

        public ILMSRepository<Sessions> SessionsRepository
        {
            get
            {
                if (_sessionsRepository == null)
                {
                    _sessionsRepository = new GenericRepository<Sessions>(_context);
                }
                return _sessionsRepository;
            }
        }

        public ILMSRepository<Trainees> TraineesRepository
        {
            get
            {
                if (_traineesRepository == null)
                {
                    _traineesRepository = new GenericRepository<Trainees>(_context);
                }
                return _traineesRepository;
            }
        }

        public ILMSRepository<Trainer> TrainerRepository
        {
            get
            {
                if (_trainerRepository == null)
                {
                    _trainerRepository = new GenericRepository<Trainer>(_context);
                }
                return _trainerRepository;
            }
        }

        public ILMSRepository<Training> TrainingRepository
        {
            
            get
            {
                if (_trainingRepository == null)
                {
                    _trainingRepository = new GenericRepository<Training>(_context);
                }
                return _trainingRepository;
            }
        }

        public ILMSRepository<Users> UsersRepository
        {
            get
            {

                if (_usersRepository == null)
                {
                    _usersRepository = new GenericRepository<Users>(_context);
                }
                return _usersRepository;
            }
        }
    }
}
