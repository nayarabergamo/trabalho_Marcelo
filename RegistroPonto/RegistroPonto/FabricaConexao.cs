using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace RegistroPonto
{
    class FabricaConexao
    {
        public MySqlConnection RetornaConexao()
        {
            String connectionString = @"server=localhost;database=controle_ponto;userid=usuario;password=senha";
            return new MySqlConnection(connectionString);
        }
    }
}
