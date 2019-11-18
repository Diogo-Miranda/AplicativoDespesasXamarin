using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AplicativoDespesas.Models
{
    class Database
    {
        string DiretorioBase = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        bool TabelasCriadas = false;

        public SQLiteConnection Conexao()
        {
            SQLiteConnection cnx = new SQLiteConnection(Path.Combine(DiretorioBase, "base.db"));

            if(!TabelasCriadas)
            {
                cnx.CreateTable<Despesa>();
                TabelasCriadas = true;
            }

            return cnx;
        }

    }
}
