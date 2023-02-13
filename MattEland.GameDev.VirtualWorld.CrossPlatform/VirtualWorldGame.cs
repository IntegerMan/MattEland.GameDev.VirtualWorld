using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MattEland.GameDev.VirtualWorld.CrossPlatform
{
    public sealed class VirtualWorldGame : Game
    {
        private const int SourceTileSize = 8;
        private const int ScreenTileSize = 16;
        private readonly GraphicsDeviceManager _graphics;
        private readonly VirtualWorldGameInfo _gameInfo;
        private SpriteBatch _spriteBatch;

        private readonly List<TileInfo> _tiles;

        private Texture2D _target;
        private readonly Rectangle _wallTileRect = new(47,85,SourceTileSize,SourceTileSize);

        public VirtualWorldGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _gameInfo = new VirtualWorldGameInfo();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // Program some basic tiles
            // TODO: Let's load these from a data file, probably involving Tiled in the process
            _tiles = new List<TileInfo>
            {
                new(1, 2),
                new(2, 2),
                new(3, 2),
                new(1, 3)
            };
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
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            //_spriteBatch.DrawString(_font, _gameInfo.Title, new Vector2(0,0), Color.White);

            // Draw some game tiles
            foreach (TileInfo tile in _tiles)
            {
                Vector2 screenPos = tile.ToScreenPos(ScreenTileSize);
                Rectangle targetRect = new((int)screenPos.X, (int)screenPos.Y, ScreenTileSize, ScreenTileSize);
                _spriteBatch.Draw(_target, targetRect, _wallTileRect, Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}