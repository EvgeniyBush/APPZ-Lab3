#pragma warning disable 

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public abstract class Animal : IFeedable, ICleanable, IAnimalActions, IStatus, IObservable<string>
{
    public string Name { get; }
    private int FeedCount { get; set; }
    private bool IsHappy { get; set; }
    private DateTime LastFed { get; set; }
    public bool IsAlive { get; private set; }

    private List<IObserver<string>> observers = new();

    public Animal(string name)
    {
        Name = name;
        FeedCount = 0;
        IsHappy = false;
        LastFed = DateTime.Now;
        IsAlive = true;

        MonitorHealth();
    }

    public IDisposable Subscribe(IObserver<string> observer)
    {
        if (!observers.Contains(observer))
            observers.Add(observer);
        return new Unsubscriber(observers, observer);
    }

    private class Unsubscriber : IDisposable
    {
        private List<IObserver<string>> _observers;
        private IObserver<string> _observer;

        public Unsubscriber(List<IObserver<string>> observers, IObserver<string> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observer != null && _observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }

    public void Notify(string message)
    {
        foreach (var observer in observers)
        {
            observer.OnNext(message);
        }
    }

    public abstract void PerformAction();

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
            Notify($"{Name} has died from overeating!");
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
            Notify($"{Name} has died from starvation!");
        }
    }
}
