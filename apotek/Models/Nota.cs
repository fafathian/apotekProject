using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace apotek.Models
{
    public partial class Nota
    {
        public int IdNota { get; set; }
        [DisplayName("ID Transaksi")]
        public int? IdTransaksi { get; set; }
        [DisplayName("Total Harga")]
        public int? TotalHarga { get; set; }

        public Transaksi IdTransaksiNavigation { get; set; }
    }
}
