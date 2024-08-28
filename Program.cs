

using System.ComponentModel;

namespace UniversiteSistemi
{
    public interface IDisplayable 
    {
        void DisplayInfo();
    }

    //  Fakulte elemanı ekleme çıkarma ve gösterme methodu içeren, universitenin adi ve constructorını içeren sınıf
    public class Universite
    {
        private string universiteAdi;
        private List<Fakulte> fakulteler = new List<Fakulte>();


        public Universite(string _universiteAdi)
        {
            this.universiteAdi = _universiteAdi;
        }

        public string UniversiteAdi
        {
            get { return universiteAdi; }
            set { universiteAdi = value; }
        }


        public void FakulteEkle(Fakulte _yeniFakulte)
        {
            fakulteler.Add(_yeniFakulte);
        }

        public void FakulteCikar(Fakulte _yeniFakulte)
        {
            fakulteler.Remove(_yeniFakulte);
        }

        public void FakulteleriGoster()
        {
            for (int i = 0; i < fakulteler.Count; i++)
                Console.WriteLine(fakulteler[i].FakulteAdi); // Fakülte adını yazdırmak için FakulteAdi özelliğine property yoluyla eriştim
        }



    }

    public class Fakulte 
    {
        private string fakulteAdi;
        private List<Bolum> bolumler = new List<Bolum>();
        private OgretimUyesi dekan { get; set; }

        public Fakulte(string _fakulteAdi, List<Bolum> _bolumler, OgretimUyesi _dekan)
        {
            this.fakulteAdi = _fakulteAdi;
            this.dekan = _dekan;
            bolumler = _bolumler;

        }

        public string FakulteAdi
        {
            get { return fakulteAdi; }
            set { fakulteAdi = value; }
        }

        public void BolumEkle(Bolum _yeniBolum)
        {
            bolumler.Add(_yeniBolum);
        }

        public void BolumCikar(Bolum _yeniBolum)
        {
            bolumler.Remove(_yeniBolum);
        }

        public void BolumleriGoster()
        {
            for (int i = 0; i < bolumler.Count; i++)
                Console.WriteLine(bolumler[i].BolumAdi);
        }


    }

    public class Bolum
    {
        private string bolumAdi;
        private List<OgretimUyesi> ogretimUyeleri;
        private List<Ogrenci> ogrenciler;

        public Bolum(string _bolumAdi, List<OgretimUyesi> _ogretimUyeleri, List<Ogrenci> _ogrenciler)
        {
            this.bolumAdi = _bolumAdi;
            this.ogretimUyeleri = _ogretimUyeleri;
            this.ogrenciler = _ogrenciler;
        }

        public string BolumAdi
        {
            get { return bolumAdi; }
            set { bolumAdi = value; }
        }

        public List<Ogrenci> Ogrenciler
        {
            get { return ogrenciler; }
        }

        public void OgretimUyesiEkle(OgretimUyesi _ogretimUyesi) // ogretimUyeleri listesine yeni üye ekler
        {
            ogretimUyeleri.Add(_ogretimUyesi);
        }

        public void OgrenciEkle(Ogrenci _yeniOgrenci) // ogrenciler listesine yeni ögrenci ekler
        {
            ogrenciler.Add(_yeniOgrenci);
        }

        public void OgrencileriListele()
        {
            foreach (var ogrenci in ogrenciler)
            {
                Console.WriteLine(ogrenci.Ad + " " + ogrenci.Soyad);
            }
        }



    }


    public class Kisi // öğretim üyesi ve öğrencinin inherite edileceği sınıf 
    {
        private string ad;
        private string soyad;
        private int TCKN;

        public Kisi(string _ad, string _soyad, int _TCKN)
        {
            this.ad = _ad;
            this.soyad = _soyad;
            this.TCKN = _TCKN;
        }

        public string Ad
        {
            get { return ad; }
        }

        public string Soyad
        {
            get { return soyad; }
        }

        public virtual void DersleriListele() // override edilmesi için base method
        {

        }


    }

    public class OgretimUyesi : Kisi, IDisplayable
    {
        private string unvan;
        private List<Ders> dersListesi;

        public OgretimUyesi(string _ad, string _soyad, int _TCKN, string _unvan, List<Ders> dersListesi) : base(_ad, _soyad, _TCKN)
        {
            this.unvan = _unvan;
            this.dersListesi = dersListesi;
        }

        public void OgretmeneDersEKle(Ders _ders) // öğretim üyesine ders ekler
        {
            dersListesi.Add(_ders);
        }

        public void OgretmendenDersCikart(Ders _ders) // çıkartır
        {
            dersListesi.Remove(_ders);

        }

        public override void DersleriListele()
        {
            base.DersleriListele();

            Console.WriteLine(dersListesi);
        }

        public void DisplayInfo() // interfaceden kullanılan method
        {
            Console.WriteLine("Öğretim üyesi : " +  Ad + " " + Soyad + " " + "Ünvan : " + unvan);
        }
    }



    public class Ogrenci : Kisi
    {
        private int ogrenciNum;
        private Bolum kayitliBolum;
        private List<Ders> kayitliDersler;
        public Ogrenci(string _ad, string _soyad, int _TCKN, int ogrenciNum, Bolum kayitliBolum, List<Ders> kayitliDersler) : base(_ad, _soyad, _TCKN)
        {
            this.ogrenciNum = ogrenciNum;
            this.kayitliBolum = kayitliBolum;
            this.kayitliDersler = kayitliDersler;
        }

        public void DerseOgrenciEkle(Ders _yeniDers) // kayıtlı dersler listesine Ders ekler
        {
            kayitliDersler.Add(_yeniDers);
        }

        public void DerstenOgrenciCikart(Ders _yeniDers) // çıkartır
        {
            kayitliDersler.Remove(_yeniDers);
        }

        public override void DersleriListele() // override edilen listeleme methodu
        {
            base.DersleriListele();

            foreach (var ders in kayitliDersler)
            {
                Console.WriteLine($"{ders.DersAdi} {ders.Kredi}");
            }
        }

        public List<Ders> KayitliDersler
        {
            get {  return kayitliDersler; }
        }

        public void DisplayInfo() // interfaceden kullanılan method
        {
            Console.WriteLine("Öğrenci : " + Ad + " " + Soyad + " " + "Numara " + ogrenciNum);
        }


    }

    public class Ders
    {
        private string dersAdi;
        private int kredi;
        private OgretimUyesi dersinOgretmeni;
        private List<Ogrenci> ogrenciListesi;

        public Ders(string dersAdi, int kredi, OgretimUyesi dersinOgretmeni, List<Ogrenci> ogrenciListesi)
        {
            this.dersAdi = dersAdi;
            this.kredi = kredi;
            this.dersinOgretmeni = dersinOgretmeni;
            this.ogrenciListesi = ogrenciListesi;
        }

        // private değerler için propertyler
        public string DersAdi
        {
            get { return dersAdi; }
            set { dersAdi = value; }
        }

        public int Kredi
        {
            get { return kredi; }
            set { kredi = value; }
        }

        public List<Ogrenci> OgrenciListesi
        {
            get { return ogrenciListesi; }
           
        }

        public void BilgileriGoster() // dersin tüm bilgilerini gösteren method
        {
            Console.WriteLine(dersAdi + " " + kredi + " " + dersinOgretmeni.Ad + "\nSınıf listesi :");

            foreach (var ogrenci in ogrenciListesi)
            {
                Console.WriteLine(ogrenci.Ad);
            }
        }

        public void OgrenciEkle(Ogrenci _yeniOgrenci) // listeye öprenci ekler
        {
            ogrenciListesi.Add(_yeniOgrenci);
        }


    }







    public class Program
    {
        public static void Main(string[] args)
        {
            Universite universite = new Universite("Marmara Üniversitesi");

            OgretimUyesi dekan = new OgretimUyesi("Mahmut", "Korkmaz", 1231241232, "Dekan", new List<Ders>());

            Fakulte muhendislik = new Fakulte("Mühendislik Fakültesi", new List<Bolum>(), dekan);
            Fakulte tip = new Fakulte("Tıp Fakültesi", new List<Bolum>(), dekan);


            Bolum kimyaMuhendislik = new Bolum("Kimya Mühendisliği", new List<OgretimUyesi>(), new List<Ogrenci>());
            Bolum pcMuhendislik = new Bolum("Bilgisayar Mühendisliği", new List<OgretimUyesi>(), new List<Ogrenci>());

            OgretimUyesi ogretimUyesi_1 = new OgretimUyesi("Ogretim Uye1", "Bla", 1231241232, "Öğretim Üyesi", new List<Ders>());
            OgretimUyesi ogretimUyesi_2 = new OgretimUyesi("Ogretim Uye2", "Bla", 1231241232, "Öğretim Üyesi", new List<Ders>());

            Ders biyokimya101 = new Ders("Biyokimya", 5, ogretimUyesi_1, new List<Ogrenci>());
            Ders basitkimya101 = new Ders("Basit Kimya", 5, ogretimUyesi_1, new List<Ogrenci>());
            Ders pc101 = new Ders("pc101", 5, ogretimUyesi_2, new List<Ogrenci>());

            
            Ogrenci ogrenci_1 = new Ogrenci("batuhan", "koçak", 1231231, 1555 ,kimyaMuhendislik, new List<Ders>());
            Ogrenci ogrenci_2 = new Ogrenci("ahmet", "koçak", 1231231, 1555 ,kimyaMuhendislik, new List<Ders>());
            
            
            universite.FakulteEkle(muhendislik);
            universite.FakulteEkle(tip);

            muhendislik.BolumEkle(kimyaMuhendislik);
            muhendislik.BolumEkle(pcMuhendislik);

            muhendislik.BolumleriGoster();
            Console.WriteLine();


            kimyaMuhendislik.OgrenciEkle(ogrenci_1);
            kimyaMuhendislik.OgretimUyesiEkle(ogretimUyesi_1);

            ogretimUyesi_1.OgretmeneDersEKle(biyokimya101);
            ogretimUyesi_1.OgretmeneDersEKle(basitkimya101);

            ogretimUyesi_1.DisplayInfo();
            ogrenci_1.DisplayInfo();


            ogrenci_1.DerseOgrenciEkle(biyokimya101);

            ogrenci_1.DersleriListele();
            Console.WriteLine();

            
            biyokimya101.OgrenciEkle(ogrenci_1);
            biyokimya101.OgrenciEkle(ogrenci_2);

            biyokimya101.BilgileriGoster();


            //////////////////////////////////////////
            
            
            




        }
    }
}