using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL
{
    public class Methods
    {
        private readonly Dealer _ctx = new Dealer(); //створюємо екземпляр бази данних
        //створення методів для роботи з данними класів

        public User ValidateUser(string login, string password)
        {
            return _ctx.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
        }

        public void AddUser(User user)
        {
            _ctx.Users.Add(user);
            _ctx.SaveChanges();
        }

        public void ModifyUser(User user)
        {
            User user1 = _ctx.Users.First(u => u.Id == user.Id);
            user1.Login = user.Login;
            user1.Password = user.Password;
            user1.Ballance = user.Ballance;
            _ctx.SaveChanges();
        }

        public User GetUser(int id)
        {
            return _ctx.Users.FirstOrDefault(u => u.Id == id);
        }

        public List<BaseClass> GetBaseParts()
        {
            return _ctx.BaseClasses.ToList();
        }

        public void AddParts(BaseClass baseClass)
        {
            _ctx.BaseClasses.Add(baseClass);
            _ctx.SaveChanges();
        }

        public void ModifyParts(BaseClass baseClass)
        {
            if(baseClass is Engine)
            {
                ModifyEngine(baseClass as Engine);
            }

            else if (baseClass is Gearbox)
            {
                ModifyGearBox(baseClass as Gearbox);
            }

            else if (baseClass is Interior)
            {
                ModifyInterior(baseClass as Interior);
            }

            else if (baseClass is Exterior)
            {
                ModifyExterior(baseClass as Exterior);
            }
        }

        public void ModifyEngine(Engine baseClass)
        {
            Engine engine1 = (_ctx.BaseClasses.FirstOrDefault(b => b.Id == baseClass.Id) as Engine);
            engine1.HP = (baseClass as Engine).HP;
            engine1.Liters = (baseClass as Engine).Liters;
            engine1.Cylinders = (baseClass as Engine).Cylinders;
            engine1.Name = (baseClass as Engine).Name;
            engine1.Price = (baseClass as Engine).Price;
            engine1.Producer = (baseClass as Engine).Producer;
            engine1.Torque = (baseClass as Engine).Torque;
            engine1.Type = (baseClass as Engine).Type;
            _ctx.SaveChanges();
        }

        public void ModifyGearBox(Gearbox baseClass)
        {
            Gearbox gearbox1 = (_ctx.BaseClasses.FirstOrDefault(g => g.Id == baseClass.Id) as Gearbox);
            gearbox1.Name = (baseClass as Gearbox).Name;
            gearbox1.Type = (baseClass as Gearbox).Type;
            gearbox1.Price = (baseClass as Gearbox).Price;
            gearbox1.Producer = (baseClass as Gearbox).Producer;
            gearbox1.Quantity = (baseClass as Gearbox).Quantity;
            _ctx.SaveChanges();

        }

        public void ModifyInterior(Interior baseClass)
        {
            Interior interior1 = (_ctx.BaseClasses.FirstOrDefault(i => i.Id == baseClass.Id) as Interior);
            interior1.Name = (baseClass as Interior).Name;
            interior1.Material = (baseClass as Interior).Material;
            interior1.Colour = (baseClass as Interior).Colour;
            interior1.Producer = (baseClass as Interior).Producer;
            interior1.Price = (baseClass as Interior).Price;
            _ctx.SaveChanges();

        }

        public void ModifyExterior(Exterior baseClass)
        {
            Exterior exterior1 = (_ctx.BaseClasses.FirstOrDefault(e => e.Id == baseClass.Id) as Exterior);
            exterior1.Name = (baseClass as Exterior).Name;
            exterior1.Price = (baseClass as Exterior).Price;
            exterior1.TypeOfPaint = (baseClass as Exterior).TypeOfPaint;
            exterior1.Producer = (baseClass as Exterior).Producer;
            _ctx.SaveChanges();

        }

        public void AddCar(Car car)
        {
            car.Engine = _ctx.BaseClasses.FirstOrDefault(e => e.Id == car.Engine.Id) as Engine;
            car.Gearbox = _ctx.BaseClasses.FirstOrDefault(g => g.Id == car.Gearbox.Id) as Gearbox;
            car.Interior = _ctx.BaseClasses.FirstOrDefault(i => i.Id == car.Interior.Id) as Interior;
            car.Exterior = _ctx.BaseClasses.FirstOrDefault(e => e.Id == car.Exterior.Id) as Exterior;
            _ctx.Cars.Add(car);
            _ctx.SaveChanges();
        }

        public void ModifyCar(Car car)
        {
            Car newcar = _ctx.Cars.First(x => x.Id == car.Id);
            newcar.Name = car.Name;
            newcar.Price = car.Price;
            newcar.Engine = _ctx.BaseClasses.FirstOrDefault(e => e.Id == car.Engine.Id) as Engine;
            newcar.Gearbox = _ctx.BaseClasses.FirstOrDefault(g => g.Id == car.Gearbox.Id) as Gearbox;
            newcar.Interior = _ctx.BaseClasses.FirstOrDefault(i => i.Id == car.Interior.Id) as Interior;
            newcar.Exterior = _ctx.BaseClasses.FirstOrDefault(e => e.Id == car.Exterior.Id) as Exterior;
            _ctx.SaveChanges();          
        }

        public List<Car> GetCars()
        {
            return _ctx.Cars.ToList();
        }

        public void SellCar(int id, int userid)
        {
            Car car1 = _ctx.Cars.FirstOrDefault(c => c.Id == id);
            car1.Status = "Sold";
            _ctx.Users.FirstOrDefault(u => u.Id == userid).Ballance += car1.Price;
            _ctx.SaveChanges();
        }

        
    }
}
