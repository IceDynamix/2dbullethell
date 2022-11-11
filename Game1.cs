using _2dbullethell.Components;
using _2dbullethell.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Sprites;

namespace _2dbullethell;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private World _world;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _world = new WorldBuilder()
            .AddSystem(new VelocitySystem())
            .AddSystem(new RenderSystem(new SpriteBatch(GraphicsDevice)))
            .Build();

        Components.Add(_world);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        var player = _world.CreateEntity();
        player.Attach(new Player {Name = "Noah"});
        player.Attach(new Transform2
        {
            Scale = new Vector2(0.5f, 0.5f)
        });
        player.Attach(new Sprite(Content.Load<Texture2D>("player")));
        player.Attach(new Velocity(new Vector2(50f, 20f)));
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _world.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _world.Draw(gameTime);
        base.Draw(gameTime);
    }
}
