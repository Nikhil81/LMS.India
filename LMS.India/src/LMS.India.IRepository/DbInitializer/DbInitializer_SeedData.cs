using LMS.India.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.India.Repository
{
    public class DbInitializer_SeedData
    {
       
        private readonly IUnitOfWork _iUnitOfWork;
        public DbInitializer_SeedData(IUnitOfWork iUnitOfWork)
        {
            _iUnitOfWork = iUnitOfWork;

        }
        public static void Initialize(EntityDBContext context)
        {
            #region Feedback

           
            context.Database.EnsureCreated();
            if (context.FeedBackDbSet.Any())
            {
                return;   // DB has been seeded
            }
            var qNa = new List<Questions>() {
                new Questions
                            {
                               
                                Question = "meet you learing objective",
                                LearningObjectiveAndFacilitator = Models.Enums.LearningObjectiveAndFacilitator.LearningObjective,
                                Rating =2
                            },
                 new Questions
                            {
                     
                                Question = "Duration",
                                LearningObjectiveAndFacilitator = Models.Enums.LearningObjectiveAndFacilitator.LearningObjective,
                                Rating =3
                            },
                 new Questions
                            {
                     
                                Question = "Application knowleage",
                                LearningObjectiveAndFacilitator = Models.Enums.LearningObjectiveAndFacilitator.LearningObjective,
                                Rating =3
                            },
                  new Questions
                            {
                     
                                Question = "Value knowleage",
                                LearningObjectiveAndFacilitator = Models.Enums.LearningObjectiveAndFacilitator.LearningObjective,
                                Rating =3
                            },
                    new Questions
                            {
                        
                                Question = "Trainer knowleage",
                                LearningObjectiveAndFacilitator = Models.Enums.LearningObjectiveAndFacilitator.LearningFacilitator,
                                Rating =3
                            },
                     new Questions
                            {
                         
                                Question = "Presentation knowleage",
                                LearningObjectiveAndFacilitator = Models.Enums.LearningObjectiveAndFacilitator.LearningFacilitator,
                                Rating =3
                            },
                      new Questions
                            {
                         
                                Question = "ability",
                                LearningObjectiveAndFacilitator = Models.Enums.LearningObjectiveAndFacilitator.LearningFacilitator,
                                Rating =3
                            },
                      new Questions
                            {
                         
                                Question = "Qulality",
                                LearningObjectiveAndFacilitator = Models.Enums.LearningObjectiveAndFacilitator.LearningFacilitator,
                                Rating =3
                            },
                       new Questions
                            {
                          
                                Question = "Practicle",
                                LearningObjectiveAndFacilitator = Models.Enums.LearningObjectiveAndFacilitator.LearningFacilitator,
                                Rating =3
                            }
            };
            
            var _feedBacks = new FeedBack
            {
                AttendeeId = 1,
                FeedbackDate = DateTime.Now,
                QuestionAndRating = qNa,
                Remark = "Pleae provide more sessions",
                SessionId = 1
            };

            context.FeedBackDbSet.Add(_feedBacks);
            //context.SaveChanges();
            #endregion


            #region Trainings
            var _trainer = new Trainer {Email ="nikhil.kumar2@globallogic.com",Name="Nikhil" };
            var _trainer1 = new Trainer { Email = "nikhil.kumar@globallogic.com", Name = "Nikhil" };
            var _trainees = new List<Trainees> {
                new Trainees { Emails = "nikhil.kumar@globallogic.com" },
                new Trainees { Emails = "nikhil.kumar2@globallogic.com"},

            };
            var _trainees1 = new List<Trainees> {
                new Trainees { Emails = "nikhil.kumar@globallogic.com" },
                new Trainees { Emails = "nikhil.kumar2@globallogic.com"},

            };

            //var _trainees = new List<string> {
            //    "nikhil.kumar@globallogic.com" , "nikhil.kumar2@globallogic.com"

            //};


            List<Sessions> _sessions = new List<Sessions> {

                new Sessions {
                                    Audiences = _trainees,
                                    Durations=3.5,
                                    IsActive=true,
                                    IsEnroll=true,
                                    IsInternal = true,
                                    LastDateOfRegistration = DateTime.Now.AddDays(20),
                                    Sessiondate = DateTime.Now.AddDays(21),
                                    SessionName="Core Java",
                                    SessionNominatedBy="Nikhil",
                                    Trainer  = _trainer
                }
                ,

                new Sessions {
                                    Audiences = _trainees1,
                                    Durations=3,
                                    IsActive=true,
                                    IsEnroll=true,
                                    IsInternal = true,
                                    LastDateOfRegistration = DateTime.Now.AddDays(20),
                                    Sessiondate = DateTime.Now.AddDays(23),
                                    SessionName="Advance Java",
                                    SessionNominatedBy="Nikhil",
                                    Trainer  = _trainer1
                },
            };
           
            //traingings
            var _trainings = new Training()
            {
                CourseTitle="Java",
                LearningType =Models.Enums.LearningType.Technical,
                Locations =Models.Enums.Locations.Noida,
                MaxNoOfAttendees =30,
                NoOfSessions = 2,
                Sessions = _sessions
                
            };
            context.TrainingDbSet.Add(_trainings);
            context.SaveChanges();
            #endregion
        }
    }
}
