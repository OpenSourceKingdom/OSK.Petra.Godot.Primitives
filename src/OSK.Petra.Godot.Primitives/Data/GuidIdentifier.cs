using Godot;
using Godot.Collections;
using System;

namespace OSK.Petra.Godot.Primitives.Data;

/// <summary>
/// A uniqiue identfiier that can be generated and reloaded within a Godot editor
/// </summary>
[Tool]
[GlobalClass]
public partial class GuidIdentifier : Resource
{
    #region Variables

    [Export]
    private string _id;

    #endregion

    #region Constructors

    /// <summary>
    /// Generates a new empty identifier
    /// </summary>
    public GuidIdentifier()
    {
        _id = string.Empty;
        CallDeferred(nameof(Initialize));
    }

    #endregion

    #region Resource Overrides

    /// <inheritdoc/>
    public override void _ValidateProperty(Dictionary property)
    {
        if ((string)property["name"] == "_id")
        {
            property["usage"] = (int)(PropertyUsageFlags.Default | PropertyUsageFlags.ReadOnly);
        }
    }

    #endregion

    #region Api

    /// <summary>
    /// The unique identifier
    /// </summary>
    public Guid Id { get; private set; }

    #endregion

    #region Helpers

    public static implicit operator Guid(GuidIdentifier identifier)
        => identifier.Id;

    private void Initialize()
    {
        if (string.IsNullOrWhiteSpace(_id))
        {
            _id = Guid.NewGuid().ToString();
            GD.Print($"Initializing new guid identifier with Id: {_id}");
        }

        Id = Guid.Parse(_id);
    }

    #endregion
}
