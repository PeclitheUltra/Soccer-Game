using System;

public class SignalBus
{
    public static Action Scored, GameEnded, GameStarted, HitABall;
    public static Action<string, int> PlayerFinished;
}
