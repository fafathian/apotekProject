using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace apotek.Models
{
    public partial class Obat
    {
        public Obat()
        {
            Transaksi = new HashSet<Transaksi>();
        }

        public int IdObat { get; set; }
        [DisplayName("Nama Obat")]
        public string NamaObat { get; set; }
        [DisplayName("Jenis Obat")]
        public string JenisObat { get; set; }
        public int? Harga { get; set; }
        public int? Quantity { get; set; }

        public ICollection<Transaksi> Transaksi { get; set; }
    }
}
