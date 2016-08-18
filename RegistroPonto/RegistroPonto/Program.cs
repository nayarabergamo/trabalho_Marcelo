using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace RegistroPonto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite a data:");
            String data = Console.ReadLine();
            Console.WriteLine("Digite o horario:");
            String horario = Console.ReadLine();

            FabricaConexao fabricaConexao = new FabricaConexao();
            MySqlConnection connectionInsert = fabricaConexao.RetornaConexao();

            String queryInserir = "Insert INTO ponto(data, hora) values(@data, @hora)";
            connectionInsert.Open();
            MySqlCommand commandInserir = new MySqlCommand(queryInserir, connectionInsert);
            commandInserir.Prepare();
            commandInserir.Parameters.Add(new MySqlParameter("data", data));
            commandInserir.Parameters.Add(new MySqlParameter("hora", horario));
            commandInserir.ExecuteNonQuery();
            connectionInsert.Close();
            Console.WriteLine("Registro inserido com sucesso");
            Console.ReadKey();
            

            String pesquisa = "SELECT data, hora FROM ponto";
            connectionInsert.Open();
            MySqlCommand commandPesquisar = new MySqlCommand(pesquisa, connectionInsert);
            commandPesquisar.Prepare();

            using (MySqlDataReader dr = commandPesquisar.ExecuteReader())
            {
                while (dr.Read())
                {
                    Console.WriteLine("Data:          {0}", Convert.ToString(dr["data"]));
                    Console.WriteLine("Horario        {0}", Convert.ToString(dr["hora"]));
                }

            }

            Console.ReadKey();

        }
    }
}
