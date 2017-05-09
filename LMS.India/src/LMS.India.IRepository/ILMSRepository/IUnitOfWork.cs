using LMS.India.Models.Entities;
using LMS.India.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.India.Repository
{
   public interface IUnitOfWork
    {
        ILMSRepository<FeedBack> FeedBackRepository { get; }
        ILMSRepository<Questions> QuestionsRepository { get; }
        ILMSRepository<Sessions> SessionsRepository { get; }
        ILMSRepository<Trainees> TraineesRepository { get; }
        ILMSRepository<Trainer> TrainerRepository { get; }
        ILMSRepository<Training> TrainingRepository { get; }
         ILMSRepository<Users> UsersRepository { get; }

    }
}
