using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AplicativoDespesas.Models
{
    class Despesa
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String nome { get; set; }

        public double valor { get; set; }

        public DateTime data { get; set; }

        public String parcelas { get; set; }


    }
}
