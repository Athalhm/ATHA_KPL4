using System;
using System.Collections.Generic;

public class KodePos
{
    private Dictionary<string, string> kodePos;

    public KodePos()
    {
        kodePos = new Dictionary<string, string>
        {
            {"Batununggal", "40266"},
            {"Kujangsari", "40287"},
            {"Mengger", "40267"},
            {"Wates", "40256"},
            {"Cijaura", "40287"},
            {"Jatisari", "40286"},
            {"Margasari", "40286"},
            {"Sekejati", "40286"},
            {"Kebonwaru", "40272"},
            {"Maleer", "40274"},
            {"Samoja", "40273"}
        };
    }

    public string GetKodePos(string kelurahan)
    {
        if (kodePos.ContainsKey(kelurahan))
        {
            return kodePos[kelurahan];
        }
        else
        {
            return "Kode Pos Tidak Ditemukan!";
        }
    }
}

public enum DoorState
{
    Terkunci,
    Terbuka
}

public class DoorMachine
{
    private DoorState currentState;

    public DoorMachine()
    {
        currentState = DoorState.Terkunci;
    }

    public void BukaPintu()
    {
        currentState = DoorState.Terbuka;
        Console.WriteLine("Pintu terbuka.");
    }

    public void KunciPintu()
    {
        currentState = DoorState.Terkunci;
        Console.WriteLine("Pintu dikunci.");
    }
}

class Program
{
    static void Main(string[] args)
    {

        KodePos kodePosObj = new KodePos();
        string kelurahan = "Jatisari";
        string kodePos = kodePosObj.GetKodePos(kelurahan);
        Console.WriteLine($"Kode Pos {kelurahan}: {kodePos}");

        kelurahan = "Cijaura";
        kodePos = kodePosObj.GetKodePos(kelurahan);
        Console.WriteLine($"Kode Pos {kelurahan}: {kodePos}");

        kelurahan = "Margasari";
        kodePos = kodePosObj.GetKodePos(kelurahan);
        Console.WriteLine($"Kode Pos {kelurahan}: {kodePos}");

        DoorMachine doorMachine = new DoorMachine();
        doorMachine.KunciPintu();
        doorMachine.BukaPintu();

    }
}
