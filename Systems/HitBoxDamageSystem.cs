using _2dbullethell.Components;
using _2dbullethell.Components.Objects;
using DefaultEcs;
using DefaultEcs.System;
using Microsoft.Xna.Framework;


namespace _2dbullethell.Systems;

public class HitBoxDamageSystem : AEntitySetSystem<float>
{
    public HitBoxDamageSystem(World world) : base(world.GetEntities().With<HitBox>().With<Transform>()
        .With<Damage>().AsSet())
    {
    }

    protected override void Update(float elapsedTime, in Entity entity)
    {
        
        ref HitBox hitbox = ref entity.Get<HitBox>();
        ref Transform transform = ref entity.Get<Transform>();
        ref Damage damage = ref entity.Get<Damage>();


        var healthSet = World.GetEntities().With<HitBox>().With<Transform>().With<Health>().AsEnumerable();


        foreach (var healthEntity in healthSet)
        {
            ref var transformHealthEntity = ref healthEntity.Get<Transform>();
            ref var hitBoxHealthEntity = ref healthEntity.Get<HitBox>();
            ref var healthHealthEntity = ref healthEntity.Get<Health>();

            if (healthEntity.Equals(entity)) continue;
            var distance = Vector2.Distance(transform.Position, transformHealthEntity.Position);
            if (distance - (hitbox.Radius + hitBoxHealthEntity.Radius) <= 0)
            {
                healthHealthEntity.Value -= damage.Value;
            }
        }
        
    }
}