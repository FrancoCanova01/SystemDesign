# SNS

- Pub/Sub model
- One message and many many receivers.
- MEssages are sent to SNS topic and "subscribers" subscribe to a specific topic.
- SNS integrates with many other AWS services.
- Each subscriber to a topic gets all messages. There is also a feature that lets you filter messages.
- Up to 12500000 subscriptions per topic
- 100000 topic limit.
- Subscribers can be SQS, Email, HTTP/s, Kinesis, Lambda, SMS.
- SNS Direct Publish
    - For mobile device integration
    - You can also use Amazon SNS to send messages to mobile endpoints subscribed to a topic.
    - The difference is that Amazon SNS communicates through notification services like Apple Push Notification Service (APNS) and Google Firebase Cloud Messaging (FCM). Through the notifications service, the subscribed mobile endpoints receive notifications sent to the topic.
    - You can send Amazon SNS push notification messages directly to an endpoint which represents an application on a mobile device.
    - The publish is made to a platform endpoint
- Security:
    - In-flight encryption using HTTPS API
    - At rest encryption using KMS
    - You can also do client side encryption (on producers and consumers)
    - SNS Access Policies (simil a bucket policies): Useful for cross-account access to SNS.
- SNS & SQS Fan out pattern
    - Idea is that you send one message to SNS
    - SNS fans out to multiple SQS queues.
- SNS can be FIFO if consumers are FIFO SQS queues. We can get ordering and de-duplication features.
- SNS message filtering:
    - JSON policy used to filter messages sent to SNS topic subscriptions.
    - One topic can have multiple filters that filter messages before sending them to different consumers. (EWG: One filter per consumer to get subset of messages published to a specific topic).