using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DL
{
    public class Conexion
    {
        public static string Get()//Se utiliza el get porque va a recibir datos 
        {
            string conexion = ConfigurationManager.ConnectionStrings["KCuevasProgramacionNCapas"].ConnectionString;
            return conexion;//retorna la conexion de la base de datos
        }
    }
}
