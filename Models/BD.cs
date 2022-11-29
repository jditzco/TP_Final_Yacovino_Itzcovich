using Tp_9.Models;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
namespace Tp_9.Models{
    public static class BD{
        private static string  _connectionString= @"Server=DESKTOP-LARRJRO\MSSQLSERVER01;DataBase=CompuPro;Trusted_Connection=True;"; 
        private static List<Usuario> _ListaUsuarios = new List<Usuario>();
        public static void AgregarUsuario(string Nombre, string Contraseña, DateTime FechaNacimiento)
        {
            string sql = "INSERT INTO Usuario(nombre, contraseña, fechaNacimiento, fechaSignUp, plata, computadorasCompradas, computadorasVendidas, rango) VALUES (@nombre, @contraseña, @fechaNacimiento, @fechaSignUp, @plata, @computadorasCompradas, @computadorasVendidas, @rango)";
            using (SqlConnection db= new SqlConnection(_connectionString)){
                db.Execute(sql, new {nombre = Nombre, contraseña = Contraseña, fechaNacimiento = FechaNacimiento, fechaSignUp = DateTime.Now, plata = 0, computadorasCompradas = 0, computadorasVendidas = 0, rango = 'H'});
            }
        }
        public static void AgregarComputadora(int idUsuario, string nombre, int Precio, string Marca, string Procesador, string Mother, string PlacaVideo, string SO, string ram, bool EnvioADomicilio, string FuenteAlimentacion, string ImagenPortada)
        {
            string sql = "INSERT INTO Computadora(imagenPortada, precio, procesador, mother, placaVideo, fuenteAlimentacion, SO, envioADomicilio, disponible, marca, idUsuario, nombre, ram) VALUES (@pimagenPortada, @pprecio, @pprocesador, @pmother, @pplacaVideo, @pfuenteAlimentacion, @pSO, @penvioADomicilio, @pdisponible, @pmarca, @pidUsuario, @pnombre, @pram)";
            using (SqlConnection db= new SqlConnection(_connectionString)){
                db.Execute(sql, new {pimagenPortada = ImagenPortada, pprecio = Precio, pprocesador = Procesador, pmother = Mother, pplacaVideo = PlacaVideo, pfuenteAlimentacion = FuenteAlimentacion, pSO = SO, penvioADomicilio = EnvioADomicilio, pdisponible = 1, pmarca = Marca, pidUsuario = idUsuario, pnombre = nombre, pram = ram}); //FALTA 1 CAMPO QUE NO PUSE ACÁ
            }
        }
        public static Usuario verInfoUsuario(int idUsuario){
            string sql = "SELECT * FROM Usuario WHERE idUsuario = @IdUsuario";
            Usuario x = new Usuario();
            using (SqlConnection db= new SqlConnection(_connectionString)){
                x = db.QueryFirstOrDefault<Usuario>(sql, new{IdUsuario=idUsuario});
            }
            return x;
        }
        public static Usuario verInfoUsuario2(string nombre, string contraseña){
            string sql = "SELECT TOP 1 * FROM Usuario WHERE nombre = @Nombre AND contraseña = @Contraseña";
            Usuario x = new Usuario();
            using (SqlConnection db= new SqlConnection(_connectionString)){
                x = db.QueryFirstOrDefault<Usuario>(sql, new{Nombre = nombre, Contraseña = contraseña});
            }
            return x;
        }
        public static Usuario verInfoVendedorPC(int idPC){
            string sql = "SELECT * FROM Usuario WHERE idUsuario IN (SELECT idUsuario FROM Computadora WHERE idPC = @IdPC)";
            Usuario x = new Usuario();
            using (SqlConnection db= new SqlConnection(_connectionString)){
                x = db.QueryFirstOrDefault<Usuario>(sql, new{IdPC=idPC});
            }
            return x;
        }
        public static void agregarVentaUsuarioPC(int idPC){ //Trae el vendedor de una PC
            string sql = "UPDATE Usuario SET computadorasVendidas = computadorasVendidas + 1 WHERE idUsuario IN (SELECT idUsuario FROM Computadora WHERE idPC = @IdPC)";
             using (SqlConnection db= new SqlConnection(_connectionString)){
                db.Execute(sql, new{IdPC = idPC});
            }
        }
        public static void agregarCompraUsuario(int idUsuario){ //Agrega 1 compra del usuario
            string sql = "UPDATE Usuario SET computadorasCompradas = computadorasCompradas + 1 WHERE idUsuario = @IdUsuario";
             using (SqlConnection db= new SqlConnection(_connectionString)){
                db.Execute(sql, new{IdUsuario=idUsuario});
            }
        }
        public static void descontarDineroCompraUsuario(int idUsuario, double precio){ //Descuenta la plata de la billetera del comprador
            string sql = "UPDATE Usuario SET plata = plata - @PrecioCompu WHERE idUsuario = @IdUsuario";
             using (SqlConnection db= new SqlConnection(_connectionString)){
                db.Execute(sql, new{PrecioCompu=precio, IdUsuario=idUsuario});
            }
        }
        public static void actualizarRangoUsuario(int idUsuario, char rango){ //Actualiza el rango del usuario (El rango es la suma de las compras y las ventas de un usuario)
            string sql = "UPDATE Usuario SET rango = @Rango WHERE idUsuario = @IdUsuario";
             using (SqlConnection db= new SqlConnection(_connectionString)){
                db.Execute(sql, new{Rango=rango, IdUsuario=idUsuario});
            }
        }
        public static List<Usuario> cargarListaUsuarios(){
            string sql = "SELECT * FROM Usuario";
            using (SqlConnection db= new SqlConnection(_connectionString)){
                _ListaUsuarios = db.Query<Usuario>(sql).ToList();
            }
            return _ListaUsuarios;
        }
        public static List<Computadora> cargarComputadoras(int idUsuario){
            string sql = "SELECT * FROM Computadora WHERE idUsuario NOT IN (SELECT idUsuario FROM Usuario WHERE idUsuario = @IdUsuario)";
            List<Computadora> _ListaComputadoras = new List<Computadora>();
            using (SqlConnection db= new SqlConnection(_connectionString)){
                _ListaComputadoras = db.Query<Computadora>(sql, new{IdUsuario=idUsuario}).ToList();
            }
            return _ListaComputadoras;
        }
        public static List<Computadora> cargarTusComputadoras(int idUsuario){
            string sql = "SELECT * FROM Computadora WHERE idUsuario = @IdUsuario";
            List<Computadora> _ListaComputadoras = new List<Computadora>();
            using (SqlConnection db= new SqlConnection(_connectionString)){
                _ListaComputadoras = db.Query<Computadora>(sql, new{IdUsuario=idUsuario}).ToList();
            }
            return _ListaComputadoras;
        }
        public static List<Computadora> filtrarComputadoras(int idUsuario, string marca){
            List<Computadora> _ListaComputadoras = new List<Computadora>();
            string sql=null;
            if(marca!=null){
                sql = "SELECT * FROM Computadora WHERE marca = @Marca AND idUsuario <> @IdUsuario";
                using (SqlConnection db= new SqlConnection(_connectionString)){
                    _ListaComputadoras = db.Query<Computadora>(sql, new{IdUsuario=idUsuario, Marca=marca}).ToList();
                }
                return _ListaComputadoras;
            }
            else{
                return cargarComputadoras(idUsuario);
            }
            
        }
        public static Computadora VerInfoComputadora(int idPC){
            string sql = "SELECT * FROM Computadora WHERE idPC = @IdCompu";
            Computadora x = null;
            using (SqlConnection db= new SqlConnection(_connectionString)){
                x = db.QueryFirstOrDefault<Computadora>(sql, new{IdCompu=idPC});
            }
            return x;
        }
        public static void EliminarComputadora(int idPC){
            string sql = "DELETE FROM Computadora WHERE idPC = @IdCompu";
            using (SqlConnection db= new SqlConnection(_connectionString)){
                db.Execute(sql, new{IdCompu=idPC});
            }
        }
        public static void AgregarPlata(int idUsuario, int plata){
            string sql = "UPDATE Usuario SET plata = plata + @Plata WHERE idUsuario = @IdUsuario";
            using (SqlConnection db= new SqlConnection(_connectionString)){
                db.Execute(sql, new{Plata=plata,IdUsuario=idUsuario});
            }
        }
        public static void CompuNoDisponible(int idPC){
            string sql = "UPDATE Computadora SET disponible = 0 WHERE idPC = @IdPC";
            using (SqlConnection db= new SqlConnection(_connectionString)){
                db.Execute(sql, new{IdPC=idPC});
            }
        }
    }
}