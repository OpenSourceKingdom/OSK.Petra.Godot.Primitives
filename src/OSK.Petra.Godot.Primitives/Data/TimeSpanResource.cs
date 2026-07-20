using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSK.Petra.Godot.Primitives.Data;

[Tool]
[GlobalClass]
public partial class TimeSpanResource : Resource
{
    #region Variables

    [Export]
    private int _hours;

    [Export]
    private int _minutes;

    [Export]
    private int _seconds;

    [Export]
    private int _milliseconds;

    #endregion

    #region Api

    /// <summary>
    /// Gets a timespan equivalent to the resource
    /// </summary>
    /// <returns></returns>
    public TimeSpan Value
        => new TimeSpan(days: 0, hours: _hours, minutes: _minutes, seconds: _seconds, milliseconds: _milliseconds);

    /// <summary>
    /// Create a TimeSpan directly from a TimeSpanResource
    /// </summary>
    /// <param name="timeSpanResource"></param>
    public static implicit operator TimeSpan(TimeSpanResource timeSpanResource)
        => timeSpanResource.Value;

    #endregion
}
