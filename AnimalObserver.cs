#pragma warning disable 

using System;

public class AnimalObserver : IObserver<string>
{
    private IDisposable unsubscriber;

    public void Subscribe(IObservable<string> provider)
    {
        unsubscriber = provider.Subscribe(this);
    }

    public void Unsubscribe()
    {
        unsubscriber.Dispose();
    }

    public void OnNext(string value)
    {
        Console.WriteLine($"[Notification]: {value}");
    }

    public void OnError(Exception error)
    {
        Console.WriteLine($"[Error]: {error.Message}");
    }

    public void OnCompleted()
    {
        Console.WriteLine("[Notification]: No more updates.");
    }
}
