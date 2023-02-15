namespace MattEland.GameDev.VirtualWorld.CrossPlatform;

public static class Vector2Extensions
{
    public static Vector2 Offset(this Vector2 origin, float deltaX, float deltaY)
    {
        return new Vector2(origin.X + deltaX, origin.Y + deltaY);
    }
}