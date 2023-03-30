using System;
using System.Collections.Generic;

namespace dz_28._03
{
    abstract class Military
    {
        public string Image { get; set; }
        public int Speed { get; set; }
        public int Power { get; set; }
        public abstract void Show(int a, int b);
    }
    class LightInfantry : Military
    {
        public LightInfantry()
        {
            Image = "light_infantry.png";
            Speed = 20;
            Power = 10;
        }

        public override void Show(int a, int b)
        {
            Console.WriteLine($"Light Infantry ({a}, {b})");
        }
    }

    class TransportVehicle : Military
    {
        public TransportVehicle()
        {
            Image = "transport_vehicle.png";
            Speed = 70;
            Power = 0;
        }

        public override void Show(int a, int b)
        {
            Console.WriteLine($"Transport Vehicle ({a}, {b})");
        }
    }

    class HeavyGroundVehicle : Military
    {
        public HeavyGroundVehicle()
        {
            Image = "heavy_ground_vehicle.png";
            Speed = 15;
            Power = 150;
        }

        public override void Show(int a, int b)
        {
            Console.WriteLine($"Heavy Ground Vehicle ({a}, {b})");
        }
    }

    class LightGroundVehicle : Military
    {
        public LightGroundVehicle()
        {
            Image = "light_ground_vehicle.png";
            Speed = 50;
            Power = 30;
        }

        public override void Show(int a, int b)
        {
            Console.WriteLine($"Light Ground Vehicle ({a}, {b})");
        }
    }

    class Aircraft : Military
    {
        public Aircraft()
        {
            Image = "aircraft.png";
            Speed = 300;
            Power = 100;
        }

        public override void Show(int a, int b)
        {
            Console.WriteLine($"Aircraft ({a}, {b})");
        }
    }

    class MilitaryFactory
    {
        private Dictionary<string, Military> units = new Dictionary<string, Military>();

        public Military GetUnit(string type)
        {
            if (units.ContainsKey(type))
            {
                return units[type];
            }
            else
            {
                Military unit;
                switch (type)
                {
                    case "light_infantry":
                        unit = new LightInfantry();
                        break;
                    case "transport_vehicle":
                        unit = new TransportVehicle();
                        break;
                    case "heavy_ground_vehicle":
                        unit = new HeavyGroundVehicle();
                        break;
                    case "light_ground_vehicle":
                        unit = new LightGroundVehicle();
                        break;
                    case "aircraft":
                        unit = new Aircraft();
                        break;
                    default:
                        throw new ArgumentException("Invalid unit type");
                }
                units.Add(type, unit);
                return unit;
            }
        }
    }

    class Map
    {
        private MilitaryFactory factory = new MilitaryFactory();

        public void AddUnit(string type, int a, int b)
        {
            Military unit = factory.GetUnit(type);
            unit.Show(a, b);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map();
            map.AddUnit("Light infantry", 10, 10);
            map.AddUnit("Light ground vehicle", 50, 50);
            map.AddUnit("Heavy ground vehicle", 100, 100);
            map.AddUnit("Transport vehicle", 150, 150);
            map.AddUnit("Aircraft", 200, 200);
        }
    }
}
