using System;

public class BankTransferApp
{
    private BankTransferConfig config;

    public BankTransferApp(BankTransferConfig config)
    {
        this.config = config;
    }

    public void Run()
    {
        string lang = config.Lang;

        // Menampilkan pesan berdasarkan bahasa
        string insertMessage = lang == "en" ? "Please insert the amount of money to transfer:" : "Masukkan jumlah uang yang akan di-transfer:";
        Console.WriteLine(insertMessage);
        int transferAmount = Convert.ToInt32(Console.ReadLine());

        // Menghitung biaya transfer
        int transferFee = transferAmount <= config.Threshold ? config.LowFee : config.HighFee;
        int totalAmount = transferAmount + transferFee;

        // Menampilkan biaya transfer dan total biaya
        string feeMessage = lang == "en" ? "Transfer fee = " : "Biaya transfer = ";
        string totalMessage = lang == "en" ? "Total amount = " : "Total biaya = ";
        Console.WriteLine($"{feeMessage}{transferFee}");
        Console.WriteLine($"{totalMessage}{totalAmount}");

        // Menampilkan pesan untuk memilih metode transfer
        string selectMessage = lang == "en" ? "Select transfer method:" : "Pilih metode transfer:";
        Console.WriteLine(selectMessage);

        // Menampilkan metode transfer dari konfigurasi
        string[] methods = config.Methods;
        for (int i = 0; i < methods.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {methods[i]}");
        }

        // Meminta konfirmasi transaksi
        string confirmationMessage = lang == "en" ? $"Please type \"{config.Confirmation.En}\" to confirm the transaction:" : $"Ketik \"{config.Confirmation.Id}\" untuk mengkonfirmasi transaksi:";
        Console.WriteLine(confirmationMessage);
        string confirmationInput = Console.ReadLine();

        // Memproses konfirmasi
        string successMessage = lang == "en" ? "The transfer is completed" : "Proses transfer berhasil";
        string cancelMessage = lang == "en" ? "Transfer is cancelled" : "Transfer dibatalkan";
        string confirmationCode = lang == "en" ? config.Confirmation.En : config.Confirmation.Id;
        if (confirmationInput == confirmationCode)
        {
            Console.WriteLine(successMessage);
        }
        else
        {
            Console.WriteLine(cancelMessage);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Membuat objek BankTransferConfig
        BankTransferConfig bankConfig = new BankTransferConfig();

        // Membuat objek BankTransferApp dengan menggunakan BankTransferConfig
        BankTransferApp bankApp = new BankTransferApp(bankConfig);

        // Menjalankan aplikasi
        bankApp.Run();
    }
}
