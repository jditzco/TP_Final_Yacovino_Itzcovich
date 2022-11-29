using Tp_9.Models;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
namespace Tp_9.Models{
    public class RAM{
        private int _idRAM;
        private string _nombre;
        private int _cantMemoria;
        private int _unidades;
        public RAM(){

        }
        public RAM(int idRAM, string Nombre, int CantMemoria, int Unidades){
            _idRAM=idRAM;
            _nombre=Nombre;
            _cantMemoria=CantMemoria;
            _unidades=Unidades;
        }
        public int idRAM{
            get {return _idRAM;}
            set {_idRAM = value;}
        }
        public string Nombre{
            get {return _nombre;}
            set {_nombre = value;}
        }
        public int CantMemoria{
            get {return _cantMemoria;}
            set {_cantMemoria = value;}
        }
        public int Unidades{
            get {return _unidades;}
            set {_unidades = value;}
        }
    }
}