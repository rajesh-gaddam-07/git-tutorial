using System;
using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory{HostName ="localhost" };

using var Connection= factory.CreateConnection();

using var channel = Connection.CreateModel();

channel.QueueDeclare(queue: "letterbox",
                    durable: false,
                    exclusive: false,
                    autoDelete:false,
                    arguments:null);

var message= "This is my first message";
var encodedMessage = Encoding.UTF8.GetBytes(message);

channel.BasicPublish("","letterbox",null,encodedMessage);

Console.WriteLine($"Pulished message: {message}");