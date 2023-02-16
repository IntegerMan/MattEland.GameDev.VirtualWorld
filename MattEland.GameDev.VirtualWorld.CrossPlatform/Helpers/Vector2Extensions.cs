namespace MattEland.GameDev.VirtualWorld.CrossPlatform.Helpers;

public static class Vector2Extensions
{
    public static Vector2 Offset(this Vector2 origin, float deltaX, float deltaY) =>
        new(origin.X + deltaX, origin.Y + deltaY);

    public static Vector2 Offset(this Vector2 origin, Vector2 delta) 
        => origin.Offset(delta.X, delta.Y);
}