using System.Text;

namespace VKIApp.Domain
{
    public class VKI
    {
        public VKI()
        {
            sayac++;
            patientNumber = sayac;
        }
        private static int sayac;
        private int patientNumber;
        public string patientName;
        public string patientSurname;
        public short patientAge;
        public string patientGender;
        public double patientHeight;
        public double patientWeight;

        public double VKIHesap()
        {
            return (patientWeight/(patientHeight*patientHeight));
        }
        static VKI boyKiloEndeksi = new VKI();
        public static double x1 = boyKiloEndeksi.VKIHesap();
        public string TeshisSonucu()
        {
            if (18.49 > boyKiloEndeksi.VKIHesap())
            {
                return "ZAYIF";
            }

            else if (18.50 <= x1 && x1 < 25)
            {
                return "İDEAL";
            }
            else if (25 <= x1 && x1 < 30)
            {
                return "HAFİF KİLOLU";
            }
            else if (30 <= x1)
            {
                return "OBEZ";
            }
            else
            {
                return "Bir problem var";
            }

        }
        public string  VKIInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Hasta No : {patientNumber}\n");
            sb.Append($"Hasta Adı Soyadı : {patientName}\t{patientSurname}\n");
            sb.Append($"Hastanın Yaşı : {patientAge}\n");
            sb.Append($"Hastanın Cinsiyeti (E / K) : {patientGender}\n");
            sb.Append($"Hastanın Boyu (m) : {patientHeight}\n");
            sb.Append($"Hastanın Kilosu (kg) : {patientWeight}\n");
            sb.Append($"Hastanın Vücut Kitle Endeksi : {patientHeight}\n");

            return sb.ToString();
        }


    }
}