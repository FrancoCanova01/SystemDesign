# SQS

- Queue
- Producer sends messages and consumer polls messages. It processes and deletes (DeleteMessageAPI) the message from the queue.
- You cant change queue after you create it.
- Types:
    - Standard Queue:
        - Unlimited number of messages in queue
        - Retention of messages 4 days (max of 14 days). Messages are persisted until a consumer processes it and deletes it.
        - 256kb size limit per message. If you need more message size, you can use SQS Extended client (JAVA). Work together with S3 (where large object is sent) and just publish metadata pointing to that S3 location so consumer can access it when processing message.
        - Can occasionally have duplicate messages (at least once delivery)
        - Can have out of order messages (best effort ordering)
        - A consumer can receive up to 10 messages at a time
        - Unlimited throughput
        - "At least one delivery": One message might bne duplicated
        - "Best effort ordering": Usually messages are delivered in the same order as they are published.
        - Your app needs to know how to process messages that arrive more than once and might be out of order.
        - Similarly, the dead-letter queue of a standard queue must also be a standard queue.
    - FIFO Queue:
        - More ordering guarantee
        - Exactly once send capability (by removing duplicates if one was found)
        - Messages are consumed in order (in ideal scenario).
        - 300 msg/second throughput. If you batch messages you can reach up to 3000msg/s.
        - You create one by creating a standard queue and adding a ".fifo" suffix to the name (queue config will change accordingly).
        - De-duplication:
            - Interval of 5 minutes. If the exact same message is sent in this 5 minute timeframe then its considered a duplicate.
            - The message deduplication ID is the token used for deduplication of sent messages. If a message with a particular message deduplication ID is sent successfully, any messages sent with the same message deduplication ID are accepted successfully but aren't delivered during the 5-minute deduplication interval.
            - Message deduplication applies to an entire queue, not to individual message groups.
            - Amazon SQS continues to keep track of the message deduplication ID even after the message is received and deleted.
            - Content based de-duplication vs Message de-duplication Id: Based on SHA-256 hash of message body or based on a provided message id.
            - Amazon SQS FIFO queues follow exactly-once processing. It introduces a parameter called Message Deduplication ID, which is the token used for deduplication of sent messages. If a message with a particular message deduplication ID is sent successfully, any messages sent with the same message deduplication ID are accepted successfully but aren't delivered during the 5-minute deduplication interval.
            ![SQS Deduplication](../../media/sqs-fifo-deduplication.png)
        - MessageGrouping:
            - Specify a group id to put messages together in same group.
            - You can have one consumer per group
            - Ordering across groups is not guaranteed.
        - The dead-letter queue of a FIFO queue must also be a FIFO queue.

- SQS with EC2 ASG:
    - SQS queue sends metric to Cloudwatch metric (AproximateNumberOfMessages)
    - We set an alarm on that metric
    - Use ASG to scale instances so messages are processed faster.

- Security:
    - In-flight encryption using HTTPS API
    - At rest encryption using KMS
    - You can also do client side encryption (on producers and consumers)
    - SQS Access Policies (simil a bucket policies): Useful for cross-account access to SQS queues. Also necessary when S3 needs to publish notifications to SQS
    - There is one major **difference between IAM** and **Amazon SQS policies**: the Amazon SQS policy system lets you grant permission to other AWS Accounts, whereas IAM doesn't.

- Message visibility timeout: Messages become invisible when polled until it is processed and deleted or not processed and added back to the queue. If message is not processed within timeout, then there is a chance of double processing the message. A consumer can make use of `ChangeMessageVisibility` API to get more time to process message and avoid this problem. The visibility timeout for the queue is in seconds. Valid values are: An integer from 0 to 43,200 (12 hours), the Default value is 30.
- We can set 'MaximumReceives' threshold and send a message to a DLQ if it fails to be processed x times. MAke sure to set 14 days retention to messages in DLQ so you have time to debug.
- Delay Queue: Delay messages so consumers don't see them immediately (up to 15 minutes). You can modify it using the 'DelaySeconds' parameter
- LongPolling: Used to reduce api calls to queue. Poll and if there is no message there, wait until sew message arrives. The wait can be between 1 and 20 seconds. If the ReceiveMessageWait is set to 0 then its called ShortPolling.
- APIs
    - CreateQueue (MessageRetentionPeriod), DeleteQueue
    - PurgeQueue: Delete all messages in queue
    - SendMessage (DelaySeconds), ReceiveMessages, DeleteMessages
    - MaxNumberOfMessages: default 1 max 10 (for ReceiveMessage API))
    - ReceiveMessageWaitTimeSecondes: LongPolling
    - ChangeMessageVisibility: Change message timeout
    - Some batch APIs are SendMessage, DeleteMessage, ChangeMEssageVisibility which can help you reduce costs.
    - MessageRetentionPeriod: controls the length of time, in seconds, for which Amazon SQS retains a message.
- Quotas:
    - Delay: The default (minimum) delay for a queue is 0 seconds. The maximum is 15 minutes.
    - Long polling: The maximum long polling wait time is 20 seconds.
    - Message groups: There is no quota to the number of message groups within a FIFO queue.
    - Messages: The number of messages that an Amazon SQS queue can store is unlimited.
    - In flight messages: Standard - 120,000 inflight messages. FIFO - 20,000 inflight messages 
    - Message attributes: A message can contain up to 10 metadata attributes.
    - Message batch requests: A single message batch request can include a maximum of 10 messages. 
    - Message retention: By default, a message is retained for 4 days. The minimum is 60 seconds (1 minute). The maximum is 1,209,600 seconds (14 days).
    - Message throughput:
        - Standard: Standard queues support a nearly unlimited number of API calls per second
        - FIFO: Without batching, FIFO queues support up to 300 API calls per second. With batching FIFO queues support up to 3,000 messages per second.
        - High throughput FIFO: Without batching 3,000 messages per second.  You can increase throughput up to 30,000 messages per second by using batching APIs.
    - Message size: The minimum message size is 1 byte (1 character). The maximum is 262,144 bytes (256 KB).
    - Message visibility timeout: The default visibility timeout for a message is 30 seconds. The minimum is 0 seconds. The maximum is 12 hours.