using Tp_9.Models;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
namespace Tp_9.Models{
    public class Usuario{
        private int _IdUsuario;
        private string _nombre;
        private string _contraseña;
        private DateTime _fechaNacimiento;
        private DateTime _fechaSignUp;
        private double _plata;
        private int _computadorasCompradas;
        private int _computadorasVendidas;
        private char _rango;
        public Usuario(){

        }
        public Usuario(int idUsuario, string Nombre, string Contraseña, DateTime FechaNacimiento, DateTime FechaSignUp, double Plata, int ComputadorasCompradas, int ComputadorasVendidas, char Rango){
            _IdUsuario=idUsuario;
            _nombre=Nombre;
            _contraseña=Contraseña;
            _fechaNacimiento=FechaNacimiento;
            _fechaSignUp=FechaSignUp;
            _plata=Plata;
            _computadorasCompradas=ComputadorasCompradas;
            _computadorasVendidas=ComputadorasVendidas;
            _rango=Rango;
        }
        public int idUsuario{
            get {return _IdUsuario;}
            set {_IdUsuario = value;}
        }
        public string Nombre{
            get {return _nombre;}
            set {_nombre = value;}
        }
        public string Contraseña{
            get {return _contraseña;}
            set {_contraseña = value;}
        }
        public DateTime FechaNacimiento{
            get {return _fechaNacimiento;}
            set {_fechaNacimiento = value;}
        }
        public DateTime FechaSignUp{
            get {return _fechaSignUp;}
            set {_fechaSignUp = value;}
        }
        public double Plata{
            get {return _plata;}
            set {_plata = value;}
        }
        public int ComputadorasCompradas{
            get {return _computadorasCompradas;}
            set {_computadorasCompradas = value;}
        }
        public int ComputadorasVendidas{
            get {return _computadorasVendidas;}
            set {_computadorasVendidas = value;}
        }
        public char Rango{
            get {return _rango;}
            set {_rango = value;}
        }
    }
}