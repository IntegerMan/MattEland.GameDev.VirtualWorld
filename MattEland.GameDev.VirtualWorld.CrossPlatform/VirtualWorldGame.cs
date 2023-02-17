using MattEland.GameDev.VirtualWorld.CrossPlatform.Engine;
using MattEland.GameDev.VirtualWorld.CrossPlatform.Entities;
using MattEland.GameDev.VirtualWorld.CrossPlatform.Entities.UI;

namespace MattEland.GameDev.VirtualWorld.CrossPlatform;

public sealed class VirtualWorldGame : Game
{
    public const int SourceTileSize = 16;
    public const int ScreenTileSize = 16;

    private GameContext? _context;

    private SpriteBatch? _spriteBatch;
    private SpriteFont? _font;
    private StatsObject? _stats;
    private Texture2D? _target;

    private readonly GraphicsDeviceManager _graphics;

    private readonly Rectangle _wallTileRect = new(0, 0, SourceTileSize, SourceTileSize);
    private readonly Rectangle _floorTileRect = new(16, 0, SourceTileSize, SourceTileSize);
    private readonly Rectangle _playerTileRect = new(32, 0, SourceTileSize, SourceTileSize);

    public VirtualWorldGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
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
        _context = new GameContext(_spriteBatch, GraphicsDevice);

        _target = Content.Load<Texture2D>("tilemaps/tileset");

        // Program some basic tiles
        // TODO: Let's load these from a data file, probably involving Tiled in the process
        for (int y = 5; y < 25; y++)
        {
            for (int x = 1; x < 25; x++)
            {
                TileType tileType;
                Rectangle sourceRect;
                if (x is 1 or 24 || y is 5 or 24)
                {
                    tileType = TileType.Wall;
                    sourceRect = _wallTileRect;
                }
                else
                {
                    tileType = TileType.Floor;
                    sourceRect = _floorTileRect;
                }

                _context.Add(new TileInfo(x, y, tileType, _target, sourceRect));
            }
        }

        // FPS Counter
        _font = Content.Load<SpriteFont>("fonts/stats");
        _stats = new StatsObject(_font, new Vector2(10, 10))
        {
            Title = Title
        };
        _context.Add(_stats);

        // Actor
        _context.Add(new Actor(2, 6, _target, _playerTileRect));
    }
    
    protected override void Update(GameTime gameTime)
    {
        _context!.Update(gameTime, false);

        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Exit();
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _context!.Sprites.Begin();
        _context.Update(gameTime, true);
        _context.Sprites.End();

        base.Draw(gameTime);
    }
}