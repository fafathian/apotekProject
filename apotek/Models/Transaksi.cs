using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace apotek.Models
{
    public partial class Transaksi
    {
        public Transaksi()
        {
            Nota = new HashSet<Nota>();
        }

        public int IdTransaksi { get; set; }

        public int? IdObat { get; set; }

        public int? IdPembeli { get; set; }

        public int? IdApoteker { get; set; }
        [DisplayName("Tanggal Transaksi")]
        public DateTime? TglTransaksi { get; set; }
        [DisplayName("Total")]
        public int? TotalHarga { get; set; }
        [DisplayName("Nama Apoteker")]
        public Apoteker IdApotekerNavigation { get; set; }
        [DisplayName("Nama Obat")]
        public Obat IdObatNavigation { get; set; }
        [DisplayName("Nama Pembeli")]
        public Pembeli IdPembeliNavigation { get; set; }

        public ICollection<Nota> Nota { get; set; }
    }
}
