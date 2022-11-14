
using _2dbullethell.Components;
using _2dbullethell.Components.Objects;
using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using Microsoft.Xna.Framework.Input;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace _2dbullethell.Systems;

public class PlayerMovementInputSystem : AEntitySetSystem<float>
{

    private const float PlayerMovementSpeed = 100f;
    
    public PlayerMovementInputSystem(World world) : base(world.GetEntities().With<Player>().With<Velocity>().AsSet())
    {
    }
    
    protected override void Update(float elapsedTime, in Entity entity)
    {
        ref Velocity velocity = ref entity.Get<Velocity>();

        KeyboardState keyboardState = Keyboard.GetState();
        Vector2 newVelocity = new Vector2(0, 0);;
        
        if (keyboardState.IsKeyDown(Keys.W)) newVelocity += new Vector2(0 , -1);
        if (keyboardState.IsKeyDown(Keys.S)) newVelocity += new Vector2(0, 1);
        if (keyboardState.IsKeyDown(Keys.A)) newVelocity += new Vector2(-1, 0);
        if (keyboardState.IsKeyDown(Keys.D)) newVelocity += new Vector2(1, 0);
   

        velocity.Value = newVelocity * PlayerMovementSpeed * elapsedTime;


    }
}