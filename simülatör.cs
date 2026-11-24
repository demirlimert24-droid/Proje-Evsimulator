using System;


enum CihazTuru
{
    Lamba,
    Klima,
    GuvenlikSistemi
}

class Cihaz
{
    public int Kimlik { get; set; }
    public string Ad { get; set; }
    public CihazTuru Tur { get; set; }
    public bool AcikMi { get; set; }

    public Cihaz(int kimlik, string ad, CihazTuru tur)
    {
        Kimlik = kimlik;
        Ad = ad;
        Tur = tur;
        AcikMi = false;
    }

    public void Ac()
    {
        AcikMi = true;
    }

    public void Kapat()
    {
        AcikMi = false;
    }

    public void BilgileriGoster()
    {
        Console.WriteLine($"{Kimlik} - {Ad} - {Tur} - {(AcikMi ? "Açık" : "Kapalı")}");
    }
}

class Program
{
    static void Main()
    {
        List<Cihaz> cihazlar = new List<Cihaz>();
    }
}

