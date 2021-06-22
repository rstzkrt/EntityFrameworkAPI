using CodeFirstEFcoreAPI.Efcore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstEFcoreAPI.models
{
    public class MainDatabaseContext : DbContext
    {
        public MainDatabaseContext() { }

        public MainDatabaseContext(DbContextOptions opt) : base(opt)
        {

        }

        public DbSet<Car> cars { get; set; }
        public DbSet<Insception> insceptions { get; set; }
        public DbSet<Mechanic> mechanics { get; set; }
        public DbSet<ServiceTypeDict> serviceTypeDicts { get; set; }
        public DbSet<ServiceTypeDictInsception> serviceTypeDictInsceptions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s20207;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CarEntityType());
            modelBuilder.ApplyConfiguration(new MechanicEntityType());
            modelBuilder.ApplyConfiguration(new InsceptionEntityType());
            modelBuilder.ApplyConfiguration(new ServiceTypeDictEntityType());
            modelBuilder.ApplyConfiguration(new ServiceTypeDictInsceptionEntityType());

            
            //
            modelBuilder.Entity<Car>(opt =>
            {
                opt.HasData(
                    new Car { IdCar = 1, name = "car", ProductionYear = 11 },
                    new Car { IdCar = 2, name = "car2", ProductionYear = 12 });
            }
            );

            modelBuilder.Entity<Insception>(opt =>
            {
                opt.HasData(
                    new Insception { IdCar = 1, IdInsception = 1 ,IdMechanic=1,  Comment= "comment1", InsceptionDate=DateTime.Now },
                    new Insception { IdCar = 2, IdInsception = 2 , IdMechanic = 2,  Comment = "comment2", InsceptionDate = DateTime.Now });
            }
            );

            modelBuilder.Entity<Mechanic>(opt =>
            {
                opt.HasData(
                    new Mechanic { IdMechanic = 1, FirstName = "Name1", LastName = "LastName1"},
                    new Mechanic { IdMechanic = 2, FirstName = "Name2", LastName = "LastName2"});
            }
            );

            modelBuilder.Entity<ServiceTypeDict>(opt =>
            {
                opt.HasData(
                    new ServiceTypeDict { IdServiceType = 1, ServiceType = "servicetype1", Price = 11 },
                    new ServiceTypeDict { IdServiceType = 2, ServiceType = "servicetype2", Price=22 });
            }
            );

            modelBuilder.Entity<ServiceTypeDictInsception>(opt =>
            {

                opt.HasData(
                    new ServiceTypeDictInsception { IdInsception = 1, IdServiceType = 1, Comments = "Description1" },
                    new ServiceTypeDictInsception { IdInsception = 2, IdServiceType = 2, Comments = "Description2"});
            }
            );
        }
    }
}