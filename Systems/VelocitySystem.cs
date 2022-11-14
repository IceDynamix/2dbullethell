
using _2dbullethell.Components;
using DefaultEcs;
using DefaultEcs.System;


namespace _2dbullethell.Systems;

public class VelocitySystem : AEntitySetSystem<float>
{

    public VelocitySystem(World world) : base(world.GetEntities().With<Velocity>().With<Transform>().AsSet())
    {
    }

    protected override void Update(float elapsedTime, in Entity entity)
    {
        ref Transform transform = ref entity.Get<Transform>();
        ref Velocity velocity = ref entity.Get<Velocity>();

        transform.Position.X += elapsedTime * velocity.Value.X;
        transform.Position.Y += elapsedTime * velocity.Value.Y;
    }
    
}