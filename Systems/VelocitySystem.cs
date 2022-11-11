using _2dbullethell.Components;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace _2dbullethell.Systems;

public class VelocitySystem : EntityUpdateSystem
{
    private ComponentMapper<Velocity> _velocityMapper;
    private ComponentMapper<Transform2> _transformMapper;

    public VelocitySystem() : base(Aspect.All(typeof(Velocity), typeof(Transform2)))
    {
    }

    public override void Initialize(IComponentMapperService mapperService)
    {
        _velocityMapper = mapperService.GetMapper<Velocity>();
        _transformMapper = mapperService.GetMapper<Transform2>();
    }

    public override void Update(GameTime gameTime)
    {
        foreach (var entityId in ActiveEntities)
        {
            var velocity = _velocityMapper.Get(entityId);
            var transform = _transformMapper.Get(entityId);

            var traveledDistance = Vector2.Multiply(velocity.Value, gameTime.ElapsedGameTime.Milliseconds / 1000f);

            transform.Position += traveledDistance;
        }
    }
}
