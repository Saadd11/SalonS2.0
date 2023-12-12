using System.Text.Json.Serialization;
using System.Xml;

namespace SalonS.Services;

public class KundeRepositoryJson
{
    /*
     * Instans
     */
    private string _filePath;


    public KundeRepositoryJson(string path) 
    {
        this._filePath = path;
    }

    public static List<T> ReadFromJson<T>(string filePath)
    {
        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonContent.DeserializeObject<List<T>>(jsonString);
        }
        else
        {
            Console.WriteLine("Error Json");
            return new List<T>();
        }
    }

    public static void WriteToJson<T>(List<T> list, string filePath)
    {
        try
        {
            string output = JsonConverter.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(filePath, output);
        } catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

}
}