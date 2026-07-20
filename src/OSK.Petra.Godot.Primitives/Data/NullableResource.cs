using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSK.Petra.Godot.Primitives.Data;

/// <summary>
/// Provides a resource that gives access to nullable style resources within the godot inspector
/// </summary>
/// <typeparam name="T"></typeparam>
public partial class NullableResource<T> : Resource
    where T : struct
{
    #region Variables

    [Export]
    private bool _enabled { get; set; }

    private T? _value;

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a nullable <see cref="T"/> resource, with the default value
    /// </summary>
    public NullableResource()
    {
    }

    /// <summary>
    /// Creates a nullable <see cref="T"/> resource, using the provided value
    /// </summary>
    /// <param name="value"></param>
    public NullableResource(T? value)
    {
        SetValue(value);
    }

    #endregion

    #region Api

    /// <summary>
    /// The value for the resource
    /// </summary>
    /// <remarks>
    /// 💡Notes:
    /// <list type="bullet">
    /// <item>This call will throw if the value has not been set, if wanting safe access to this value, please use <see cref="GetValueOrDefault(T)"/></item>
    /// </list>
    /// </remarks>
    public T Value
    {
        get => _enabled ? Value : throw new InvalidOperationException("Unable to get a value for a nullable that has not been set.");
    }

    /// <summary>
    /// Describes whether the value has been set in the editor
    /// </summary>
    [MemberNotNullWhen(true, nameof(Value))]
    public bool HasValue => _enabled;

    /// <summary>
    /// Gets the value of the resource, returning the fallback value if it was not set
    /// </summary>
    /// <param name="fallback"></param>
    /// <returns></returns>
    public T GetValueOrDefault(T fallback = default) => _enabled ? Value : fallback;

    /// <summary>
    /// Converts the resource to the equivalent nullable <see cref="T"/>
    /// </summary>
    /// <param name="nullableResource"></param>
    public static implicit operator T?(NullableResource<T> nullableResource)
        => nullableResource.HasValue
            ? nullableResource.Value
            : null;

    /// <summary>
    /// Converts the <see cref="T"/> to the equivalent nullable resource
    /// </summary>
    /// <param name="value"></param>
    public static implicit operator NullableResource<T>(T? value)
        => new(value);

    #endregion

    #region Helpers


    protected void SetValue(T? value)
    {
        _value = value;
        _enabled = value is not null;
    }

    #endregion
}
