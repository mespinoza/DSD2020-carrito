using RabbitMQ.Client;
using Servicio_Mant.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Servicio_Mant.Mensaje
{
    public class Mensajes
    {
        public static void EnviarMensajeCliente(Cliente cliente)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "moose.rmq.cloudamqp.com",
                VirtualHost = "tmuhbdns",
                UserName = "tmuhbdns",
                Password = "CRNFWsKvg1zVmCzVUOtRZKT3ZPnj4EZQ"
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "Notificacion Nuevo Cliente",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = cliente.id_cliente.ToString() + "|" + cliente.id_usuario.ToString() + "|" + cliente.nombre.ToString() +
                    "|" + cliente.apellido1.ToString() + "|" + cliente.apellido2.ToString() + "|" + cliente.dni.ToString() +
                    "|" + cliente.correo.ToString() + "|" + cliente.clave.ToString() + "|" + cliente.direccion.ToString() + "|" + cliente.referencia.ToString();
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "Notificacion Nuevo Cliente",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }
        }

        public static Cliente ObtenerMensajeCliente()
        {
            Cliente clientenuevo = null;
            string clientResult = "";

            var factory = new ConnectionFactory()
            {
                HostName = "moose.rmq.cloudamqp.com",
                VirtualHost = "tmuhbdns",
                UserName = "tmuhbdns",
                Password = "CRNFWsKvg1zVmCzVUOtRZKT3ZPnj4EZQ"
            };
            using (var connection = factory.CreateConnection())

            using (var channel = connection.CreateModel())
            {
                BasicGetResult consumer = channel.BasicGet(
                    "Notificacion Nuevo Cliente", true
                    );

                if (consumer != null)
                {
                    string resultado = Encoding.UTF8.GetString(consumer.Body.ToArray());
                    string[] subs = resultado.Split('|');

                    clientenuevo = new Cliente()
                    {
                        id_cliente = int.Parse(subs[0]),
                        id_usuario = int.Parse(subs[1]),
                        nombre = subs[2],
                        apellido1 = subs[3],
                        apellido2 = subs[4],
                        dni = subs[5],
                        correo = subs[6],
                        clave = subs[7],
                        direccion = subs[8],
                        referencia = subs[9],
                    };

                    clientResult = clientResult + "\r\n" +
                        "Mensaje: " + resultado;
                }

                Console.WriteLine(" [x] Sent {0}", clientResult);
            }
            return clientenuevo;
        }
    }
}