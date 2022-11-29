using Tp_9.Models;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
namespace Tp_9.Models{
    public class Computadora{
        private int _idPC;
        private string _imagenPortada;
        private double _precio;
        private string _procesador;
        private string _mother;
        private string _placaVideo;
        private string _fuenteAlimentacion;
        private string _SO;
        private bool _envioADomicilio;
        private bool _disponible;
        private string _marca;
        private int _idUsuario;
        private string _nombre;
        private string _ram;
        
        public Computadora(){

        }
        public Computadora(int idPC, string ImagenPortada, double Precio, string Procesador, string Mother, string PlacaVideo, string FuenteAlimentacion, string SO, bool EnvioADomicilio, bool Disponible, string Marca, int idUsuario, string nombre, string ram)
        {
            _idPC=idPC;
            _imagenPortada=ImagenPortada;
            _precio=Precio;
            _procesador=Procesador;
            _mother=Mother;
            _placaVideo=PlacaVideo;
            _fuenteAlimentacion=FuenteAlimentacion;
            _SO=SO;
            _envioADomicilio=EnvioADomicilio;
            _disponible=Disponible;
            _marca=Marca;
            _idUsuario=idUsuario;
            _nombre=nombre;
            _ram=ram;
        }
        public int idPC{
            get {return _idPC;}
            set {_idPC = value;}
        }
        public string ImagenPortada{
            get {return _imagenPortada;}
            set {_imagenPortada = value;}
        }
        public double Precio{
            get {return _precio;}
            set {_precio = value;}
        }
        public string Procesador{
            get {return _procesador;}
            set {_procesador = value;}
        }
        public string Mother{
            get {return _mother;}
            set {_mother = value;}
        }
        public string PlacaVideo{
            get {return _placaVideo;}
            set {_placaVideo = value;}
        }
        public string FuenteAlimentacion{
            get {return _fuenteAlimentacion;}
            set {_fuenteAlimentacion = value;}
        }
        public string SO{
            get {return _SO;}
            set {_SO = value;}
        }
        public bool EnvioADomicilio{
            get {return _envioADomicilio;}
            set {_envioADomicilio = value;}
        }
        public bool Disponible{
            get {return _disponible;}
            set {_disponible = value;}
        }
        public string Marca{
            get {return _marca;}
            set {_marca = value;}
        }
        public int idUsuario{
            get {return _idUsuario;}
            set {_idUsuario = value;}
        }
        public string nombre{
            get {return _nombre;}
            set {_nombre = value;}
        }
        public string ram{
            get {return _ram;}
            set {_ram = value;}
        }
    }
}