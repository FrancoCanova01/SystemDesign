using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cliente inicializa el servicio al que quiere conectarse
            //El lo que quiere hacer es acceder a GetSpecificRequest().
            Adaptee adaptee = new Adaptee();

            //Cliente usa el Adapter y le pasa la instancia inicializada
            //anteriormente del servicio al que no podría acceder 
            //directamente. Le pasa al Adapter como parametro al 
            //servicio al que quiere conectarse (adaptee).
            ITarget target = new Adapter(adaptee);

            Console.WriteLine("Adaptee interface is incompatible with the client.");
            Console.WriteLine("But with adapter client can call it's method.");

            //Con el adapter, el cliente está llamadno por medio del adapter la función
            //GetRequest() que a su vez llama a GetSpecificRequest() del Adaptee.
            Console.WriteLine(target.GetRequest());
        }
    }


    // The Target defines the domain-specific interface used by the client code.
    public interface ITarget
    {
        string GetRequest();
    }

    // The Adaptee contains some useful behavior, but its interface is
    // incompatible with the existing client code. The Adaptee needs some
    // adaptation before the client code can use it.

    //Este es el "servicio" que desea usar el cliente pero que no puede
    class Adaptee
    {
        public string GetSpecificRequest()
        {
            return "Specific request.";
        }
    }

    // The Adapter makes the Adaptee's interface compatible with the Target's
    // interface. O sea ... el adapter implementa la interfaz declarada para 
    //el usuario (ITarget).
    class Adapter : ITarget
    {
        //Esta es la field que guarda el valor del "servicio"
        //al que quiere conectarse el cliente.
        private readonly Adaptee _adaptee;

        //El constructor
        public Adapter(Adaptee adaptee)
        {
            this._adaptee = adaptee;
        }

        public string GetRequest()
        {
            return $"This is '{this._adaptee.GetSpecificRequest()}'";
        }
    }
}
