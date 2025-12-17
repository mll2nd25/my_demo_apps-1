using System.Text.RegularExpressions;
using Angle.API.Services.Interfaces;

namespace Angle.API.Services;

public partial class CalcService : ICalcService
{
    private const string regexPattern = @"^(0?[1-9]|1[0-2]):[0-5][0-9]$";

    public string CalculateAngle(TimeModel model)
    {
        if (!string.IsNullOrWhiteSpace(model.Time) && MyRegex().IsMatch(model.Time))
            return CalcByTime(model.Time);
        if (int.TryParse(model.Hour, out int hour) && int.TryParse(model.Minute, out int minute))
            return CalcByHourMinute(hour, minute);

        throw new ArgumentException($"Arg does not supply valid time values.");
    }

    #region PRIVATE METHODS

    private string CalcByHourMinute(int hour, int min)
    {
        int origin;
        double angleByMin, angleByHr, angleTotal;

        origin = hour % 12;
        angleByMin = min * 6;
        angleByHr = (origin * 30) + (min * 0.5);
        angleTotal = angleByHr + angleByMin;

        return $"{angleTotal} degrees";
    }
    private string CalcByTime(string time)
    {        
        int hour, minute;

        string[] timeArr = time.Split(':');

        // Data validation
        if (!int.TryParse(timeArr[0], out hour) || !int.TryParse(timeArr[1], out minute))
            throw new ArgumentException($"Time Arg value supplied: {time} is invalid.");

        return CalcByHourMinute(hour, minute);
    }

    [GeneratedRegex(regexPattern)]
    private static partial Regex MyRegex();
    
    #endregion
}
