using VKIApp.Data.IO;
using System.Text.Json;


namespace VKIApp.Domain
{
    public class VKIService
    {
        private static List<VKI> liste = new List<VKI>();

        public static VKI SaveVKI(string hastaAdi, string soyadi, short hastaYasi, string cinsiyet,double hastaninBoyu, double hastaninKilosu)
        {
            VKI vKI = new VKI();

            vKI.patientName = hastaAdi;
            vKI.patientSurname = soyadi;
            vKI.patientAge = hastaYasi;
            vKI.patientGender = cinsiyet;
            vKI.patientHeight = hastaninBoyu;
            vKI.patientWeight = hastaninKilosu;

            liste.Add(vKI);


            string json = JsonSerializer.Serialize(liste,
    new JsonSerializerOptions { IncludeFields = true });


            FileOperation.Write(json);

            return vKI;


        }
        public static IReadOnlyCollection<VKI> GetAllPatient()
        {
            LoadListFromFile();
            return liste.AsReadOnly();

        }
        public static IReadOnlyCollection<VKI> FilterByPatient(string hastaAdi)
        {
            LoadListFromFile();
            List<VKI> filteredByPatient = new List<VKI>();
            foreach (VKI v in liste)
            {
                if (v.patientName.ToLower().Contains(hastaAdi.ToLower()))
                filteredByPatient.Add(v);
            }
            return filteredByPatient.AsReadOnly();
        }

        private static void LoadListFromFile()
        {
            string json = FileOperation.Read();
            liste = JsonSerializer.Deserialize<List<VKI>>(json,
                new JsonSerializerOptions { IncludeFields = true });
        }
    }
}
