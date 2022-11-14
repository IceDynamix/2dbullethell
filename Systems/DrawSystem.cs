using _2dbullethell.Components;
using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using Microsoft.Xna.Framework.Graphics;

namespace _2dbullethell.Systems;

public class DrawSystem : AEntitySetSystem<float>
{
    private SpriteBatch _spriteBatch;
    
    public DrawSystem(World world, SpriteBatch spriteBatch) : base(world.GetEntities().With<Sprite>().With<Transform>().AsSet())
    {
        _spriteBatch = spriteBatch;
    }
    
    protected override void PreUpdate(float elapsedTime)
    {
        _spriteBatch.Begin();
    }

    protected override void Update(float elapsedTime, in Entity entity)
    {
        ref Sprite sprite = ref entity.Get<Sprite>();
        ref Transform transform = ref entity.Get<Transform>();
        
        _spriteBatch.Draw(sprite.Texture, transform.Position,null, sprite.Color, transform.Rotation, transform.Position, sprite.Size * transform.Scale, SpriteEffects.None, 0f );
    }

    protected override void PostUpdate(float elapsedTime)
    {
        _spriteBatch.End();
    }
    

   
}