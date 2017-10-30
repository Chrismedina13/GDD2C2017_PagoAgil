using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba
{
    class BDComun
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection Conexion = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2017; User id=gd; Password= gd2017");
            Conexion.Open();
            return Conexion;
        }
    }
}
