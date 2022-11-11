using System;

namespace _2dbullethell.Components;

public class Weapon
{
    public bool IsShooting;
    public TimeSpan TimeBetweenEachShot; 
    public TimeSpan TimeSinceLastFire;

    public Weapon()
    {
        IsShooting = false;
        TimeBetweenEachShot = new TimeSpan();
        TimeSinceLastFire = new TimeSpan();
    }
}