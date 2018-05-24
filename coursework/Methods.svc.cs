using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using coursework.DataContracts;
using BLL;
using BLL.Models;

namespace coursework
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IMethods
    {
        private readonly MethodsBLL _bll = new MethodsBLL();
        public void AddCar(Car car)
        {
            CarDTO carDTO = new CarDTO()
            {
                Name = car.Name,
                Status = car.Status,
                Price = car.Price,
                Engine = ConvertToEngineDTO(car.Engine),
                Gearbox = ConvertTOGearboxDTO(car.Gearbox),
                Exterior = ConvertTOExteriorDTO(car.Exterior),
                Interior = ConvertTOInteriorDTO(car.Interior)
            };
            _bll.AddCar(carDTO);
        }

        public void AddUser(User user)
        {
            UserDTO userDTO = new UserDTO() { Id = user.Id, Ballance = user.Balance, Login = user.Login, Password = user.Password };
            _bll.AddUser(userDTO);
        }
        public EngineDTO ConvertToEngineDTO(Engine engine)
        {
            EngineDTO engineDTO = new EngineDTO()
            {
                Id = engine.Id,
                Cylinders = engine.Cylinders,
                HP = engine.HP,
                Liters = engine.Liters,
                Name = engine.Name,
                Price = engine.Price,
                Producer = engine.Producer,
                Torque = engine.Torque,
                Type = engine.Type
            };

            return engineDTO;
        }

        public GearboxDTO ConvertTOGearboxDTO(Gearbox gearbox)
        {
            GearboxDTO gearboxDTO = new GearboxDTO()
            {
                Id = gearbox.Id,
                Name = gearbox.Name,
                Price = gearbox.Price,
                Producer = gearbox.Producer,
                Quantity = gearbox.Quantity,
                Type = gearbox.Type
            };
            return gearboxDTO;
        }

        public InteriorDTO ConvertTOInteriorDTO(Interior interior)
        {
            InteriorDTO interiorDTO = new InteriorDTO()
            {
                Id = interior.Id,
                Name = interior.Name,
                Colour = interior.Colour,
                Material = interior.Material,
                Price = interior.Price,
                Producer = interior.Producer
            };
            return interiorDTO;
        }

        public ExteriorDTO ConvertTOExteriorDTO(Exterior exterior)
        {
            ExteriorDTO exteriorDTO = new ExteriorDTO()
            {
                Id = exterior.Id,
                Colour = exterior.Colour,
                Price = exterior.Price,
                Producer = exterior.Producer,
                TypeOfPaint = exterior.TypeOfPaint
            };
            return exteriorDTO;
        }
        public void AddParts(BaseParts baseParts)
        {
            BaseClassDTO baseClassDTO = null;
            if (baseParts is Engine)
            {
                baseClassDTO = ConvertToEngineDTO(baseParts as Engine);
            }
            else if (baseParts is Gearbox)
            {
                baseClassDTO = ConvertTOGearboxDTO(baseParts as Gearbox);
            }
            else if (baseParts is Interior)
            {
                baseClassDTO = ConvertTOInteriorDTO(baseParts as Interior);
            }
            else if (baseParts is Exterior)
            {
                baseClassDTO = ConvertTOExteriorDTO(baseParts as Exterior);
            }
            _bll.AddParts(baseClassDTO);
        }
        public ICollection<BaseParts> GetBaseParts()
        {
            List<BaseClassDTO> BaseClassDTOList = _bll.GetBaseParts();

            List<BaseParts> BaseParts = BaseClassDTOList.Select(p => ConvertoToBaseParts(p)).ToList();
            return BaseParts;
        }
        public List<Car> GetCars()
        {
            List<CarDTO> ListCarDTO = _bll.GetCars();
            List<Car> ListCar = ListCarDTO.Select(c => ConvertToCar(c)).ToList();
            return ListCar;
        }

        public BaseParts ConvertoToBaseParts(BaseClassDTO baseClassDTO)
        {


            //BaseParts baseParts = null;
            if (baseClassDTO is EngineDTO)
            {
                return ConvertEngine(baseClassDTO as EngineDTO);
            }
            else if (baseClassDTO is GearboxDTO)
            {
                return ConvertGearBox(baseClassDTO as GearboxDTO);
            }
            else if (baseClassDTO is InteriorDTO)
            {
                return ConvertInterior(baseClassDTO as InteriorDTO);
            }
            else if (baseClassDTO is ExteriorDTO)
            {
                return ConvertExterior(baseClassDTO as ExteriorDTO);
            }
            return null;
        }
        public Car ConvertToCar(CarDTO carDTO)
        {
            Car car = new Car()
            {
                Name = carDTO.Name,
                Id = carDTO.Id,
                Price = carDTO.Price,
                Status = carDTO.Status,
                Engine = ConvertEngine(carDTO.Engine),
                Gearbox = ConvertGearBox(carDTO.Gearbox),
                Interior = ConvertInterior(carDTO.Interior),
                Exterior = ConvertExterior(carDTO.Exterior)
            };
            return car;
        }
        public Engine ConvertEngine(EngineDTO engineDTO)
        {
            return new Engine
            {
                Id = engineDTO.Id,
                Cylinders = engineDTO.Cylinders,
                HP = engineDTO.HP,
                Liters = engineDTO.Liters,
                Name = engineDTO.Name,
                Price = engineDTO.Price,
                Producer = engineDTO.Producer,
                Torque = engineDTO.Torque,
                Type = engineDTO.Type
            };
        }
        public Gearbox ConvertGearBox(GearboxDTO gearboxDTO)
        {
            return new Gearbox
            {
                Id = gearboxDTO.Id,
                Name = gearboxDTO.Name,
                Price = gearboxDTO.Price,
                Producer = gearboxDTO.Producer,
                Quantity = gearboxDTO.Quantity,
                Type = gearboxDTO.Type
            };
        }
        public Interior ConvertInterior(InteriorDTO interiorDTO)
        {
            return new Interior
            {
                Id = interiorDTO.Id,
                Name = interiorDTO.Name,
                Colour = interiorDTO.Colour,
                Material = interiorDTO.Material,
                Price = interiorDTO.Price,
                Producer = interiorDTO.Producer
            };
        }
        public Exterior ConvertExterior(ExteriorDTO exteriorDTO)
        {
            return new Exterior
            {
                Id = exteriorDTO.Id,
                Colour = exteriorDTO.Colour,
                Name = exteriorDTO.Name,
                Price = exteriorDTO.Price,
                Producer = exteriorDTO.Producer,
                TypeOfPaint = exteriorDTO.TypeOfPaint
            };
        }
        public void ModifyParts(BaseParts baseParts)
        {
            BaseClassDTO baseClassDTO = null;
            if (baseParts is Engine)
            {
                baseClassDTO = ConvertToEngineDTO(baseParts as Engine);
            }
            else if (baseParts is Gearbox)
            {
                baseClassDTO = ConvertTOGearboxDTO(baseParts as Gearbox);
            }
            else if (baseParts is Interior)
            {
                baseClassDTO = ConvertTOInteriorDTO(baseParts as Interior);
            }
            else if (baseParts is Exterior)
            {
                baseClassDTO = ConvertTOExteriorDTO(baseParts as Exterior);
            }
            _bll.ModifyParts(baseClassDTO);
        }
        public void ModifyUser(User user)
        {
            UserDTO userDTO = new UserDTO()
            {
                Id = user.Id,
                Ballance = user.Balance,
                Login = user.Login,
                Password = user.Password
            };
            _bll.ModifyUser(userDTO);
        }

        public User GetUser(int id)
        {
            UserDTO userDTO = _bll.GetUser(id);
            return new User() { Balance = userDTO.Ballance, Login = userDTO.Login, Password = userDTO.Password, Id = userDTO.Id };
        }
        public void SellCar(int id, int userid)
        {
            _bll.SellCar(id, userid);
        }
        public User ValidateUser(string login, string password)
        {
            UserDTO userDTO = _bll.ValidateUser(login, password);
            User user = null;
            if (userDTO != null)
            {
                user = new User();
                user.Id = userDTO.Id;
                user.Login = userDTO.Login;
                user.Balance = userDTO.Ballance;
                user.Password = userDTO.Password;
            }
            return user;
        }

        public void ModifyCar(Car car)
        {
            CarDTO carDTO = new CarDTO()
            {
                Id = car.Id,
                Name = car.Name,
                Status = car.Status,
                Price = car.Price,
                Engine = ConvertToEngineDTO(car.Engine),
                Gearbox = ConvertTOGearboxDTO(car.Gearbox),
                Exterior = ConvertTOExteriorDTO(car.Exterior),
                Interior = ConvertTOInteriorDTO(car.Interior)
            };
            _bll.ModifyCar(carDTO);
        }
    }
}
