namespace DAL
{
    using DAL.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Dealer : DbContext
    {
        public Dealer() //створюємо таблиці в базі данних
            : base("name=Dealer")
        {
            Database.SetInitializer<Dealer>(new CustomInitializer<Dealer>());
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<BaseClass> BaseClasses { get; set; }
        public virtual DbSet<User> Users { get; set; }

    }

}