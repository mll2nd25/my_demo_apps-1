using Angle.API.Services;

namespace Angle.API.Tests;

public class CalcServiceTest
{
    [Fact]
    public void Calc_AngleByTime()
    {
        // Arrange
        var model = new TimeModel { Time = "6:00" };
        var service = new CalcService();

        // Act
        var result = service.CalculateAngle(model);

        // Assert
        Assert.Equal("180 degrees", result);
    }

    [Fact]
    public void Calc_AngleByHourMin()
    {
        // Arrange
        var model = new TimeModel { Hour = "6", Minute = "15" };
        var service = new CalcService();

        // Act
        var result = service.CalculateAngle(model);

        // Assert
        Assert.Equal("277.5 degrees", result);
    }
}
