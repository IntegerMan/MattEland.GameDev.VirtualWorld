namespace MattEland.GameDev.VirtualWorld.CrossPlatform;

public static class RandomExtensions
{
    public static float NextSingle(this Random random, float minValue, float maxValue)
    {
        float range = maxValue - minValue;

        return minValue + (random.NextSingle() * range);
    }
}