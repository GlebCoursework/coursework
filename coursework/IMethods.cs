using coursework.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace coursework
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IMethods
    {
        [OperationContract]
        User ValidateUser(string login, string password);

        [OperationContract]
        void ModifyUser(User user);

        [OperationContract]
        ICollection<BaseParts> GetBaseParts();

        [OperationContract]
        void AddParts(BaseParts baseParts);

        [OperationContract]
        void AddUser(User user);

        [OperationContract]
        void ModifyParts(BaseParts baseParts);

        [OperationContract]
        void AddCar(Car car);

        [OperationContract]
        List<Car> GetCars();

        [OperationContract]
        void SellCar(int id, int userid);
        [OperationContract]
        User GetUser(int id);

        [OperationContract]
        void ModifyCar(Car car);
    }
}
