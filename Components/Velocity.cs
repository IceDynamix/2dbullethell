using Microsoft.Xna.Framework;

namespace _2dbullethell.Components;

public class Velocity
{
    public Vector2 Value = Vector2.Zero;

    public Velocity()
    {
    }

    public Velocity(Vector2 vec)
    {
        Value = vec;
    }
}
