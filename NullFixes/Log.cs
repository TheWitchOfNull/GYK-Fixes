using BepInEx.Logging;

namespace NullFixes;

public static class Log
{
    private static ManualLogSource _mls;

    public static void Initialize(ManualLogSource mls)
    {
        _mls = mls;
    }

    public static void Info(params object[] message)
    {
        string m = string.Join(" ", message);
        _mls.LogInfo(m);
    }

    public static void Warn(params object[] message)
    {
        string m = string.Join(" ", message);
        _mls.LogWarning(m);
    }

    public static void Error(params object[] message)
    {
        string m = string.Join(" ", message);
        _mls.LogError(m);
    }
}
