https://refactoring.guru/images/patterns/diagrams/builder/structure-indexed.png

1) La interfaz Constructora declara pasos de construcción de producto que todos los tipos de objetos constructores tienen en común.

2) Los Constructores Concretos ofrecen distintas implementaciones de los pasos de construcción. Los constructores concretos pueden crear productos que no siguen la interfaz común.

3) Los Productos son los objetos resultantes. Los productos construidos por distintos objetos constructores no tienen que pertenecer a la misma jerarquía de clases o interfaz.

4) La clase Directora define el orden en el que se invocarán los pasos de construcción, por lo que puedes crear y reutilizar configuraciones específicas de los productos.

5) El Cliente debe asociar uno de los objetos constructores con la clase directora. Normalmente, se hace una sola vez mediante los parámetros del constructor de la clase directora, que utiliza el objeto constructor para el resto de la construcción. No obstante, existe una solución alternativa para cuando el cliente pasa el objeto constructor al método de producción de la clase directora. En este caso, puedes utilizar un constructor diferente cada vez que produzcas algo con la clase directora.

Otras notas:

-> Builder does not require the products to have a common interface ... a diferencia de las Factory y Abstract Factory
