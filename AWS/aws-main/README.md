# AWS
Exploring different aws services

## ToDo list hands on:
- Further reading in JSON policy generation: https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_policies.html.
- ELB with WebSockets PoC. (PoC with API Gateway WebSockets?)
- ASG lifecycle hook with lambda: https://docs.aws.amazon.com/autoscaling/ec2/userguide/tutorial-lifecycle-hook-lambda.html
- RDS replica lag alarm: https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/multi-az-db-cluster-cloudwatch-alarm.html
- Aurora cluster and web server: https://docs.aws.amazon.com/es_es/es_es/AmazonRDS/latest/AuroraUserGuide/TUT_WebAppWithRDS.html
- Personalize content by country or device Lambda@Edge: https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/lambda-examples.html#lambda-examples-redirecting-examples
- CodeBuild Docker: https://docs.aws.amazon.com/codebuild/latest/userguide/sample-docker.html
- Subscribe Email to SNS: https://docs.aws.amazon.com/sns/latest/dg/example_sns_Subscribe_section.html
- Sending a message to an Amazon SQS queue from Amazon Virtual Private Cloud: https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-sending-messages-from-vpc.html
- Kinesis & Lambda: https://docs.aws.amazon.com/lambda/latest/dg/with-kinesis-example.html
- Kinesis Data Analytics: https://docs.aws.amazon.com/kinesisanalytics/latest/dev/app-tworecordtypes.html

## General
### AWS Partitions
- A Partition is a group of AWS Region and Service objects. You can use a partition to determine what services are available in a region, or what regions a service is available in.
- AWS accounts are scoped to a single partition. You can get a partition by name. Valid partition names include:
    - "aws" - Public AWS partition
    - "aws-cn" - AWS China
    - "aws-us-gov" - AWS GovCloud
- A Partition is divided up into one or more regions.
- A Partition has a list of services available
- Each Service object has a name, and information about regions that service is available in.
- Some services have multiple regions, and others have a single partition wide region. For example, IAM has a single region in the "aws" partition (because its a global service)

### SSL Certificates:
- SSL Certificates play an important role in building trust between browsers and web servers.
- Steps:
    1. Browser: Give me youtube (through DNS).
    2. Youtube: Returns his public key  and SSL certificate (issued by for example Google).
    3. Browser: I know and trust google. I also know googles public key. I will verify that it was actually google who issued the certificate. The SSL certificates signature is created by the CAs private key. The previous signature is verified by using CAs public key (which is already in the browser).
        - The browser already has all public keys of mayor CAs. Its important to chose a CA that most browsers support.
    4. Browser: Lets create a secret that only both of us know and use that to communicate. Browser creates a secret (symmetric key). It keeps a copy or it and and encrypts the other one with youtube's public key (so only youtube can decrypt it with its private key).
    5. Youtube: Decrypts the secret with its private key
    6. We've created a secure communication channel between client and server. All traffic will be encrypted and decrypted using this shared symmetric key.
- Its a good example of how asymmetric (public and private keys) and symmetric key algorithms work together.
- Steps to secure website:
    - Web: I want to use HTTPS. I send a "certificate signing request" to a CA. The request goes together with the senders public key, domain name, organization name, locality, state, email and other information. The request is signed by the senders private key. CAs may even contact the sender to request more information.
    - CA: Ive signed your request with my private key. Anyone who has my public key can verify that it was actually me who signed it.

### IOPS vs Throughput (analogy):
1. You have 4 buckets (disk size) of the same size that you want to fill or empty water to.
2. You'll be using a jug to transfer the water into or out of the buckets. Now the question will be:
    - At any given time (per second), how many jugs of water can you pour (write) or withdraw (read)? -> This is the concept of **IOPS**.
    - At any given time (per second), whats the amount of water (bit, kb, mb, etc) the jug can transfer into/out of the bucket continuously? -> This is the concept of **Throughput**.
    - Additionally there is a delay in the process of pouring and withdrawing the water from/to the buckets -> This is the concept of ***Latency**.

### Throughput vs Bandwidth:
- Throughput refers to how much data can be transferred from source to destination within a given timeframe (the jug of water form above example).
- Bandwidth is defined as the maximum throughput capacity of a network.
- They both have the same unit of measurement (bits/second)

### Elasticity
- In the cloud, resources are elastic, meaning they can instantly grow or shrink to match the requirements of a specific application.There are two basic types of elasticity:
    1. Time-based: Turning off resources when they are not being used, such as a development environment that is needed only during business hours.
    2. Volume-based: Matching scale to the intensity of demand, whether that’s compute cores, storage sizes, or throughput.

### SSL Certificates in AWS
- For certificates in a Region supported by **AWS Certificate Manager** (ACM), it is recommended that you use ACM to provision, manage, and deploy your server certificates. In **unsupported Regions**, you must use **IAM as a certificate manager.**IAM securely encrypts your private keys and stores the encrypted version in IAM SSL certificate storage. IAM supports deploying server certificates in all Regions, but you must obtain your certificate from an external provider for use with AWS. You cannot upload an ACM certificate to IAM. Additionally, you cannot manage your certificates from the IAM Console.