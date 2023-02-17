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
            Vector2 desiredPos = Position.Offset(desiredMovementDelta);

            // Check for collision
            if (context.IsValidMove(desiredPos, this))
            {
                Position = desiredPos;
            }
        }
    }

    private static Vector2 DetermineMovementDelta(GameContext context)
    {
        // Pull key states
        bool rightPressed = context.IsKeyPressed(Keys.D) || context.IsKeyPressed(Keys.Right);
        bool leftPressed = context.IsKeyPressed(Keys.A) || context.IsKeyPressed(Keys.Left);
        bool upPressed = context.IsKeyPressed(Keys.W) || context.IsKeyPressed(Keys.Up);
        bool downPressed = context.IsKeyPressed(Keys.S) || context.IsKeyPressed(Keys.Down);

        // X Axis
        int deltaX = GetAxisValue(rightPressed, leftPressed);
        int deltaY = GetAxisValue(downPressed, upPressed);

        return new Vector2(deltaX, deltaY);
    }

    private static int GetAxisValue(bool increasePressed, bool decreasePressed)
    {
        if (increasePressed)
        {
            return 1;
        }
        if (decreasePressed)
        {
            return -1;
        }

        return 0;
    }

    public override void Render(GameContext context)
    {
        Vector2 screenPos = ToScreenPos(VirtualWorldGame.ScreenTileSize);

        Rectangle targetRect = new((int)screenPos.X, (int)screenPos.Y, VirtualWorldGame.ScreenTileSize, VirtualWorldGame.ScreenTileSize);

        context.Sprites.Draw(_texture, targetRect, _sourceRect, Color.White);
    }
}
