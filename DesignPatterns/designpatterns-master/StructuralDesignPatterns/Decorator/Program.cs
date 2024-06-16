using System;

namespace Decorator
{
    // The base Component interface defines operations that can be altered by
    // decorators.
    public abstract class Component
    {
        //Los que heredan están obligados a implementar Operation().
        public abstract string Operation();
    }

    // Concrete Components provide default implementations of the operations.
    // There might be several variations of these classes. Este es el "wrapped
    // object", en la pagina el EmailNotifier o el FileDataSource. Es el más 
    // básico sobre el cual se puede "decorar" (agregar funcionalidad)
    class ConcreteComponent : Component
    {
        public override string Operation()
        {
            return "ConcreteComponent";
        }
    }

    // The base Decorator class follows the same interface as the other
    // components. The primary purpose of this class is to define the wrapping
    // interface for all concrete decorators (que implementan ésta clase). 
    // The default implementation of the wrapping code might include a field 
    // for storing a wrapped component and the means to initialize it.
    abstract class Decorator : Component
    {
        // El componente/objeto a ser wrapped que podría ser o bien 
        // un ConcreteComponent o bien otro decorator ... por eso 
        // el tipo de este field es Component (la interfaz común)
        protected Component _component;

        public Decorator(Component component)
        {
            this._component = component;
        }

        public void SetComponent(Component component)
        {
            this._component = component;
        }

        // The Decorator delegates all work to the wrapped component.
        public override string Operation()
        {
            if (this._component != null)
            {
                //si es otro decorator entonces llama a esta misma funcion
                //y si es un ConcreteComponent saldría impreso "ConcreteComponent"
                return this._component.Operation();
            }
            else
            {
                return string.Empty;
            }
        }
    }

    // Concrete Decorators call the wrapped object and alter its result in some
    // way.
    class ConcreteDecoratorA : Decorator
    {
        //Toma un componente como parámetro y llama a Decorator pasandole
        //dicho componente como parámetro a ser guardado en _component
        public ConcreteDecoratorA(Component comp) : base(comp)
        {
        }

        // Decorators may call parent implementation of the operation, instead
        // of calling the wrapped object directly. This approach simplifies
        // extension of decorator classes.
        public override string Operation()
        {
            return $"ConcreteDecoratorA({base.Operation()})";
        }
    }

    // PREGUNTAR
    // Decorators can execute their behavior either before or after the call to
    // a wrapped object.
    class ConcreteDecoratorB : Decorator
    {
        public ConcreteDecoratorB(Component comp) : base(comp)
        {
        }

        public override string Operation()
        {
            return $"ConcreteDecoratorB({base.Operation()})";
        }
    }
    
    public class Client
    {
        // The client code works with all objects using the Component interface.
        // This way it can stay independent of the concrete classes of
        // components it works with.
        public void ClientCode(Component component)
        {
            Console.WriteLine("RESULT: " + component.Operation());
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            var simple = new ConcreteComponent();
            Console.WriteLine("Client: I get a simple component:");
            client.ClientCode(simple);
            Console.WriteLine();

            // ...as well as decorated ones.
            //
            // Note how decorators can wrap not only simple components but the
            // other decorators as well.
            ConcreteDecoratorA decorator1 = new ConcreteDecoratorA(simple);
            ConcreteDecoratorB decorator2 = new ConcreteDecoratorB(decorator1);
            Console.WriteLine("Client: Now I've got a decorated component:");
            client.ClientCode(decorator2);
        }
    }
}
