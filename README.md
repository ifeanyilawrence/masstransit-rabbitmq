## Mass Transit - RabbitMQ

NB: Basic knowledge of docker required

### Install RabbitMQ
```bash
docker run -d --hostname rabbitmq-server --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```

#### RabbitMQ UI accessible on port 15672 (credentials: guest guest)

<br/>

#### Add a shared library, ideally a standalone C# library pushed to Nuget used for our class/messaged contracts. The shared interface/class will be used in consumer & producer projects

<br/>

#### Add A producer ASP.NET Core Web API project and reference shared library
	* add MassTransit & MassTransit.RabbitMQ Nuget packages
	* configure MassTransit to use RabbitMQ in startup
	* add createItemViewModel

#### Add item controller
	- inject IPublishEndpoint to the controller
	- add new post method and use the publishEndpoint service to push the message
	- in the anonymous type, ensure to use same property names as in the message contract
#### Add Consumer project (Another ASP.NET Web API)
	- add MassTransit Nuget package
	- add the consumer MassTransit config in Program.cs
	- add consumer class extending IConsumer interface
	_ add the consumer method and retrieve	the message

#### Run application
	- run the API and consumer together
	- call the post endpoint with payload
	- put a breakpoint in the consume method to see the message
	- check rabbitMq UI for the created exchanges, queues and message


