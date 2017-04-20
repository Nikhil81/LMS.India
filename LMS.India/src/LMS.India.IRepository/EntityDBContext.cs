using LMS.India.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LMS.India.Repository
{
    public class EntityDBContext : DbContext
    {

        //used in tersting purpose will remove later
        public DbSet<FeedBack> FeedBackDbSet { get; set; }
        public DbSet<Questions> QuestionsDbSet { get; set; }
        public DbSet<Sessions> SessionsDbSet { get; set; }
        public DbSet<Trainees> TraineesDbSet { get; set; }
        public DbSet<Trainer> TrainerDbSet { get; set; }

        public DbSet<Training> TrainingDbSet { get; set; }

        public EntityDBContext(DbContextOptions<EntityDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FeedBack>().ToTable("tbl_Feedback");
            modelBuilder.Entity<Questions>().ToTable("tbl_Questions");
            modelBuilder.Entity<Sessions>().ToTable("tbl_Sessions");
            modelBuilder.Entity<Trainees>().ToTable("tbl_Trainees");
            modelBuilder.Entity<Trainer>().ToTable("tbl_Trainer");
            modelBuilder.Entity<Training>().ToTable("tbl_Training");

            //modelBuilder.Entity<FeedBack>()
            //.HasMany(p => p.QuestionAndRating);
            
           
        }

    }

}