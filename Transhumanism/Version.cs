using System.Text;

namespace Transhumanism;

public static class Version
{
    public const int MAJOR = 0;
    public const int MINOR = 1;
    public const int REVISION = 0;
    public const string? PRERELEASE = null;
    public const string? BUILD = null;

    public static string GetVersion()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append($"{MAJOR}.{MINOR}.{REVISION}");

#if DEBUG
        if ( !string.IsNullOrEmpty(PRERELEASE) )
        {
            stringBuilder.Append($"-{PRERELEASE}");
        }

        if ( !string.IsNullOrEmpty(BUILD) )
        {
            stringBuilder.Append($"+{BUILD}");
        }
#endif
        return stringBuilder.ToString();
    }
}
