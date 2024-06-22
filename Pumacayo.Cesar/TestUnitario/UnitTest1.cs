using Entidades;
using Interfaz;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json;
using System.Windows.Forms;


namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
    {

        /// <summary>
        /// Verifica que el archivo MOCK_DATA.json se encuentra en la ubicación esperada.
        /// </summary>
        [TestMethod]
        public void VerificarUbicacionArchivoJson()
        {
            //Arrange
            string directorioEjecutable = AppDomain.CurrentDomain.BaseDirectory;

            string jsonPath = Path.Combine(@"..\..\..\MOCK_DATA.json");

            string filePath = Path.GetFullPath(Path.Combine(directorioEjecutable, jsonPath));

            //Act y Assert
            if(File.Exists(filePath)) 
            {
                Assert.IsTrue(File.Exists(filePath));
            }


        }
        /// <summary>
        /// Prueba unitaria para verificar que el método Verificar del formulario FrmLogin 
        /// encuentre correctamente un usuario en el archivo JSON con credenciales válidas.
        /// </summary>

        [TestMethod]
        public void VerificarUsuarioJson()
        {
            // Arrange
            var form = new FrmLogin();
            form.txtCorreo.Text = "cgorgen@vendedor.com";
            form.txtClave.Text = "123abc45";

            // Simular el archivo JSON y su contenido
            var jsonContent = @"
            [
                {""apellido"":""Gorgen"",""nombre"":""Corey"",""legajo"":1,""correo"":""cgorgen@vendedor.com"",""clave"":""123abc45"",""perfil"":""vendedor""},
                {""apellido"":""Harroll"",""nombre"":""Ingrid"",""legajo"":2,""correo"":""iharroll@vendedor.com"",""clave"":""qweasdzx"",""perfil"":""vendedor""},
                {""apellido"":""Harris"",""nombre"":""Steve"",""legajo"":3,""correo"":""sharris@maiden.com.uk"",""clave"":""eddie666"",""perfil"":""vendedor""},
                {""apellido"":""Robinson"",""nombre"":""Tilda"",""legajo"":4,""correo"":""trobinson@super.com"",""clave"":""12345678"",""perfil"":""supervisor""},
                {""apellido"":""Jordan"",""nombre"":""Michael"",""legajo"":5,""correo"":""admin@admin.com"",""clave"":""12345678"",""perfil"":""administrador""}
            ]";
            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\MOCK_DATA.json");
            File.WriteAllText(jsonPath, jsonContent);

            // Act
            var resultado = form.Verificar();

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual("cgorgen@vendedor.com", resultado.correo);
            Assert.AreEqual("123abc45", resultado.clave);

            // Clean up
            File.Delete(jsonPath);
        }
        /// <summary>
        /// Prueba verifica la igualdad de dos instancias de gaseosas con los mismos valores de propiedades
        /// </summary>
        [TestMethod]
        public void VerificarIgualdadTipoBotella_Ok()
        {
            //Arrange
            Fanta f1 = new Fanta(EtipoBotella.Plastico, 1, 10, true);
            Manaos f2 = new Manaos(EtipoBotella.Plastico, 1 , 10 , true);

            //Act
            bool result = f1 == f2;
            //Assert
            Assert.IsTrue(result);  
        }
        /// <summary>
        /// Prueba verifica la desigualdad de dos instancias de gaseosas con los mismos valores de propiedades
        /// </summary>
        [TestMethod]
        public void VerificarIgualdadTipoBotella_Failure()
        {
            //Arrange
            Fanta f1 = new Fanta(EtipoBotella.Plastico, 1, 10, false);
            Manaos f2 = new Manaos(EtipoBotella.Vidrio, 1, 25, true);

            //Act
            bool result = f1 == f2;

            //Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Prueba que verifica la correcta adición de instancias de diferentes tipos de gaseosas a una lista de gaseosas.
        /// </summary>
        [TestMethod]
        public void AgregarGaseosaLista()
        {
            //Arrange
            List<Gaseosa> listaGaseosa = new List<Gaseosa>();
            Fanta f1 = new Fanta(EtipoBotella.Plastico, 1, 1, true);

            Manaos m2 = new Manaos(EtipoBotella.Plastico, 1200.0, 1, EtipoSabor.Naranja, false);

            Sprite s3 = new Sprite(EtipoBotella.Vidrio, 5000.0, 2, 123.321, false);

            //Act
            listaGaseosa.Add(f1);   
            listaGaseosa.Add(m2);
            listaGaseosa.Add(s3);

            //Assert
            Assert.IsTrue(listaGaseosa.Contains(f1));
            Assert.IsTrue(listaGaseosa.Contains(m2));
            Assert.IsTrue(listaGaseosa.Contains(s3));
        }
        /// <summary>
        /// Prueba que verifica la correcta eliminacion de las gaseosas en la lista
        /// </summary>
        [TestMethod]
        public void EliminarGaseosaLista()
        {
            //Arrange
            List<Gaseosa> listaGaseosa = new List<Gaseosa>();
            Fanta f1 = new Fanta(EtipoBotella.Plastico, 1, 1, true);

            Manaos m2 = new Manaos(EtipoBotella.Plastico, 1200.0, 1, EtipoSabor.Naranja, false);

            Sprite s3 = new Sprite(EtipoBotella.Vidrio, 5000.0, 2, 123.321, false);

            //Act
            listaGaseosa.Add(f1);
            listaGaseosa.Add(m2);
            listaGaseosa.Add(s3);

            listaGaseosa.Remove(m2);

            //Assert
            Assert.IsFalse(listaGaseosa.Contains(m2));
        }






    }

}