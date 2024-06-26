using System.IO;
using Newtonsoft.Json;

public class BankTransferConfig
{
    public string Lang { get; set; }
    public int Threshold { get; set; }
    public int LowFee { get; set; }
    public int HighFee { get; set; }
    public string[] Methods { get; set; }
    public Confirmation ConfirmationInfo { get; set; }

    public class Confirmation
    {
        public string En { get; set; }
        public string Id { get; set; }
    }

    public BankTransferConfig()
    {
        LoadConfig();
    }

     private void LoadConfig()
    {
        try
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                JsonDocument document = JsonDocument.Parse(json);

                JsonElement root = document.RootElement;
                Lang = root.GetProperty("lang").GetString();
                Threshold = root.GetProperty("transfer").GetProperty("threshold").GetInt32();
                LowFee = root.GetProperty("transfer").GetProperty("low_fee").GetInt32();
                HighFee = root.GetProperty("transfer").GetProperty("high_fee").GetInt32();
                Methods = root.GetProperty("methods").EnumerateArray().Select(x => x.GetString()).ToArray();
                Confirmation = new Confirmation
                {
                    En = root.GetProperty("confirmation").GetProperty("en").GetString(),
                    Id = root.GetProperty("confirmation").GetProperty("id").GetString()
                };
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Configuration file not found. Using default values.");
        }
    }
}
