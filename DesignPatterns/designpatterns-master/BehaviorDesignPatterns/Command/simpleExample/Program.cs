/*1) The Sender (or invoker ) class is responsible for initializing requests. 
This class must have a field to store a reference to a command object. The 
sender triggers this command instead of sending the request directly to the 
receiver. Note that the issuer is not responsible for creating the command object. 
Typically you get a pre-created command from the client through the constructor.

2) The Command interface typically declares a single method to execute the command.

3) The Commandos Concretos implement various types of applications. 
A specific command is not supposed to do the work on its own, but 
to pass the call to one of the business logic objects. However, to simplify 
the code, these classes can be merged. The parameters required to execute a 
method on a receiver object can be declared as fields in the concrete command. 
You can make command objects immutable by allowing initialization of these fields 
only through the constructor.

4) The Receiver class contains some business logic. Almost any object can act 
as a receiver. Most commands only handle the details about how a request is passed 
to the receiver, while the receiver itself does the actual work.

5) The Client creates and configures the specific command objects. The client 
must pass all the request parameters, including a receiver instance, into the 
command's constructor. After that, the resulting command can be associated with 
one or more emitters.
*/

using System;

namespace Command
{
    // The Command interface declares a method for executing a command.
    // Los "Commands" implementan esta interfaz
    public interface ICommand
    {
        void Execute();
    }

    // Some commands can implement simple operations on their own. 
    // ie: no necesitan estar vinculados con un receiver
    class SimpleCommand : ICommand
    {
        private string _payload = string.Empty;

        public SimpleCommand(string payload)
        {
            this._payload = payload;
        }

        public void Execute()
        {
            Console.WriteLine($"SimpleCommand: See, I can do simple things like printing ({this._payload})");
        }
    }

    // However, some commands can delegate more complex operations to other
    // objects, called "receivers." (los tienen como field). Acá el cliente
    // le pasará mas informacion para poder usar este "receiver". In general
    // commands only handle the details about how a request is passed to the 
    // receiver, while the receiver itself does the actual work. Fijate como 
    // este comando no ejecuta nada si no que hace de "pasamano" entre cliente
    // y reciever. 
    class ComplexCommand : ICommand
    {
        private Receiver _receiver;

        // Context data, required for launching the receiver's methods.
        private string _a;

        private string _b;

        // Complex commands can accept one or several receiver objects along
        // with any context data via the constructor.
        public ComplexCommand(Receiver receiver, string a, string b)
        {
            this._receiver = receiver;
            this._a = a;
            this._b = b;
        }

        // Commands can delegate to any methods of a receiver.
        public void Execute()
        {
            Console.WriteLine("ComplexCommand: Complex stuff should be done by a receiver object.");
            this._receiver.DoSomething(this._a);
            this._receiver.DoSomethingElse(this._b);
        }
    }

    // The Receiver classes contain some important business logic. They know how
    // to perform all kinds of operations, associated with carrying out a
    // request. In fact, any class may serve as a Receiver.
    class Receiver
    {
        public void DoSomething(string a)
        {
            Console.WriteLine($"Receiver: Working on ({a}.)");
        }

        public void DoSomethingElse(string b)
        {
            Console.WriteLine($"Receiver: Also working on ({b}.)");
        }
    }

    // The Invoker (o Sender) is associated with one or several commands. It sends a
    // request to the command. Its responsible for initializing requests.
    // Se comunica con los commands por medio de la interfaz común (ICommand).
    // El cliente se comuncia con el invoker para ejecutar comandos (el cliente
    // es el responsable de darle al invoker el comando como parametro).
    class Invoker
    {
        
        private ICommand _onStart;

        private ICommand _onFinish;

        // Initialize commands.
        public void SetOnStart(ICommand command)
        {
            this._onStart = command;
        }

        public void SetOnFinish(ICommand command)
        {
            this._onFinish = command;
        }

        // The Invoker does not depend on concrete command or receiver classes.
        // The Invoker passes a request to a receiver indirectly, by executing a
        // command.
        public void DoSomethingImportant()
        {
            Console.WriteLine("Invoker: Does anybody want something done before I begin?");
            if (this._onStart is ICommand)
            {
                this._onStart.Execute();
            }
            
            Console.WriteLine("Invoker: ...doing something really important...");
            
            Console.WriteLine("Invoker: Does anybody want something done after I finish?");
            if (this._onFinish is ICommand)
            {
                this._onFinish.Execute();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // The client code can parameterize an invoker with any commands.
            Invoker invoker = new Invoker();
            invoker.SetOnStart(new SimpleCommand("Say Hi!"));
            Receiver receiver = new Receiver();
            invoker.SetOnFinish(new ComplexCommand(receiver, "Send email", "Save report"));

            invoker.DoSomethingImportant();
        }
    }
}