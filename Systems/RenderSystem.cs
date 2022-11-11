using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using MonoGame.Extended.Sprites;

namespace _2dbullethell.Systems;

public class RenderSystem : EntityDrawSystem
{
    private readonly SpriteBatch _spriteBatch;
    private ComponentMapper<Transform2> _transformMapper;
    private ComponentMapper<Sprite> _spriteMapper;

    public RenderSystem(SpriteBatch spriteBatch) : base(Aspect.All(typeof(Transform2), typeof(Sprite)))
    {
        _spriteBatch = spriteBatch;
    }

    public override void Initialize(IComponentMapperService mapperService)
    {
        _transformMapper = mapperService.GetMapper<Transform2>();
        _spriteMapper = mapperService.GetMapper<Sprite>();
    }

    public override void Draw(GameTime gameTime)
    {
        _spriteBatch.Begin();

        foreach (var entityId in ActiveEntities)
        {
            var transform = _transformMapper.Get(entityId);
            var sprite = _spriteMapper.Get(entityId);

            _spriteBatch.Draw(sprite, transform);
        }

        _spriteBatch.End();
    }
}
