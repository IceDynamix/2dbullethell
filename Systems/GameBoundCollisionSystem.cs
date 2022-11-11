using _2dbullethell.Components;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace _2dbullethell.Systems;

public class GameBoundCollisionSystem : EntityUpdateSystem
{
    private ComponentMapper<Velocity> _velocityMapper;
    private ComponentMapper<PhysicalHitBox> _physicalHitBoxMapper;
    private ComponentMapper<Transform2> _transformMapper;

    private readonly GraphicsDeviceManager _graphics;

    public GameBoundCollisionSystem(GraphicsDeviceManager graphics) : base(Aspect.All(typeof(Player), typeof(PhysicalHitBox), typeof(Velocity), typeof(Transform2)))
    {
        _graphics = graphics;
    }

    public override void Initialize(IComponentMapperService mapperService)
    {
        _velocityMapper = mapperService.GetMapper<Velocity>();
        _physicalHitBoxMapper = mapperService.GetMapper<PhysicalHitBox>();
        _transformMapper = mapperService.GetMapper<Transform2>();
    }

    public override void Update(GameTime gameTime)
    {
        foreach (var entityId in ActiveEntities)
        {
            var velocity = _velocityMapper.Get(entityId);
            var transform = _transformMapper.Get(entityId);
            var hitBoxWidth = _physicalHitBoxMapper.Get(entityId).Width;
            var hitBoxHeight = _physicalHitBoxMapper.Get(entityId).Height;
            
            if (velocity.Value.X < 0f && transform.Position.X - hitBoxWidth <= 0f ||
                velocity.Value.X> 0f && transform.Position.X + hitBoxWidth >= _graphics.PreferredBackBufferWidth)
            {
                velocity.Value.X = 0f;
            }

            if (velocity.Value.Y < 0f && transform.Position.Y - hitBoxHeight <= 0f ||
                velocity.Value.Y > 0f && transform.Position.Y + hitBoxHeight >= _graphics.PreferredBackBufferHeight)
            {
                velocity.Value.Y = 0f;
            }

        }
    }
}