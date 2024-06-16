https://refactoring.guru/images/patterns/diagrams/decorator/structure-indexed.png

1) The Component declares the common interface for both wrappers and wrapped objects.

2) Concrete Component is a class of wrapped objects. Defines basic behavior, which decorators can alter.

3) The Base Decorator class has a field to reference a wrapped object. The field's type must be declared as the component's interface so that it can contain both concrete components and decorators. The base decorator class delegates all operations to the wrapped object.

4) The Decoradores Concretos define additional features that can be dynamically added to the components. Concrete decorators override methods of the base decorator class and execute their behavior, either before or after invoking the parent method.

5) The Customer can wrap in several layers of components decorators, provided they work with all objects through the interface component.
