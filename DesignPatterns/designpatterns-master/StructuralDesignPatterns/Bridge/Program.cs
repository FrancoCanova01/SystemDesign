using System;

namespace Bridge
{
    // The Abstraction defines the interface for the "control" part of the two 
    // class hierarchies. It maintains a reference to an object of the 
    // Implementation hierarchy and delegates all of the real work to this 
    // object. 
    
    //Esta es la clase con la que interactúa el cliente. 
    class Abstraction { 

        protected IImplementation _implementation; 

        //El constructor toma como parametro una implementación en particular.
        //y la deja en una field. Notar que llama a la interfaz IImplementation
        //que será implementada por ConcreteImplementations. IImplementation
        //tiene un solo metodo que es OperationImplementation() que será implementada
        //obligatoriamente en las ConcreteImplementations. 
        public Abstraction (IImplementation implementation) 
        { 
            this . _implementation = implementation; 
        }
        
        //El cliente llamará a una Operation() de la Abstraction. Esta 
        //Operation será la implementada por la _implementation especificada.
        //Es virtual porque puede ser override en alguna extension de esta 
        //clase en caso de ser heredada.
        public virtual string Operation ( ) 
        { 
            //El bridge se ve acá. _implementation está en Abstraction y es 
            //la pasada por el cliente. Y de ella se llama a la interfaz de la
            //implementación de la misma.
            return "Abstract: Base operation with: \n" + _implementation.OperationImplementation();
        } 
    }
        
    // You can extend the Abstraction without changing the Implementation 
    // classes. Como el ejemplo de armar "Controles Remotos" mas avanzados.
    class ExtendedAbstraction : Abstraction 
    { 
        //También toma un implementation y hace exactamente lo mismo que la clase base ...
        //guardarla en una variable protegida.
        public ExtendedAbstraction (IImplementation implementation) : base (implementation) 
        {
        
        } 
        
        //Luego pisa la operación heredada con otra.
        public override string Operation ( ) 
        { 
            //El bridge se ve acá
            return "ExtendedAbstraction: Extended operation with: \n" + base._implementation.OperationImplementation();
        
        } 
    }
     
     
     // The Implementation defines the interface for all implementation classes. 
     // It doesn't have to match the Abstraction's interface. In fact, the two 
     // interfaces can be entirely different. Typically the Implementation 
     // interface provides only primitive operations, while the Abstraction 
     // defines higher-level operations based on those primitives. 
        
     public interface  IImplementation
     { 
         string OperationImplementation(); 
     } 
     
     
    // Each Concrete Implementation corresponds to a specific platform and 
    // implements the Implementation interface using that platform's API. 
     
    class ConcreteImplementationA : IImplementation 
    { 
        public string OperationImplementation() 
        { 
            return "ConcreteImplementationA: The result in platform A. \n" ; 
        } 
    } 
    
    class ConcreteImplementationB : IImplementation 
    { 
        public string OperationImplementation ( ) 
        { 
            return "ConcreteImplementationA: The result in platform B. \n" ; 
            
        } 
    } 
    
    
    class Client { 
        // Except for the initialization phase, where an Abstraction object gets 
        // linked with a specific Implementation object, the client code should 
        // only depend on the Abstraction class. This way the client code can 
        // support any abstraction-implementation combination. 
        public void ClientCode (Abstraction abstraction) 
        { 
            Console.Write(abstraction.Operation()) ; 
        } 
    } 
    
    
    class Program 
    { 
        static void Main ( string [ ] args ) 
        { 
            Client client = new Client (); 
            Abstraction abstraction; 
            
            
            // The client code should be able to work with any pre-configured 
            // abstraction-implementation combination. El cliente por medio de 
            //ClientCode llama a la Operation() que tiene la Abstracción. Desde la
            //Abstracción se resuelve que implementación usar en base a la combinación
            //abstraction-implementation elegida.
            
            abstraction = new Abstraction (new ConcreteImplementationA()); 
            client.ClientCode(abstraction);

            Console.WriteLine();

            abstraction = new ExtendedAbstraction(new ConcreteImplementationB()); 
            client.ClientCode(abstraction); 
        } 
    } 
}