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
public abstract partial class NullableResource<T> : Resource
    where T: struct
{
    #region Variables

    private bool _isEnabled;

    [Export]
    private bool _enabled 
    {
        get => _isEnabled;
        set 
        {
            _isEnabled = value;
            if (_underlyingValue is null)
            {
                _underlyingValue = default(T);
            }
        }
    }

    private T? _underlyingValue;

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a nullable resource, with the default value
    /// </summary>
    protected NullableResource()
    {
    }

    /// <summary>
    /// Creates a nullable resource, using the provided value
    /// </summary>
    /// <param name="value"></param>
    protected NullableResource(T? value)
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
        get => HasValue ? _underlyingValue.Value : throw new InvalidOperationException("Unable to get a value for a nullable that has not been set.");
    }

    /// <summary>
    /// Describes whether the value has been set in the editor
    /// </summary>
    [MemberNotNullWhen(true, nameof(_underlyingValue))]
    public bool HasValue => _underlyingValue is not null;

    /// <summary>
    /// Gets the value of the resource, returning the fallback value if it was not set
    /// </summary>
    /// <param name="fallback"></param>
    /// <returns></returns>
    public T GetValueOrDefault(T fallback = default) => _enabled ? Value : fallback;

    /// <summary>
    /// Converts the resource to the equivalent nullable type
    /// </summary>
    /// <param name="nullableResource"></param>
    public static implicit operator T?(NullableResource<T> nullableResource)
        => nullableResource.HasValue
            ? nullableResource.Value
            : null;

    #endregion

    #region Helpers

    /// <summary>
    /// Sets the underlying value for the nullable resource
    /// </summary>
    /// <param name="value"></param>
    protected void SetValue(T? value)
    {
        _underlyingValue = value;
        _enabled = value is not null;
    }

    #endregion
}
