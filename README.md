# RabbitMQ - with .NET Core & Docker
### Goal
To become familiar with messaging architecture using asynchrnous and syncronous processing


[Pluralsight Course 1: RabbitMQ by Example](https://app.pluralsight.com/library/courses/rabbitmq-by-example/table-of-contents)

## Notes from Course 1:

RabbitMQ - open-source messaging system that allows applications to integrate together using exchanges and queues

AMQP - Advanced Message Queue Protocol

Developed in ERLANG - supports other development languages using it's client libraries

Common platform message coordinator that allows applications to send and receive messages to one another

### Benefits of RabbitMQ
- Reliability
  - Messages can be persisted on disk for fault talerence
  - Message delivery acknowledgements
- Routing
- Clustering and High Availability
- Management Web Interface
- Command Line Interface (CLI)
  - rabbitmq-ctrl
  - rabbitmq-admin
- Cross platform
  - Linux
  - Windows
  - MacOS
  - Azure
  - AWS
  - Docker


## MSMQ vs RabbitMQ
MSMQ - Microsoft Messaging Queue - messaging protocol that allows applications running on separate servers and protocols to communicate in a failsafe manner

### MSMQ Benefits
- Reliability
  - Reliably delivers messages inside / outside of the organization
- Places failed messages on a separate queue
- Security & priority based messages are supported 
- Supports transactions

### RabbitMQ vs MSMQ
- Centeralized vs Decentralized
  - RabbitMQ - centeralized
  - MSMQ - Decenteralized
- Multi-platform vs Windows
  - RabbitMQ - multi-platform
  - MSMQ - Windows only messaging queue
- Standards vs no-standards
  - RabbitMQ - AMQP
  - MSMQ - own propriety messaging format

## Exchange
AMQP - Advanced Message Queueing Protocol
  - RabbitMQ supports 0-9-1
  - Publisher -> Message Broker -> Consumer
    - Message Broker   
      Exchange -> Routes -> Queue   
  - You can think of an exchange like a mailbox

### Exchange types
1. Direct
2. Fanout
3. Topic
4. Headers

Each exchange is declared with a number of different attributes:
- name: Name of the exchange
- durability: Persisting the messages to disk
- auto-delete: Delete message when not needed
- arguments: these are message broker-dependent

### Direct Exchange
Ideal if you want to publish a message to a single queue
<img src="https://github.com/ZinkNotTheMetal/PS-RabbitMQ/blob/master/images/direct-exchange.png">

### Fanout Exchange
Ideal for broadcast routing for messages
<img src="https://github.com/ZinkNotTheMetal/PS-RabbitMQ/blob/master/images/fanout-exchange.png">

Example:
  - weather updates to all consumers
  - online game scores to all players in a game
  - chat sessions between groups of people

### Topic Exchange
Route messages to one or many queues based on a pattern of the routing key
<img src="https://github.com/ZinkNotTheMetal/PS-RabbitMQ/blob/master/images/topic-exchange.png">
Uses wildcard routing key

Example:
  - Commonly used to intake a message and route them to different queues
  - If an application wants to selectively choose what messages they receive this queue should be considered
  - categorized news updates

Will be covered in more detail in later modules

### Headers Exchange
Supercharged direct exchanges
<img src="https://github.com/ZinkNotTheMetal/PS-RabbitMQ/blob/master/images/headers-exchange.png">


## Queues
First In / First Out basis (FIFO)

Each queue is declared with a number of different attributes 
- name: the name of the queue
- durable: persisting the queue to disk
- exclusive: delete the queue when not needed
- auto-delete: queue deleted when consumer unsubscribes

