https://refactoring.guru/images/patterns/diagrams/bridge/structure-es-indexed.png

1) The abstraction provides control logic high level. It depends on the implementation object doing the low-level work.

2) The Implementation declares the interface common to all concrete implementations. An abstraction can only communicate with an implementation object through the methods that are declared here. The abstraction can enumerate the same methods as the implementation, but typically the abstraction declares complex functionalities that depend on a wide variety of primitive operations declared by the implementation.

3) The Implementations Concretas contain platform - specific code.

4) The Abstractions Finer provide variants of control logic. Like their parents, they work with different implementations through the general implementation interface.

5) Typically the Client is only interested in working with the abstraction. However, the client has to bind the abstraction object to one of the implementation objects.
