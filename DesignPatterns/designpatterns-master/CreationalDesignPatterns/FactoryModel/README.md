
Format: ![UML] (https://refactoring.guru/images/patterns/diagrams/factory-method/structure-indexed.png)

1) The Product declares the interface, which is common to all objects that the creator class and its subclasses can produce.

2) The Products Concretos are different implementations of the product interface.

3) The Creator class declares the factory method that returns new product objects. It is important that the return type of this method matches the product interface. You can declare the Factory Method pattern as abstract to force all subclasses to implement their own versions of the method. Alternatively, the base factory method can return some kind of product by default. Note that despite its name, product creation is not the primary responsibility of the creative class. Typically this class has some core business logic related to products. The Factory Method pattern helps to decouple this logic from concrete product classes. Here's an analogy: a large software development company may have a programmer training department. However, the main function of the company is still writing code, not training programmers.

4) The Creators Concretos overwrites the Factory Method base, so as to return a different type of product. Note that the factory method does not have to create new instances all the time. It can also return existing objects from a cache, an object pool, or another source.
