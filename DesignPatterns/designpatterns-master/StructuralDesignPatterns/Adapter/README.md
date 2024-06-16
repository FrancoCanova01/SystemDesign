https://refactoring.guru/images/patterns/diagrams/adapter/structure-object-adapter-indexed.png

1) The Customer class contains the existing business logic of the program.

2) The Client Interface describes a protocol that other classes must follow in order to collaborate with client code.

3) Service is some useful class (usually third party or inherited). The client cannot directly use this class because it has an incompatible interface.

4) The Adapter class is able to work with both the client class and the service class: it implements the interface with the client, while wrapping the object of the service class. The adapter class receives calls from the client through the adapter interface and translates them into calls to the wrapped object of the service class, but in a format that it can understand.

5) Client code does not bind to the concrete adapter class as long as it works with the adapter class through the client interface. Thanks to this, you can introduce new types of adapters into the program without breaking down the existing client code. This can be useful when the interface of the service class is changed or replaced, since you can create a new adapter class without changing the client code.
