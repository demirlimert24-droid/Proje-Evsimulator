using System;
using System.Collections.Generic;

enum CihazTuru
{
    Lamba = 1,
    Klima = 2,
    GuvenlikSistemi = 3
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
        List<Cihaz> cihazlar = new List<Cihaz>
        {
            new Cihaz(1, "Salon Lambası", CihazTuru.Lamba),
            new Cihaz(2, "Oturma Odası Kliması", CihazTuru.Klima),
            new Cihaz(3, "Giriş Kamerası", CihazTuru.GuvenlikSistemi)
        };

        while (true)
        {
            Console.WriteLine("\n1. Cihazları Listele");
            Console.WriteLine("2. Yeni Cihaz Ekle");
            Console.WriteLine("3. Cihaz Aç");
            Console.WriteLine("4. Cihaz Kapat");
            Console.WriteLine("0. Çıkış");
            Console.Write("Seçiminiz: ");
            string secim = Console.ReadLine() ?? "";

            if (secim == "0")
            {
                break;
            }
            else if (secim == "1")
            {
                foreach (Cihaz c in cihazlar)
                {
                    c.BilgileriGoster();
                }
            }
            else if (secim == "2")
            {
                Console.Write("Kimlik: ");
                if (!int.TryParse(Console.ReadLine(), out int kimlik))
                {
                    Console.WriteLine("Hata: Geçerli bir sayı giriniz!");
                    continue;
                }

                bool varMi = false;
                foreach (Cihaz c in cihazlar)
                {
                    if (c.Kimlik == kimlik)
                    {
                        varMi = true;
                        break;
                    }
                }

                if (varMi)
                {
                    Console.WriteLine("Hata: Bu kimliğe sahip bir cihaz zaten var!");
                    continue;
                }

                Console.Write("Ad: ");
                string ad = Console.ReadLine() ?? "";

                Console.Write("Tür (1: Lamba, 2: Klima, 3: GuvenlikSistemi): ");
                if (!int.TryParse(Console.ReadLine(), out int turSecim) || turSecim < 1 || turSecim > 3)
                {
                    Console.WriteLine("Hata: Geçersiz cihaz türü!");
                    continue;
                }

                cihazlar.Add(new Cihaz(kimlik, ad, (CihazTuru)turSecim));
                Console.WriteLine("Cihaz eklendi.");
            }
            else if (secim == "3" || secim == "4")
            {
                Console.Write("Cihaz Kimliği: ");
                if (!int.TryParse(Console.ReadLine(), out int kimlik))
                {
                    Console.WriteLine("Hata: Geçerli bir sayı giriniz!");
                    continue;
                }

                Cihaz? bulunan = null;
                foreach (Cihaz c in cihazlar)
                {
                    if (c.Kimlik == kimlik)
                    {
                        bulunan = c;
                        break;
                    }
                }

                if (bulunan == null)
                {
                    Console.WriteLine("Hata: Bu kimliğe sahip cihaz bulunamadı!");
                }
                else
                {
                    if (secim == "3")
                    {
                        bulunan.Ac();
                        Console.WriteLine("Cihaz açıldı.");
                    }
                    else
                    {
                        bulunan.Kapat();
                        Console.WriteLine("Cihaz kapatıldı.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Geçersiz seçim!");
            }
        }
    }
}

