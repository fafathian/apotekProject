using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace apotek.Models
{
    public partial class Apoteker
    {
        public Apoteker()
        {
            Transaksi = new HashSet<Transaksi>();
        }

        public int IdApoteker { get; set; }
        [DisplayName("Nama Apoteker")]
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<Transaksi> Transaksi { get; set; }
    }
}
