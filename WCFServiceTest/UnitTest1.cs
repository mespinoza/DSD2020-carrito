using System;
using System.ServiceModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WCFServiceTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Tes1CrearDespachoOk()
        {
            DespachoWS.ServiceDespachoClient proxy = new DespachoWS.ServiceDespachoClient();
            DespachoWS.Despacho despachoCreado = proxy.CrearDespacho(new DespachoWS.Despacho()
            {
                ubicacion = "UbicacionDemo",
                fecha = Convert.ToDateTime("08/08/2020"),
                id_compra = 3,
                id_tipo_estado = 1,
                estado = true
            });
            Assert.AreEqual("UbicacionDemo", despachoCreado.ubicacion);
            Assert.AreEqual(Convert.ToDateTime("08/08/2020"), despachoCreado.fecha);
            Assert.AreEqual(3, despachoCreado.id_compra);
            Assert.AreEqual(1, despachoCreado.id_tipo_estado);
            Assert.AreEqual(true, despachoCreado.estado);

        }
        [TestMethod]
        public void Tes1CrearDespachoRepetido()
        {
            DespachoWS.ServiceDespachoClient proxy = new DespachoWS.ServiceDespachoClient();
            try
            {
                DespachoWS.Despacho despachoCreado = proxy.CrearDespacho(new DespachoWS.Despacho()
                {
                    ubicacion = "UbicacionDemo",
                    fecha = Convert.ToDateTime("10-11-2020"),
                    id_compra = 3,
                    id_tipo_estado = 1,
                    estado = true
                });
                Assert.AreEqual("UbicacionDemo", despachoCreado.ubicacion);
                Assert.AreEqual(Convert.ToDateTime("10-11-2020"), despachoCreado.fecha);
                Assert.AreEqual(3, despachoCreado.id_compra);
                Assert.AreEqual(1, despachoCreado.id_tipo_estado);
                Assert.AreEqual(true, despachoCreado.estado);

            }
            catch (FaultException<DespachoWS.RepetidoException> error)
            {

                Assert.AreEqual("Error al intentar la Creación", error.Reason.ToString());
                Assert.AreEqual(error.Detail.Codigo, "101");
                Assert.AreEqual(error.Detail.Descripcion, "El despacho ya existe con la misma compra");
            }

        }
        [TestMethod]
        public void Tes2CrearDespachoFechaNoValida()
        {
            DespachoWS.ServiceDespachoClient proxy = new DespachoWS.ServiceDespachoClient();
            DespachoWS.Despacho despachoCreado = proxy.CrearDespacho(new DespachoWS.Despacho()
            {
                ubicacion = "UbicacionDemo",
                fecha = Convert.ToDateTime("08-11-2020"),
                id_compra = 5,
                id_tipo_estado = 1,
                estado = true
            });
            Assert.AreEqual("UbicacionDemo", despachoCreado.ubicacion);
            Assert.AreEqual(Convert.ToDateTime("08-08-2020"), despachoCreado.fecha);
            Assert.AreEqual(5, despachoCreado.id_compra);
            Assert.AreEqual(1, despachoCreado.id_tipo_estado);
            Assert.AreEqual(true, despachoCreado.estado);

        }
        [TestMethod]
        public void Tes2CrearDespachoFechaValida()
        {
            DespachoWS.ServiceDespachoClient proxy = new DespachoWS.ServiceDespachoClient();
            try
            {
              
                DespachoWS.Despacho despachoCreado = proxy.CrearDespacho(new DespachoWS.Despacho()
                {
             
                    ubicacion = "UbicacionDemo",
                    fecha = DateTime.Now,
                    id_compra = 8,
                    id_tipo_estado = 1,
                    estado = true


            });
                Assert.AreEqual("UbicacionDemo", despachoCreado.ubicacion);
                Assert.AreEqual(DateTime.Now, despachoCreado.fecha);
                Assert.AreEqual(8, despachoCreado.id_compra);
                Assert.AreEqual(1, despachoCreado.id_tipo_estado);
                Assert.AreEqual(true, despachoCreado.estado);
            }
            catch (Exception error)
            {
                Console.WriteLine("Error al Crear", error);

            }

        }

    }
}
