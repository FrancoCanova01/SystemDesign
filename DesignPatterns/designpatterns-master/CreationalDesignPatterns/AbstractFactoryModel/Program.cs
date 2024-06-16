using System;

namespace AbstractFactoryModel
{
    /// <summary>
    /// MainApp startup class for Real-World
    /// Abstract Factory Design Pattern.
    /// </summary>  
    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        public static void Main()
        {
        
        //Create and run the African animal world
        //Notar como llama a un AfricaFactory pero el tipo
        //de dicha variable es ContinentFactory. El cliente
        //interactúa solo con dicha clase abstracta
        ContinentFactory africa = new AfricaFactory();
        AnimalWorld world = new AnimalWorld(africa);
        world.RunFoodChain();
 
        // Create and run the American animal world

        ContinentFactory america = new AmericaFactory();
        world = new AnimalWorld(america);
        world.RunFoodChain();
 
        // Wait for user input

        Console.Read();
    }
  }
 
 
    /// <summary>
    /// The 'AbstractFactory' abstract class.
    /// Es la clase con la que interactúa el cliente.
    /// Es una clase abstracta de la cual se 
    /// armarán "ConcreteFactories" (AfricanFactory,
    /// AmericanFactory).
    /// </summary>

    abstract class ContinentFactory
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }
 
    /// <summary>
    /// The 'ConcreteFactory1' class
    /// Son animales Herbivoros y Carnivoros
    /// de Africa 
    /// </summary>

    class AfricaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
        return new Wildebeest();
        }

        public override Carnivore CreateCarnivore()
        {
        return new Lion();
        }
    }
 
    /// <summary>
    /// The 'ConcreteFactory2' class 
    /// Son animales Herbivoros y Carnivoros
    /// de America   
    /// </summary>

    class AmericaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
        return new Bison();
        }
        public override Carnivore CreateCarnivore()
        {
        return new Wolf();
        }
    }
 
    /// <summary>
    /// The 'AbstractProductA' abstract class
    /// Es la clase abstracta (a ser impelmentada/heredada)
    /// por implementaciones de Herbivoros
    /// Analogo a la interfaz "ProductA, ProductB"
    /// </summary>

    abstract class Herbivore
    {
    }
 
    /// <summary>
    /// The 'AbstractProductB' abstract class
    /// Es la clase abstracta (a ser impelmentada/heredada)
    /// por implementaciones de Carnívoros.
    /// Analogo a la interfaz "ProductA, ProductB"
    /// </summary>
    abstract class Carnivore
    {
        public abstract void Eat(Herbivore h);
    }
 
    /// <summary>
    /// The 'ProductA1' class
    /// Implementa/Hereda un Herbívoro
    /// Es un "ConcreteProduct"
    /// </summary>
    class Wildebeest : Herbivore
    {
    }
 
    /// <summary>
    /// The 'ProductB1' class
    /// Implementa/Hereda un Carnívoro
    /// Es un "ConcreteProduct"
    /// </summary>
    class Lion : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Wildebeest

            Console.WriteLine(this.GetType().Name +
            " eats " + h.GetType().Name);
        }
    }
 
    /// <summary>
    /// The 'ProductA2' class
    /// Implementa/Hereda un Herbívoro
    /// Es un "ConcreteProduct"
    /// </summary>
    class Bison : Herbivore
    {
    }
 
    /// <summary>
    /// The 'ProductB2' class
    /// Implementa/Hereda un Carnívoro
    /// Es un "ConcreteProduct"
    /// </summary>
    class Wolf : Carnivore
    {
        public override void Eat(Herbivore h)
        {
        // Eat Bison

             Console.WriteLine(this.GetType().Name +
            " eats " + h.GetType().Name);
        }
    }
 
    /// <summary>
    /// The 'Client' class
    /// Clase llamada en el entry point de la app
    /// Basicamente dependiendo de la factory pasada
    /// esta clase devolverá el Carnivoro/Herbívoro
    /// correspondiente. Se accede a los metodos
    /// de los "ConcreteProducts" por medio de
    /// RunFoodChain, con lo cual el cliente 
    /// ni se entera exactamente que son
    /// Solo llama a AnimalWorld.RunFoodChain 
    /// y AnimalWorld se encarga de llamar a 
    /// los "concreteProducts".
    /// </summary>

    class AnimalWorld

    {
        private Herbivore _herbivore;
        private Carnivore _carnivore;
 
        // Constructor

        public AnimalWorld(ContinentFactory factory)
        {
            _carnivore = factory.CreateCarnivore();
            _herbivore = factory.CreateHerbivore();
        }
 
        public void RunFoodChain()
        {
            _carnivore.Eat(_herbivore);
        }
    }
}