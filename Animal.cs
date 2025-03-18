#pragma warning disable 

using System;
using System.Threading.Tasks;

public abstract class Animal : IFeedable, ICleanable, IAnimalActions, IStatus
{
    public string Name { get; }
    private int FeedCount { get; set; }
    private bool IsHappy { get; set; }
    private DateTime LastFed { get; set; }
    public bool IsAlive { get; private set; }

    // Events
    public event Action OnAnimalHungry;
    public event Action OnAnimalOverfed;
    public event Action OnAnimalStarved;

    // Internal state for tracking the time without feeding
    private DateTime _lastCheckTime;

    public Animal(string name)
    {
        Name = name;
        FeedCount = 0;
        IsHappy = false;
        LastFed = DateTime.Now;
        IsAlive = true;
        _lastCheckTime = DateTime.Now;

        MonitorHealth();
    }

    public abstract void PerformAction();

    public async void MonitorHealth()
    {
        while (IsAlive)
        {
            await Task.Delay(5000); // Check health every 5 seconds
            CheckForDeath();
        }
    }

    public void Feed()
    {
        if (!IsAlive)
        {
            Console.WriteLine($"{Name} is dead and cannot be fed.");
            return;
        }

        FeedCount++;
        LastFed = DateTime.Now;
        _lastCheckTime = DateTime.Now; // Reset the starvation check time

        if (FeedCount > 5)
        {
            Console.WriteLine($"{Name} has eaten too much and has died from overeating.");
            IsAlive = false;
            OnAnimalOverfed?.Invoke();
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
            Console.WriteLine($"{Name} is happy because it's clean!");
        }
        else
        {
            Console.WriteLine($"{Name} is dead and cannot be cleaned.");
        }
    }

    public void ShowStatus()
    {
        Console.WriteLine(IsAlive ? $"{Name} is alive. Fed {FeedCount} times today. Happy: {IsHappy}" : $"{Name} is dead.");
    }

    public void CheckForDeath()
    {
        if (!IsAlive)
        {
            return; // If the animal is dead, stop checking for starvation
        }

        // Simulate 24 hours as 15 seconds
        int simulatedTimeInSeconds = 15;

        // If 20 seconds have passed without feeding, the animal dies
        if ((DateTime.Now - _lastCheckTime).TotalSeconds >= simulatedTimeInSeconds)
        {
            IsAlive = false;
            OnAnimalStarved?.Invoke();
            Console.WriteLine($"{Name} has died from starvation after {simulatedTimeInSeconds} seconds (simulating 24 hours without food).");
        }
    }
}
