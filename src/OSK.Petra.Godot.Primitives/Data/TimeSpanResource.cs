using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSK.Petra.Godot.Primitives.Data;

/// <summary>
/// Provides a resource that can be used to create and edit <see cref="TimeSpan"/> in the inspector
/// </summary>
[Tool]
[GlobalClass]
public partial class TimeSpanResource : Resource
{
    #region Variables

    [Export(PropertyHint.Range, "-23,23")]
    private int _hours;

    [Export(PropertyHint.Range, "-59,59")]
    private int _minutes;

    [Export(PropertyHint.Range, "-59,59")]
    private int _seconds;

    [Export(PropertyHint.Range, "-999,999")]
    private int _milliseconds;

    #endregion

    #region Constructors
    
    /// <summary>
    /// Creates a timespan resource with default values
    /// </summary>
    public TimeSpanResource()
    {

    }

    /// <summary>
    /// Creates a timespan resource utilizing the provided timespan's values
    /// </summary>
    /// <param name="timeSpan"></param>
    public TimeSpanResource(TimeSpan timeSpan)
    {
        _hours = timeSpan.Hours;
        _minutes = timeSpan.Minutes;
        _seconds = timeSpan.Seconds;
        _milliseconds = timeSpan.Milliseconds;
    }

    #endregion

    #region Api

    /// <summary>
    /// The timespan equivalent to the resource
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
