https://refactoring.guru/images/patterns/diagrams/command/structure-indexed.png

1) The Sender (or invoker ) class is responsible for initializing requests. This class must have a field to store a reference to a command object. The sender triggers this command instead of sending the request directly to the receiver. Note that the issuer is not responsible for creating the command object. Typically you get a pre-created command from the client through the constructor.

2) The Command interface typically declares a single method to execute the command.

3) The Commandos Concretos implement various types of applications. A specific command is not supposed to do the work on its own, but to pass the call to one of the business logic objects. However, to simplify the code, these classes can be merged. The parameters required to execute a method on a receiver object can be declared as fields in the concrete command. You can make command objects immutable by allowing initialization of these fields only through the constructor.

4) The Receiver class contains some business logic. Almost any object can act as a receiver. Most commands only handle the details about how a request is passed to the receiver, while the receiver itself does the actual work.

5) The Client creates and configures the specific command objects. The client must pass all the request parameters, including a receiver instance, into the command's constructor. After that, the resulting command can be associated with one or more emitters.
