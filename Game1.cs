using DefaultEcs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2dbullethell;

public class Game1 : Game
{
    private Texture2D playerTexture;

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
        _world = new World();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        playerTexture = Content.Load<Texture2D>("Player");

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _spriteBatch.Draw(playerTexture, new Vector2(0, 0), Color.White);
        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
