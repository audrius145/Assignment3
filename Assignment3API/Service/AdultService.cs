using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Assignment3API.Model;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Assignment3API.Service
{
    public class AdultService: IAdultService

    {
    private string AdultFile = "adults.json";
    private IList<Adult> adults;
  

    public AdultService()
    {
        if (!File.Exists(AdultFile))
        {
            
            adults = new List<Adult>();
            WriteAdultsToFile();
        }
        else
        {
            ReadAdultsFromFile();
        }
    }

    private void WriteAdultsToFile()
    {
        string productAsJson = JsonSerializer.Serialize(adults);
        File.WriteAllText(AdultFile, productAsJson);
    }

    private void ReadAdultsFromFile()
    {
        using StreamReader r = new StreamReader("adults.json");
        string json = r.ReadToEnd();
        adults = JsonConvert.DeserializeObject<List<Adult>>(json);
    }

    public async Task<IList<Adult>> getAdultsAsync()
    {
        var tmp = new List<Adult>(adults);
        return tmp;
    }

    public async Task<Adult> AddAdultAsync(Adult adult)
    {
        int max = adults.Max(adult => adult.Id);
        adult.Id = ++max;
        adults.Add(adult);
        WriteAdultsToFile();
        return adult;
    }

    public async Task RemoveAdultAsync(int adultID)
    {
        Adult toRemove = adults.First(t => t.Id == adultID);
        adults.Remove(toRemove);
        WriteAdultsToFile();
        
    }
    }
}