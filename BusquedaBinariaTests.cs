using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataCore.Fase4;

namespace DataCore.Tests
{
    [TestClass]
    public class BusquedaBinariaTests
    {
        // Fixture compartida: Arreglo de 5 elementos ordenado ascendentemente
        private static readonly RegistroDatos[] _arregloBase = new[]
        {
            new RegistroDatos { Id = 10, Nombre = "Alpha", Dato = "dato1" },
            new RegistroDatos { Id = 25, Nombre = "Beta", Dato = "dato2" },
            new RegistroDatos { Id = 40, Nombre = "Gamma", Dato = "dato3" },
            new RegistroDatos { Id = 67, Nombre = "Delta", Dato = "dato4" },
            new RegistroDatos { Id = 99, Nombre = "Epsilon", Dato = "dato5" }
        };

        // CASO 1: Elemento en el extremo izquierdo (índice 0)
        [TestMethod]
        public void Buscar_ElementoEnExtremoIzquierdo_RetornaElementoCorrecto()
        {
            var (registro, comparaciones) = BusquedaIndexada.BuscarRegistroIndexado(_arregloBase, 10);

            Assert.IsNotNull(registro);
            Assert.AreEqual(10, registro.Id);
            Assert.IsTrue(comparaciones >= 1);
        }

        // CASO 2: Elemento en el extremo derecho (índice n-1)
        [TestMethod]
        public void Buscar_ElementoEnExtremoDerecho_RetornaElementoCorrecto()
        {
            var (registro, _) = BusquedaIndexada.BuscarRegistroIndexado(_arregloBase, 99);

            Assert.IsNotNull(registro);
            Assert.AreEqual(99, registro.Id);
        }

        // CASO 3: Elemento exactamente en el punto medio
        [TestMethod]
        public void Buscar_ElementoEnPuntoMedio_RetornaEnUnaComparacion()
        {
            // Con 5 elementos, el medio es índice 2 -> ID 40
            var (registro, comparaciones) = BusquedaIndexada.BuscarRegistroIndexado(_arregloBase, 40);

            Assert.IsNotNull(registro);
            Assert.AreEqual(40, registro.Id);
            Assert.AreEqual(1, comparaciones); // Debe encontrarlo en la 1ª iteración
        }

        // CASO 4: Elemento no existente — retorna null
        [TestMethod]
        public void Buscar_ElementoNoExistente_RetornaNull()
        {
            var (registro, comparaciones) = BusquedaIndexada.BuscarRegistroIndexado(_arregloBase, 50);

            Assert.IsNull(registro);
            Assert.IsTrue(comparaciones > 0); // Se hicieron comparaciones aunque falló
        }

        // CASO 5: Arreglo vacío — retorna null con 0 comparaciones
        [TestMethod]
        public void Buscar_ArregloVacio_RetornaNullSinComparaciones()
        {
            var arregloVacio = Array.Empty<RegistroDatos>();
            var (registro, comparaciones) = BusquedaIndexada.BuscarRegistroIndexado(arregloVacio, 10);

            Assert.IsNull(registro);
            Assert.AreEqual(0, comparaciones);
        }

        // CASO 6: Arreglo con un solo elemento — coincidencia
        [TestMethod]
        public void Buscar_UnElemento_Coincidencia_RetornaElemento()
        {
            var arregloUnico = new[] { new RegistroDatos { Id = 42, Nombre = "Único", Dato = "dato" } };
            var (registro, comparaciones) = BusquedaIndexada.BuscarRegistroIndexado(arregloUnico, 42);

            Assert.IsNotNull(registro);
            Assert.AreEqual(1, comparaciones);
        }

        // CASO 7: Arreglo con un solo elemento — sin coincidencia
        [TestMethod]
        public void Buscar_UnElemento_SinCoincidencia_RetornaNull()
        {
            var arregloUnico = new[] { new RegistroDatos { Id = 42, Nombre = "Único", Dato = "dato" } };
            var (registro, comparaciones) = BusquedaIndexada.BuscarRegistroIndexado(arregloUnico, 99);

            Assert.IsNull(registro);
            Assert.AreEqual(1, comparaciones);
        }

        // CASO 8: Arreglo null — retorna null sin excepción
        [TestMethod]
        public void Buscar_ArregloNull_RetornaNullSinExcepcion()
        {
            var (registro, comparaciones) = BusquedaIndexada.BuscarRegistroIndexado(null, 10);

            Assert.IsNull(registro);
            Assert.AreEqual(0, comparaciones);
        }
    }
}