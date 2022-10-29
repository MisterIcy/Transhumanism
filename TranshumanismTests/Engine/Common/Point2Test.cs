using Transhumanism.Engine.Common;

namespace TranshumanismTests.Engine.Common;

public class Point2Test
{
    [Fact]
    public void CreateNewPoint2()
    {
        var pt = new Point2(1, 2);
        Assert.Equal(1, pt.X);
        Assert.Equal(2, pt.Y);
    }

    [Fact]
    public void CreateNewPointFromValue()
    {
        var pt = new Point2(2);
        Assert.Equal(2, pt.X);
        Assert.Equal(2, pt.Y);
    }

    [Fact]
    public void CreateNewPointEmpty()
    {
        var pt = new Point2();
        Assert.Equal(0, pt.X);
        Assert.Equal(0, pt.Y);
    }
}