using System;
using System.Collections.Generic;
    abstract class PesananTransportasi
    {
        // Encapsulation 
        private string namaPenumpang;
        private string idPesanan;
        private string lokasiTujuan;

        public string NamaPenumpang
        {
            get { return namaPenumpang; }
            set { namaPenumpang = value; }
        }
        public string IdPesanan
        {
            get { return idPesanan; }
            set { idPesanan = value; }
        }
        public string LokasiTujuan
        {
            get { return lokasiTujuan; }
            set { lokasiTujuan = value; }
        }

        // Constructor
        public PesananTransportasi(string namaPenumpang, string idPesanan, string lokasiTujuan)
        {
            NamaPenumpang = namaPenumpang;
            IdPesanan = idPesanan;
            LokasiTujuan = lokasiTujuan;
        }
        // Method umum
        public void TampilInfo()
        {
            Console.WriteLine("Nama : " + NamaPenumpang + "| ID : " + IdPesanan + " | Tujuan : " + LokasiTujuan);
        }
        //  Metode Abstract
        public abstract double HitungTarif(double jarakKm);
    }

    //Inheritance 
    class LayananMotor : PesananTransportasi
    {
        public double TarifPerKm { get; set; }
        public LayananMotor(string namaPenumpang, string idPesanan, string lokasiTujuan, double tarifPerKm) : base(namaPenumpang, idPesanan, lokasiTujuan)
        {
            TarifPerKm = tarifPerKm;
        }
        public override double HitungTarif(double jarakKm)
        {
            return jarakKm * TarifPerKm;
        }
    } 
    class LayananMobil : PesananTransportasi
    {
        public double TarifPerKm { get; set; }
        public double BiayaTol { get; set; }
        public LayananMobil(string namaPenumpang,string idPesanan,string lokasiTujuan,double tarifPerKm,double biayaTol) : base(namaPenumpang, idPesanan, lokasiTujuan)
        {
            TarifPerKm = tarifPerKm;
            BiayaTol = biayaTol;
        }

        // Polymorphism
        public override double HitungTarif(double jarakKm)
        {
            return (jarakKm * TarifPerKm) + BiayaTol;
        }
    }

    class RiwayatPerjalanan
    {
        public string JenisLayanan { get; set; }
        public double JarakKm { get; set; }
        public DateTime TanggalPesan { get; set; }
        public RiwayatPerjalanan(string jenisLayanan, double jarakKm)
        {
            JenisLayanan = jenisLayanan;
            JarakKm = jarakKm;
            TanggalPesan = DateTime.Now;
        }
    }
    class ManajemenRiwayat
    {
        private List<RiwayatPerjalanan> daftarRiwayat =
        new List<RiwayatPerjalanan>();
        public void TambahPerjalanan(RiwayatPerjalanan perjalanan)
{ 
            daftarRiwayat.Add(perjalanan);
        }
        public void CetakRiwayat()
        {
            foreach (var item in daftarRiwayat)
            {
                Console.WriteLine(
                $" {item.JenisLayanan} | {item.JarakKm} Km | {item.TanggalPesan} ");
            }
        }
    }

    class Program
    {
    static void Main(string[] args)
    {
        LayananMobil mobil = new LayananMobil(
        "Budi",
        "TRX01",
        "Stasiun",
        6000,
        5000);
        double jarakMobil = 10;
        //Console.WriteLine("\n===== PESANAN MOBIL =====");
        mobil.TampilInfo();
        //Console.WriteLine("Jarak : " + jarakMobil + " Km");
        Console.WriteLine("Total : Rp " +
        mobil.HitungTarif(jarakMobil));
        // Riwayat perjalanan
        ManajemenRiwayat riwayat = new ManajemenRiwayat();
        //riwayat.TambahPerjalanan(
        // new RiwayatPerjalanan("Motor", jarakMotor));
        riwayat.TambahPerjalanan(
        new RiwayatPerjalanan("Mobil", jarakMobil));
        riwayat.CetakRiwayat();
    }
}