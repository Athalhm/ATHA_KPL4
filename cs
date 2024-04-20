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
            using (StreamReader r = new StreamReader("bank_transfer_config.json"))
            {
                string json = r.ReadToEnd();
                dynamic configData = JsonConvert.DeserializeObject(json);

                Lang = configData.lang != null ? configData.lang : "en";
                Threshold = configData.transfer != null && configData.transfer.threshold != null ? (int)configData.transfer.threshold : 25000000;
                LowFee = configData.transfer != null && configData.transfer.low_fee != null ? (int)configData.transfer.low_fee : 6500;
                HighFee = configData.transfer != null && configData.transfer.high_fee != null ? (int)configData.transfer.high_fee : 15000;
                Methods = configData.methods != null ? configData.methods.ToObject<string[]>() : new string[] { "RTO (real-time)", "SKN", "RTGS", "BI FAST" };
                ConfirmationInfo = new Confirmation
                {
                    En = configData.confirmation != null && configData.confirmation.en != null ? configData.confirmation.en : "yes",
                    Id = configData.confirmation != null && configData.confirmation.id != null ? configData.confirmation.id : "ya"
                };
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Configuration file not found. Using default values.");
        }
    }
}
