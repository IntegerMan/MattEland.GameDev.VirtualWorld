using MattEland.GameDev.VirtualWorld.CrossPlatform.Engine;
using MattEland.GameDev.VirtualWorld.CrossPlatform.Helpers;

namespace MattEland.GameDev.VirtualWorld.CrossPlatform.Entities;

public class Actor : WorldObjectBase
{
    private readonly Texture2D _texture;
    private readonly Rectangle _sourceRect;

    public Actor(float x, float y, Texture2D texture, Rectangle sourceRect) : base(x, y)
    {
        _texture = texture;
        _sourceRect = sourceRect;
    }

    public override void Update(GameContext context)
    {
        Vector2 desiredMovementDelta = DetermineMovementDelta(context);

        // Actually move the player
        if (desiredMovementDelta.Length() != 0)
        {
            // TODO: Check for collision!
            Position = Position.Offset(desiredMovementDelta);
        }
    }

    private static Vector2 DetermineMovementDelta(GameContext context)
    {
        bool rightPressed = context.IsKeyPressed(Keys.D) || context.IsKeyPressed(Keys.Right);
        bool leftPressed = context.IsKeyPressed(Keys.A) || context.IsKeyPressed(Keys.Left);
        bool upPressed = context.IsKeyPressed(Keys.W) || context.IsKeyPressed(Keys.Up);
        bool downPressed = context.IsKeyPressed(Keys.S) || context.IsKeyPressed(Keys.Down);

        int deltaX = 0;
        int deltaY = 0;

        if (rightPressed)
        {
            deltaX++;
        }
        else if (leftPressed)
        {
            deltaX--;
        }

        if (upPressed)
        {
            deltaY--;
        }
        else if (downPressed)
        {
            deltaY++;
        }

        return new Vector2(deltaX, deltaY);
    }

    public override void Render(GameContext context)
    {
        Vector2 screenPos = ToScreenPos(VirtualWorldGame.ScreenTileSize);

        Rectangle targetRect = new((int)screenPos.X, (int)screenPos.Y, VirtualWorldGame.ScreenTileSize, VirtualWorldGame.ScreenTileSize);

        context.Sprites.Draw(_texture, targetRect, _sourceRect, Color.White);
    }
}
