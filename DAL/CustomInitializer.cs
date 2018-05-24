using DAL.Models;
using System.Data.Entity;

namespace DAL
{
    internal class CustomInitializer<T> : DropCreateDatabaseIfModelChanges<Dealer>
    {
        protected override void Seed(Dealer context)
        {
            User user = new User() { Login = "aaa", Password = "aaa", Ballance = 100000 };
            context.Users.Add(user);

            Engine engine = new Engine { Cylinders = 6, HP = 218, Liters = 3, Name = "M57TU", Price = 2000, Producer = "BMW", Torque = 500, Type = "Diesel" };
            context.BaseClasses.Add(engine);

            Gearbox gearbox = new Gearbox { Name = "6HP26", Price = 1000, Producer = "ZF", Quantity = 6, Type = "Automatic" };
            context.BaseClasses.Add(gearbox);

            Interior interior = new Interior { Colour = "Black", Material = "Leather", Price = 1500, Producer = "BMW", Name = "" };
            context.BaseClasses.Add(interior);

            Exterior exterior = new Exterior { Colour = "Black", Name = "", Price = 1000, Producer = "BMW", TypeOfPaint = "Glossy" };
            context.BaseClasses.Add(exterior);

            Car car = new Car { Engine = engine, Exterior = exterior, Interior = interior, Name = "BMW X5", Price = 5000, Gearbox = gearbox, Status = "Not sold" };
            context.Cars.Add(car);

            context.SaveChanges();
            
        }
    }
}