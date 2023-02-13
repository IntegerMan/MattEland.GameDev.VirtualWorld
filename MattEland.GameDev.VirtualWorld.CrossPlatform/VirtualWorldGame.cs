namespace MattEland.GameDev.VirtualWorld.CrossPlatform;

public sealed class VirtualWorldGame : Game
{
    private const int SourceTileSize = 8;
    private const int ScreenTileSize = 16;
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private SpriteFont _font;

    private readonly List<TileInfo> _tiles = new();
    private readonly List<Actor> _actors = new();

    private Texture2D _target;
    private readonly Rectangle _wallTileRect = new(47,85,SourceTileSize,SourceTileSize);
    private readonly Rectangle _floorTileRect = new(65,85,SourceTileSize,SourceTileSize);
    private readonly Rectangle _playerTileRect = new(68,1,SourceTileSize,SourceTileSize);

    public VirtualWorldGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        // Program some basic tiles
        // TODO: Let's load these from a data file, probably involving Tiled in the process
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

        _actors.Add(new Actor(15, 13));
    }

    public Version Version => new(0, 0, 1);
    public string VersionSuffix => " Prototype";
    public string Title => $"Virtual World v{Version}{VersionSuffix} by Matt Eland";

    public int WindowWidth => 800;
    public int WindowHeight => 600;

    protected override void Initialize()
    {
        Window.Title = Title;

        _graphics.PreferredBackBufferWidth = WindowWidth;
        _graphics.PreferredBackBufferHeight = WindowHeight;
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
        _spriteBatch.DrawString(_font, Title, new Vector2(0,0), Color.White);

        // Draw the game tiles
        foreach (TileInfo tile in _tiles)
        {
            Vector2 screenPos = tile.ToScreenPos(ScreenTileSize);

            Rectangle targetRect = new((int)screenPos.X, (int)screenPos.Y, ScreenTileSize, ScreenTileSize);
            Rectangle sourceRect = tile.TileType == TileType.Wall ? _wallTileRect : _floorTileRect;

            _spriteBatch.Draw(_target, targetRect, sourceRect, Color.White);
        }

        // Draw the actors
        foreach (Actor actor in _actors)
        {
            Vector2 screenPos = actor.ToScreenPos(ScreenTileSize);

            Rectangle targetRect = new((int)screenPos.X, (int)screenPos.Y, ScreenTileSize, ScreenTileSize);
            Rectangle sourceRect = _playerTileRect;

            // TODO: This is not drawing transparent. Might be a source image problem
            _spriteBatch.Draw(_target, targetRect, sourceRect, Color.White);
        }

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}