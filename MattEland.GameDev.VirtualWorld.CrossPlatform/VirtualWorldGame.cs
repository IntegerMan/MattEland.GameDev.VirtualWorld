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
        private SpriteFont _font;

        private readonly List<TileInfo> _tiles;

        private Texture2D _target;
        private readonly Rectangle _wallTileRect = new(47,85,SourceTileSize,SourceTileSize);
        private readonly Rectangle _floorTileRect = new(65,85,SourceTileSize,SourceTileSize);

        public VirtualWorldGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _gameInfo = new VirtualWorldGameInfo();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // Program some basic tiles
            // TODO: Let's load these from a data file, probably involving Tiled in the process
            _tiles = new List<TileInfo>();
            
            for (int y = 5; y < 25; y++)
            {
                for (int x = 1; x < 25; x++)
                {
                    TileType tileType;
                    if (x == 1 || x == 24 || y == 5 || y == 24)
                    {
                        tileType = TileType.Wall;
                    } 
                    else
                    {
                        tileType = TileType.Floor;
                    }

                    _tiles.Add(new TileInfo(x, y, tileType));
                }
            }
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
            _font = Content.Load<SpriteFont>("default");
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
            _spriteBatch.DrawString(_font, _gameInfo.Title, new Vector2(0,0), Color.White);

            // Draw some game tiles
            foreach (TileInfo tile in _tiles)
            {
                Vector2 screenPos = tile.ToScreenPos(ScreenTileSize);

                Rectangle targetRect = new((int)screenPos.X, (int)screenPos.Y, ScreenTileSize, ScreenTileSize);
                Rectangle sourceRect = tile.TileType == TileType.Wall ? _wallTileRect : _floorTileRect;

                _spriteBatch.Draw(_target, targetRect, sourceRect, Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}