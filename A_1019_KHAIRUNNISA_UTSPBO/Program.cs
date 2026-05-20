//Console.WriteLine("Hello, World!");

//Sebuah perusahaan teknologi bernama OOPRide mengembangkan sistem aplikasi untuk layanan transportasi online. Sistem ini harus mencatat data penumpang, jenis layanan kendaraan, serta menghitung tarif perjalanan berdasarkan jarak tempuh dan jenis kendaraan yang dipesan. Anda diminta untuk merancang program berbasis OOP menggunakan empat pilar utama (Encapsulation, Inheritance, Polymorphism, dan Abstraction). Adapun syarat yang harus dipenuhi sebagai berikut: 1.Encapsulation  Buatlah kelas PesananTransportasi yang memiliki atribut yang bersifat private: ● namaPenumpang ● idPesanan ● lokasiTujuan Sediakan getter dan setter agar data dapat diakses dengan aman. Tambahkan metode tampilInfo() untuk menampilkan informasi pesanan. 2. Inheritance  Buatlah dua kelas turunan dari PesananTransportasi, yaitu: ● LayananMotor: layanan ojek online roda dua. ● LayananMobil : layanan taksi online roda empat. Masing-masing kelas memiliki atribut tambahan: ● LayananMotor: tarifPerKm ● LayananMobil: tarifPerKm, biayaTol Gunakan konsep pewarisan untuk mengambil atribut dasar dari PesananTransportasi. 3. Polymorphism Tambahkan metode hitungTarif() yang didefinisikan di kelas induk PesananTransportasi (sebagai metode abstrak). Override metode tersebut pada kelas turunan dengan rumus berbeda: ● LayananMotor: total = jarakKm × tarifPerKm ● LayananMobil: total = (jarakKm × tarifPerKm) + biayaTol 4. Abstraction Jadikan kelas PesananTransportasi sebagai kelas abstrak agar tidak bisa diinstansiasi langsung. Kelas ini harus memiliki: ● Metode abstrak hitungTarif() ● Metode umum tampilInfo() 5. Tambahan (optional) Buat kelas RiwayatPerjalanan yang menyimpan: ● jenisLayanan(Motor / Mobil) ● jarakKm ● tanggalPesan Hubungkan kelas ini dengan PesananTransportasi menggunakan composition. Tambahkan metode tambahPerjalanan() dan cetakRiwayat(). 
abstract class PesananTransportasi
{
    private string namaPenumpang
    {
        get; set;
    }
    
    private string idPesanan
    {
        get; set;
    }
    private string lokasiTujuan
    {
        get; set;
    }

    public void tampilInfo(string namaPenumpang, string idPesanan, string lokasiTujuan)
    {
        Console.WriteLine($"Nama: {namaPenumpang} | ID: {idPesanan} | Tujuan: {lokasiTujuan}");
    }

    public virtual double HitungTarif(double jarakKm)
    {
        return jarakKm * 10;
    }

}

class LayananMotor : PesananTransportasi
{
    private double tarifPerKm
    {
        get; set;
    }
    public override double HitungTarif(double jarakKm)
    {
        return jarakKm * tarifPerKm;
    }
}

class LayananMobil : PesananTransportasi
{
    private double tarifPerKm
    {
        get; set;
    }
    private double biayaTol
    {
        get; set;
    }

    
    public void HitungTarif(double jarakKm)
    {   
        tarifPerKm += 600;
        biayaTol = 500;
        Console.WriteLine($"Total: Rp {(jarakKm * tarifPerKm) + biayaTol}");
    }
}

class RiwayatPerjalanan
{
    private string jenisLayanan
    {
        get; set;
    }
    private double jarakKm
    {
        get; set;
    }
    private string tanggalPesan
    {
        get; set;
    }
    public void tambahPerjalanan(string jenisLayanan, double jarakKm, string tanggalPesan)
    {
        this.jenisLayanan = jenisLayanan;
        this.jarakKm = jarakKm;
        this.tanggalPesan = tanggalPesan;
    }
    public void cetakRiwayat()
    {
        Console.WriteLine($"1. {jenisLayanan} | {jarakKm} km | {tanggalPesan} ");
    }
}

class Program
{
    static void Main(string[] args)
    {
        //LayananMotor motor = new LayananMotor();            
        //motor.TampilInfo("Aca", "TRX01", "sTASIUN");
        //Console.WriteLine($"Total: Rp{motor.HitungTarif(10)}");

        LayananMobil mobil = new LayananMobil();
        //mobil.(tarifPerKm) = 50.0;
        
        mobil.tampilInfo("Budi", "TRX01", "Stasiun");
        mobil.HitungTarif(10);
        RiwayatPerjalanan riwayat = new RiwayatPerjalanan();
        riwayat.tambahPerjalanan("Mobil", 10, "10-10-2025");
        riwayat.cetakRiwayat();

        //
    }
}