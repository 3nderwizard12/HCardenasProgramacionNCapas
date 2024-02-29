using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Connection
    {
        public static string GetConnection()
        {
            //return "Data Source=.;Initial Catalog=HCardenasProgramcionNCapas;Persist Security Info=True;User ID=sa;Password=pass@word1;";
            return ConfigurationManager.ConnectionStrings["HCardenasProgramcionNCapas"].ToString();
        }
    }
}
