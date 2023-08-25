using System;

public class SignalBus
{
    public static Action Scored, GameEnded, GameStarted;
    public static Action<string, int> PlayerFinished;
}
