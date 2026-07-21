using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSK.Petra.Godot.Primitives.Data.Nullables;

/// <summary>
/// Represents a timespan resource that is optionally set in the editor
/// </summary>
[Tool]
[GlobalClass]
public partial class NullableTimeSpan: NullableResource<TimeSpan>
{
    #region Variables

    private TimeSpanResource _timeSpanResource;

    [Export]
    private TimeSpanResource _value
    {
        get => _timeSpanResource;
        set
        {
            _timeSpanResource = value;
            SetValue(_timeSpanResource.Value);
        }
    }

    #endregion
}
