using MattEland.GameDev.VirtualWorld.CrossPlatform;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MattEland.GameDev.VirtualWorld.Mono.Desktop
{
    public sealed class VirtualWorldGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private readonly VirtualWorldGameInfo _gameInfo;

        private Texture2D _target;

        public VirtualWorldGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _gameInfo = new VirtualWorldGameInfo();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Window.Title = _gameInfo.Title;

            _graphics.PreferredBackBufferWidth = _gameInfo.WindowWidth;
            _graphics.PreferredBackBufferHeight = _gameInfo.WindowHeight;
            _graphics.ApplyChanges();
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _target = Content.Load<Texture2D>("8x");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            //_spriteBatch.DrawString(_font, _gameInfo.Title, new Vector2(0,0), Color.Black);
            _spriteBatch.Draw(_target, new Vector2(0,0), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}