using VKIApp.Domain;


namespace VKI.Presentation.Console.UI
{
        public class Program
    {
        public static void Main()
        {
            MenuGoster();
        }

        private static void MenuGoster()
        {
            Console.WriteLine("1. Yeni Hasta Kaydı\n2.Kayıtlı Hasta Listesi\n3.Kayıtlı Hasta Bul\n4.Çıkış");
            MenuSelection();
        }

        private static void MenuSelection()
        {
            Console.WriteLine("Seçiminiz : ");
            string choose = Console.ReadLine();
        switch (choose)
        {
            case "1": NewPatient();
                break;
            case "2": LoadPatient();
                break ;
            case "3": FindPatient();
                break ;
            case "4": Environment.Exit(0);
                break ;
            default: MenuSelection();
                break ;
        }


    }

    private static void FindPatient()
    {
        Console.WriteLine("Kanal adı içinde geçen kelimeyi yazın : ");
        string filterKeyword = Console.ReadLine();
        var data = VKIService.FilterByPatient(filterKeyword);
        PrintList(data);
    }

    private static void LoadPatient()
    {
        var list = VKIService.GetAllPatient();
        PrintList(list);
    }

    static void PrintList(IReadOnlyCollection<VKI> list)
    {
        Console.WriteLine("----------- Liste Başlangıcı ----------");
        foreach (VKI v in list)
        {
            Console.WriteLine(v.VKIInfo()); 
            Console.WriteLine("--------------------------------------");
        }
        Console.WriteLine("----------- Liste Sonu ----------");
        Again();
    }

    private static void NewPatient()
    {
        Console.WriteLine("Hasta Adı: ");
        string name = Console.ReadLine();
        Console.WriteLine("Hasta Soyadı: ");
        string surname= Console.ReadLine();
        Console.WriteLine("Hasta Yaşı : ");
        short age = Convert.ToInt16(Console.ReadLine());
        Console.WriteLine("Hastanın Cinsiyeti : ");
        string boyOrGirl = Console.ReadLine();

        Console.WriteLine("Hastanın Boyu : ");
        double height = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Kilonuzu kg cinsinden giriniz:");
        short weight = Convert.ToInt16(Console.ReadLine());

        var data = VKIService.SaveVKI(name, surname, age, boyOrGirl, height, weight);

        Console.WriteLine("Vücut Kitle İndeksiniz:" + data.VKIHesap());
        Console.WriteLine("Test Sonucu:" + data.TeshisSonucu());

        Again();

    }

    static void Again()
    {
        Console.WriteLine("Menüye Dönmek İçin Enter");
        Console.ReadLine();
        MenuGoster();
    }
    }
}