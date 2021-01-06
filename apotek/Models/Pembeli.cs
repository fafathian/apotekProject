using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace apotek.Models
{
    public partial class Pembeli
    {
        public Pembeli()
        {
            Transaksi = new HashSet<Transaksi>();
        }

        public int IdPembeli { get; set; }
        [DisplayName("Nama Pembeli")]
        public string UsernamePembeli { get; set; }
        public string PasswordPembeli { get; set; }

        public ICollection<Transaksi> Transaksi { get; set; }
    }
}
