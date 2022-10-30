namespace Transhumanism.Engine.Video;

public class GammaRamp
{
    public ushort[] Red { get; set; }
    public ushort[] Green { get; set; }
    public ushort[] Blue { get; set; }

    public GammaRamp(in ushort[] red, in ushort[] green, in ushort[] blue)
    {
        Red = red;
        Green = green;
        Blue = blue;
    }
}
