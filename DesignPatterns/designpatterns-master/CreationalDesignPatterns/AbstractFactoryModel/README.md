https://refactoring.guru/images/patterns/diagrams/abstract-factory/structure-indexed.png

1) Los Productos Abstractos declaran interfaces para un grupo de productos diferentes pero relacionados que forman una familia de productos.

2) Los Productos Concretos son implementaciones distintas de productos abstractos agrupados por variantes. Cada producto abstracto (silla/sofá) debe implementarse en todas las variantes dadas (victoriano/moderno).

3) La interfaz Fábrica Abstracta declara un grupo de métodos para crear cada uno de los productos abstractos.

4) Las Fábricas Concretas implementan métodos de creación de la fábrica abstracta. Cada fábrica concreta se corresponde con una variante específica de los productos y crea tan solo dichas variantes de los productos.

5) Aunque las fábricas concretas instancian productos concretos, las firmas de sus métodos de creación deben devolver los productos abstractos correspondientes. De este modo, el código cliente que utiliza una fábrica no se acopla a la variante específica del producto que obtiene de una fábrica. El Cliente puede funcionar con cualquier variante fábrica/producto concreta, siempre y cuando se comunique con sus objetos a través de interfaces abstractas.

Otras Notas:

-> Crear familias enteras de productos sin especificar sus clases concretas.

-> The client code invokes the methods of creating a factory object instead of creating the products directly with a call to the constructor (operator new).
