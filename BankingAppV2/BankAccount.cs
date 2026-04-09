using System;
using System.Collections.Generic;
using System.IO;

class BankAccount
{
    public decimal Balance { get; private set; }

    public List<string> History { get; private set; }

    private string filePath;

    public BankAccount(string userName)
    {
        filePath = userName.ToLower() + "_data.txt";
        History = new List<string>();
        LoadData();

    }

    public bool Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            return false;
        }
        Balance += amount;
        string record = $"Deposited: {amount} on {DateTime.Now}";
        History.Add(record);
        SaveData();
        return true;

    }
    public bool Withdraw(decimal amount)
    {
        if (amount <= 0 || amount > Balance)
        {
            return false;
        }
        Balance -= amount;
        string record = $"Withdraw: {amount} on {DateTime.Now}";
        History.Add(record);
        SaveData();
        return true;
    }
    public void ShowHistory()
    {
        foreach (string item in History)
        {
            Console.WriteLine(item);
        }
    }

    public void SaveData()
    {
        List<string> lines = new List<string>();
        lines.Add(Balance.ToString());
        lines.AddRange(History);

        File.WriteAllLines(filePath, lines);

    }
    public void LoadData()
    {
        if (!File.Exists(filePath))
        {
            return;
        }
        var lines = File.ReadAllLines(filePath);
        if (lines.Length > 0)
        {
            Balance = Convert.ToDecimal(lines[0]);
            for (int i = 1; i < lines.Length; i++)
            {
                History.Add(lines[i]);
            }
        }
    }


}


