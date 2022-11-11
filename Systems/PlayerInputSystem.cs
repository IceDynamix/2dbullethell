using _2dbullethell.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace _2dbullethell.Systems;

public class PlayerInputSystem : EntityUpdateSystem
{
    private ComponentMapper<Velocity> _velocityMapper;

    public PlayerInputSystem() : base(Aspect.All(typeof(Player), typeof(Velocity)))
    {
    }

    public override void Initialize(IComponentMapperService mapperService)
    {
        _velocityMapper = mapperService.GetMapper<Velocity>();
    }

    public override void Update(GameTime gameTime)
    {
        const float baseVelocity = 10f;

        foreach (var entityId in ActiveEntities)
        {
            var velocity = _velocityMapper.Get(entityId);

            var nextDirection = Vector2.Zero;

            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.W)) nextDirection += new Vector2(0, -1);
            if (keyboardState.IsKeyDown(Keys.S)) nextDirection += new Vector2(0, 1);
            if (keyboardState.IsKeyDown(Keys.A)) nextDirection += new Vector2(-1, 0);
            if (keyboardState.IsKeyDown(Keys.D)) nextDirection += new Vector2(1, 0);

            var nextVelocity = nextDirection * baseVelocity * gameTime.ElapsedGameTime.Milliseconds;
            velocity.Value = nextVelocity;
        }
    }
}
