using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using BLL.Models;

namespace BLL
{
    public class MethodsBLL
    {
        private readonly Methods _dal = new Methods(); //створюємо екземпляр DAL

        public UserDTO ValidateUser(string login, string password)
        {
            User user = _dal.ValidateUser(login, password);
            UserDTO userDTO = null;
            if (user != null)
            {
                userDTO = new UserDTO();
                userDTO.Login = user.Login;
                userDTO.Password = user.Password;
                userDTO.Id = user.Id;
                userDTO.Ballance = user.Ballance;
            }
            return userDTO;
        }

        public void AddUser(UserDTO userDTO)
        {
            User user = new User() { Id = userDTO.Id, Ballance = userDTO.Ballance, Login = userDTO.Login, Password = userDTO.Password };
            _dal.AddUser(user);
        }

        public void ModifyUser(UserDTO userDTO)
        {
            User user = new User() { Id = userDTO.Id, Ballance = userDTO.Ballance, Login = userDTO.Login, Password = userDTO.Password };
            _dal.ModifyUser(user);
        }

        public UserDTO GetUser(int id)
        {
            User user = _dal.GetUser(id);
            return new UserDTO() { Ballance = user.Ballance, Login = user.Login, Password = user.Password, Id = user.Id };
        }

        public List<BaseClassDTO> GetBaseParts()
        {
            List<BaseClass> baseclass = _dal.GetBaseParts();
            List<BaseClassDTO> baseclassesDTO = baseclass.Select(x => ConvertBaseClass(x)).ToList();
            return baseclassesDTO;
        }

        public BaseClassDTO ConvertBaseClass(BaseClass baseClass)
        {

            //BaseClassDTO baseClassDTO = null;
            if (baseClass is Engine)
            {
                return ConvertToEngineDTO(baseClass as Engine);
            }
            else if (baseClass is Gearbox)
            {
                return ConvertToGearBoxDTO(baseClass as Gearbox);
            }
            else if (baseClass is Interior)
            {
                return ConvertToInteriorDTO(baseClass as Interior);
            }
            else if (baseClass is Exterior)
            {
                return ConvertToExteriorDTO(baseClass as Exterior);
            }
            return null;
        }

        public EngineDTO ConvertToEngineDTO(Engine engine)
        {
            return new EngineDTO
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
        }

        public GearboxDTO ConvertToGearBoxDTO(Gearbox gearbox)
        {
            return new GearboxDTO
            {
                Id = gearbox.Id,
                Name = gearbox.Name,
                Price = gearbox.Price,
                Producer = gearbox.Producer,
                Quantity = gearbox.Quantity,
                Type = gearbox.Type
            };
        }

        public InteriorDTO ConvertToInteriorDTO(Interior interior)
        {
            return new InteriorDTO
            {
                Id = interior.Id,
                Name = interior.Name,
                Colour = interior.Colour,
                Material = interior.Material,
                Price = interior.Price,
                Producer = interior.Producer
            };
        }

        public ExteriorDTO ConvertToExteriorDTO(Exterior exterior)
        {
            return new ExteriorDTO
            {
                Id = exterior.Id,
                Colour = exterior.Colour,
                Name = exterior.Name,
                Price = exterior.Price,
                Producer = exterior.Producer,
                TypeOfPaint = exterior.TypeOfPaint
            };
        }

        public void AddParts(BaseClassDTO baseClassDTO)
        {
            BaseClass baseClass = null;
            if (baseClassDTO is EngineDTO)
            {
                baseClass = ConvertEngine(baseClassDTO as EngineDTO);
            }
            else if (baseClassDTO is GearboxDTO)
            {
                baseClass = ConvertGearBox(baseClassDTO as GearboxDTO);

            }
            else if (baseClassDTO is InteriorDTO)
            {
                baseClass = ConvertInterior(baseClassDTO as InteriorDTO);

            }
            else if (baseClassDTO is ExteriorDTO)
            {
                baseClass = ConvertExterior(baseClassDTO as ExteriorDTO);

            }
            _dal.AddParts(baseClass);
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

        public void ModifyParts(BaseClassDTO baseClassDTO)
        {
            BaseClass baseClass = null;
            if (baseClassDTO is EngineDTO)
            {
                baseClass = ConvertEngine(baseClassDTO as EngineDTO);
            }
            else if (baseClassDTO is GearboxDTO)
            {
                baseClass = ConvertGearBox(baseClassDTO as GearboxDTO);

            }
            else if (baseClassDTO is InteriorDTO)
            {
                baseClass = ConvertInterior(baseClassDTO as InteriorDTO);

            }
            else if (baseClassDTO is ExteriorDTO)
            {
                baseClass = ConvertExterior(baseClassDTO as ExteriorDTO);

            }
            _dal.ModifyParts(baseClass);
        }

        public void AddCar(CarDTO carDTO)
        {
            Car car = new Car()
            {
                Id = carDTO.Id,
                Name = carDTO.Name,
                Price = carDTO.Price,
                Status = carDTO.Status,
                Engine = ConvertEngine(carDTO.Engine),
                Exterior = ConvertExterior(carDTO.Exterior),
                Interior = ConvertInterior(carDTO.Interior),
                Gearbox = ConvertGearBox(carDTO.Gearbox)
            };
            _dal.AddCar(car);
        }

        public List<CarDTO>GetCars()
        {
            List<Car> listCar = _dal.GetCars();
            List<CarDTO> listcarDTO = listCar.Select(c => ConvertToCarDTO(c)).ToList();
            return listcarDTO;
        }

        public CarDTO ConvertToCarDTO(Car car)
        {
            CarDTO carDTO = new CarDTO()
            {
                Name = car.Name,
                Id = car.Id,
                Price = car.Price,
                Status = car.Status,
                Engine = ConvertToEngineDTO(car.Engine),
                Gearbox = ConvertToGearBoxDTO(car.Gearbox),
                Interior = ConvertToInteriorDTO(car.Interior),
                Exterior = ConvertToExteriorDTO(car.Exterior)
            };
            return carDTO;
        }

        public void SellCar(int id, int userid)
        {
            _dal.SellCar(id, userid);
        }

        public void ModifyCar(CarDTO carDTO)
        {
            Car car = new Car()
            {
                Id = carDTO.Id,
                Name = carDTO.Name,
                Price = carDTO.Price,
                Status = carDTO.Status,
                Engine = ConvertEngine(carDTO.Engine),
                Exterior = ConvertExterior(carDTO.Exterior),
                Interior = ConvertInterior(carDTO.Interior),
                Gearbox = ConvertGearBox(carDTO.Gearbox)
            };
            _dal.ModifyCar(car);
        }

    }
}
