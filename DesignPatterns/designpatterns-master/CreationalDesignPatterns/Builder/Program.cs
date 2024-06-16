using System;
using System.Collections.Generic;

//This real-world code demonstates the Builder pattern in which 
//different vehicles are assembled in a step-by-step fashion. The Shop uses 
//VehicleBuilders to construct a variety of Vehicles in a series of sequential steps.

namespace Builder
{
    
    /// <summary>
    /// MainApp startup class for Real-World 
    /// Builder Design Pattern.
    /// </summary>

    public class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        public static void Main()
        {
            //notar como VehicleBuilder es la
            // interfaz que implementará cada
            // "ConcreteBuilder"
            VehicleBuilder builder;
 
            // Create shop with vehicle builders
            // Este vendría a ser el "Director"
            // Se le pide a él que dirija 
            // la creacion del objeto con ayuda
            // del builder
            Shop shop = new Shop();
 
            // Construct and display vehicles
            // el cliente elige que builder quiere
            // (notar que llama a ScooterBuilder y builder
            // es del tipo VehicleBuilder) y le pasa ese
            // builder al "Director" Shop. Otra cosa importante
            // a notar es que el cliente recibe los resultados
            // de la creación del objeto por medio del builder
            builder = new ScooterBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();
 
            builder = new CarBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();
 
            builder = new MotorCycleBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();
 
            // Wait for user

            Console.Read();
        }
    }
 
    /// <summary>
    /// The 'Director' class
    /// </summary>
    class Shop
    {
        // Builder uses a complex series of steps
        // El constructor del Director toma un builder
        // del tipo que desea el cliente. El Director
        // aplica step-by-step construction.
        public void Construct(VehicleBuilder vehicleBuilder)
        {
            vehicleBuilder.BuildFrame();
            vehicleBuilder.BuildEngine();
            vehicleBuilder.BuildWheels();
            vehicleBuilder.BuildDoors();
        }
    }
 
    /// <summary>
    /// The 'Builder' abstract class
    /// Será implementada por los "ConcreteBuilders"
    /// de cada tipo de vehículo
    /// </summary>

     abstract class VehicleBuilder
    {
        protected Vehicle vehicle;
 
        // Gets vehicle instance. Esto es común a todo builder
        // Deben tener un metodo para extraer el resultado
        // del build

        public Vehicle Vehicle
        {
            get { return vehicle; }
        }
 
        // Abstract build methods. Serán pisadas por
        // cada subclase que herede VehicleBuilder

        public abstract void BuildFrame();
        public abstract void BuildEngine();
        public abstract void BuildWheels();
        public abstract void BuildDoors();
    }
 
    /// <summary>
    /// The 'ConcreteBuilder1' class
    /// </summary>
    class MotorCycleBuilder : VehicleBuilder

    {
        //El constructor
        public MotorCycleBuilder()
        {
            //Al heredar de VehicleBuilder, vehicle ya está definido
            // y es del tipo Vehicle
            vehicle = new Vehicle("MotorCycle");
        }
 
        //Se hace override los metodos abstractos de la base
        //class con lo específico para MotorCycleBuilder. Notar como
        //se acceden a fields de vehicles (el unico "Producto"
        //que se maneja). Recordar que una diferencia de este 
        //patron respecto a los anteriores es que los productos
        //no deben seguir una interfaz común.
        public override void BuildFrame()
        {
            vehicle["frame"] = "MotorCycle Frame";
        }
 
        public override void BuildEngine()
        {
            vehicle["engine"] = "500 cc";
        }
 
        public override void BuildWheels()
        {
            vehicle["wheels"] = "2";
        }
 
        public override void BuildDoors()
        {
            vehicle["doors"] = "0";
        }
    }
 
 
    /// <summary>
    /// The 'ConcreteBuilder2' class
    /// </summary>

    class CarBuilder : VehicleBuilder
    {
        //Al heredar de VehicleBuilder, vehicle ya está definido
        // y es del tipo Vehicle
        public CarBuilder()
        {
            vehicle = new Vehicle("Car");
        }
 
        //Se hace override los metodos abstractos de la base
        //class con lo específico para CarBuilder. Notar como
        //se acceden a fields de vehicles (el unico "Producto"
        //que se maneja). Recordar que una diferencia de este 
        //patron respecto a los anteriores es que los productos
        //no deben seguir una interfaz común.

        public override void BuildFrame()
        {
            vehicle["frame"] = "Car Frame";
        }
 
        public override void BuildEngine()
        {
            vehicle["engine"] = "2500 cc";
        }
 
        public override void BuildWheels()
        {
            vehicle["wheels"] = "4";
        }
 
        public override void BuildDoors()
        {
            vehicle["doors"] = "4";
        }
    }
 
    /// <summary>
    /// The 'ConcreteBuilder3' class
    /// </summary>

    class ScooterBuilder : VehicleBuilder
    {
        // Al heredar de VehicleBuilder, vehicle ya está definido
        // y es del tipo Vehicle
        public ScooterBuilder()
        {
            vehicle = new Vehicle("Scooter");
        }
 
        //Se hace override los metodos abstractos de la base
        //class con lo específico para ScooterBuilder. Notar como
        //se acceden a fields de vehicles (el unico "Producto"
        //que se maneja). Recordar que una diferencia de este 
        //patron respecto a los anteriores es que los productos
        //no deben seguir una interfaz común.

        public override void BuildFrame()
        {
            vehicle["frame"] = "Scooter Frame";
        }
    
        public override void BuildEngine()
        {
            vehicle["engine"] = "50 cc";
        }
 
        public override void BuildWheels()
        {
            vehicle["wheels"] = "2";
        }
 
        public override void BuildDoors()
        {
            vehicle["doors"] = "0";
        }
    }
 
    /// <summary>
    /// The 'Product' class
    /// Notar que es una sola "ProductClass" y 
    /// no se sacan sublclases ni se implementan interfaces
    /// Simplemente se usa para todos los casos este producto
    /// vehicles pero en muchas variantes
    /// </summary>
    class Vehicle
    {
        private string _vehicleType;
        private Dictionary<string,string> _parts = new Dictionary<string,string>();
 
        // Constructor. Se le pasa el tipo de vehículo que se quiere
        public Vehicle(string vehicleType)
        {
            this._vehicleType = vehicleType;
        }
 
        // Indexer
        //Esto es accedido por todos los Builders
        //y modificado dependiendo del tipo de vehículo.
        //Sería interesante que los "keys" sean comunes 
        //o se busque la manera de centralizarlo pues
        //puede traer problemas a la hora de imprimir los 
        //valores. No delegar esa tarea a los Builders 
        //podría solucionar esto.
        public string this[string key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }
 
        public void Show()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("Vehicle Type: {0}", _vehicleType);
            Console.WriteLine(" Frame : {0}", _parts["frame"]);
            Console.WriteLine(" Engine : {0}", _parts["engine"]);
            Console.WriteLine(" #Wheels: {0}", _parts["wheels"]);
            Console.WriteLine(" #Doors : {0}", _parts["doors"]);
        }
    }
}
