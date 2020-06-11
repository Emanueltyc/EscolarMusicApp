using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolarMusicApp
{
    public static class Banco
    {
        public static string StrCon =
            @"";
        public static MySqlCommand AbriConexao()
        {
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection cn = new MySqlConnection(StrCon);
            try
            {
                cn.Open();
                cmd.Connection = cn;
            }
            catch (Exception ex)
            {

            }
            return cmd;

        }
    }
}
