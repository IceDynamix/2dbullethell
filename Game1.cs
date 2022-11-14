
using System;
using _2dbullethell.Components;
using _2dbullethell.Components.Objects;
using _2dbullethell.Systems;
using DefaultEcs;
using DefaultEcs.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace _2dbullethell;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private World _world;
    private DrawSystem _drawSystem;
    private VelocitySystem _velocitySystem;
    private PlayerMovementInputSystem _playerMovementInputSystem;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = 1000;
        _graphics.PreferredBackBufferHeight = 1000;
        _graphics.ApplyChanges();

        _world = new World();

        _drawSystem = new DrawSystem(_world, new SpriteBatch(GraphicsDevice));
        _velocitySystem = new VelocitySystem(_world);
        _playerMovementInputSystem = new PlayerMovementInputSystem(_world);


        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        var texture = Content.Load<Texture2D>("player");

        var player = _world.CreateEntity();
        player.Set(new Sprite()
        {
            Texture = texture,
            Color = Color.White,
            Size = new Vector2(50,50),
        });
        player.Set(new Transform()
        {
            Position = new Vector2(100, 100),
            Rotation = 0,
            Scale = new Vector2(0.5f, 0.5f),
        });
        player.Set(new Player());
        player.Set(new Velocity());
    }
    

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        
  
        _velocitySystem.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
        _playerMovementInputSystem.Update((float)gameTime.ElapsedGameTime.Milliseconds);
        base.Update(gameTime);
      
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);  
        
        _drawSystem.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
        
        base.Draw(gameTime);
    }
}
