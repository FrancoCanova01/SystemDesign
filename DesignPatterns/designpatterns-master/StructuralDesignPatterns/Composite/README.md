https://refactoring.guru/images/patterns/diagrams/composite/structure-es-indexed.png

1) The Component interface describes operations that are common to simple and complex elements of the tree.

2) The Leaf is a basic element of a tree that has no sub-elements. Typically, sheet components end up doing most of the actual work, since they have no one to delegate the work to.

3) The container (also called composite ) is an element having subelements: leaves or other containers. A container does not know the concrete classes of its children. It works with all sub-elements only through the component interface. Upon receiving a request, a container delegates work to its sub-elements, processes the intermediate results, and returns the final result to the client.

4) The Client works with all elements through the component interface. As a result, the client can work in the same way with both simple and complex elements of the tree.
