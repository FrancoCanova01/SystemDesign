https://refactoring.guru/images/patterns/diagrams/observer/structure-indexed.png

1) The Notifier sends events of interest to other objects. Those events occur when the notifier changes its state or performs some behaviors. Notifiers contain a subscription infrastructure that allows new and old subscribers to leave the list.

2) When a new event occurs, the notifier loops through the subscription list and invokes the notify method declared on the subscriber interface on each subscriber object.

3) The Subscriber interface declares the notification interface. In most cases, it consists of a single method actualizar. The method can have multiple parameters that allow the notifier to pass some event details along with the update.

4) Specific Subscribers perform some actions in response to notifications issued by the notifier. All of these classes must implement the same interface so that the notifier is not coupled to specific classes.

5) Subscribers typically need some contextual information to properly handle the update. For this reason, notifiers often pass certain context information as arguments to the notification method. The notifier can pass himself as an argument, letting the subscribers extract the necessary information directly.

6) The client creates objects Notifier type and subscriber separately and then registers subscribers for updates Notifier.
