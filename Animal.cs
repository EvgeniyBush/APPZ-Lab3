#pragma warning disable 

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public abstract class Animal : IFeedable, ICleanable, IAnimalActions, IStatus
{
    public string Name { get; }
    private int FeedCount { get; set; }
    private bool IsHappy { get; set; }
    private DateTime LastFed { get; set; }
    public bool IsAlive { get; private set; }

    // Івент для спостереження за змінами стану тварини
    public event Action<string> StatusChanged;

    public Animal(string name)
    {
        Name = name;
        FeedCount = 0;
        IsHappy = false;
        LastFed = DateTime.Now;
        IsAlive = true;

        MonitorHealth();
    }

    // Повідомлення для спостерігачів через івент
    protected void NotifyStatusChanged(string message)
    {
        StatusChanged?.Invoke(message);
    }

    public abstract void PerformAction();

    // Моніторинг здоров'я тварини
    public async void MonitorHealth()
    {
        while (IsAlive)
        {
            await Task.Delay(5000);
            CheckForDeath();
        }
    }

    public void Feed()
    {
        if (!IsAlive)
        {
            Console.WriteLine($"{Name} is dead.");
            return;
        }

        FeedCount++;
        LastFed = DateTime.Now;

        if (FeedCount > 5)
        {
            Console.WriteLine($"{Name} overate and died.");
            IsAlive = false;
            NotifyStatusChanged($"{Name} has died from overeating!");
        }
        else
        {
            Console.WriteLine($"{Name} is fed.");
        }
    }

    public void Clean()
    {
        if (IsAlive)
        {
            IsHappy = true;
            Console.WriteLine($"{Name} is now clean and happy!");
        }
    }

    public void ShowStatus()
    {
        Console.WriteLine(IsAlive ? $"{Name} is alive. Fed {FeedCount} times. Happy: {IsHappy}" : $"{Name} is dead.");
    }

    public void CheckForDeath()
    {
        if (!IsAlive) return;

        if ((DateTime.Now - LastFed).TotalSeconds >= 15)
        {
            IsAlive = false;
            NotifyStatusChanged($"{Name} has died from starvation!");
        }
    }
}
