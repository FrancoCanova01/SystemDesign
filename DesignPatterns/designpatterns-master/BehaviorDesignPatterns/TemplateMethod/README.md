https://refactoring.guru/images/patterns/diagrams/template-method/structure-indexed.png

1) The Abstract Class declares methods that act as steps in an algorithm, as well as the template method itself that invokes these methods in a specific order. Steps can be declared abstractosor have a default implementation.

2) The concrete classes can override all the steps, but not the method itself template.
