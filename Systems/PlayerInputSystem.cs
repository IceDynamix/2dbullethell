using _2dbullethell.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace _2dbullethell.Systems;

public class PlayerInputSystem : EntityUpdateSystem
{
    private ComponentMapper<Velocity> _velocityMapper;
    private ComponentMapper<Weapon> _weaponMapper;
    
    public PlayerInputSystem() : base(Aspect.All(typeof(Player), typeof(Velocity), typeof(Weapon)))
    {
    }

    public override void Initialize(IComponentMapperService mapperService)
    {
        _velocityMapper = mapperService.GetMapper<Velocity>();
        _weaponMapper = mapperService.GetMapper<Weapon>();
    }

    public override void Update(GameTime gameTime)
    {
        const float baseVelocity = 10f;

        foreach (var entityId in ActiveEntities)
        {
            var velocity = _velocityMapper.Get(entityId);
            var weapon = _weaponMapper.Get(entityId);

            var nextDirection = Vector2.Zero;

            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.W)) nextDirection += new Vector2(0, -1);
            if (keyboardState.IsKeyDown(Keys.S)) nextDirection += new Vector2(0, 1);
            if (keyboardState.IsKeyDown(Keys.A)) nextDirection += new Vector2(-1, 0);
            if (keyboardState.IsKeyDown(Keys.D)) nextDirection += new Vector2(1, 0);

            var nextVelocity = nextDirection * baseVelocity * gameTime.ElapsedGameTime.Milliseconds;
            velocity.Value = nextVelocity;

            var mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed) weapon.IsShooting = true;
            else weapon.IsShooting = false;
            
        }
    }
}
