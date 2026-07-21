using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSK.Petra.Godot.Primitives.Data;

/// <summary>
/// Provides a nullable base class for variant style resources 
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract partial class NullableVariant<[MustBeVariant] T>: NullableResource<T>
    where T : struct
{
    #region Variables

    private Variant _value
    {
        get => HasValue ? Variant.From(Value) : default;
        set => SetValue(value.As<T>());
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a nullable variant resource using the default value
    /// </summary>
    protected NullableVariant() 
        : base() 
    { 
    }

    /// <summary>
    /// Creates a nullable variant resource using the provided value
    /// </summary>
    /// <param name="value">The variant value</param>
    protected NullableVariant(T? value) 
        : base(value)
    {
        if (value.HasValue)
        {
            _value = Variant.From(value.Value);
        }
    }

    #endregion

    #region Resource Overrides

    /// <inheritdoc/>
    public override Array<Dictionary> _GetPropertyList()
    {
        return new((Dictionary[])[ 
            new Dictionary
            {
                { "name", nameof(_value) },
                { "type", (int)GetVariantTypeFromSystem(typeof(T)) },
                { "usage", (int)PropertyUsageFlags.Default }
            }
        ]);
    }

    #endregion

    #region Helpers

    private Variant.Type GetVariantTypeFromSystem(Type type)
    {
        return type switch
        {
            _ when type == typeof(bool) => Variant.Type.Bool,
            _ when type == typeof(int) ||
                   type == typeof(long) ||
                   type == typeof(byte) ||
                   type == typeof(short) => Variant.Type.Int,
            _ when type == typeof(float) ||
                   type == typeof(double) => Variant.Type.Float,
            _ when type == typeof(string) => Variant.Type.String,

            // Math Primitives
            _ when type == typeof(Vector2) => Variant.Type.Vector2,
            _ when type == typeof(Vector3) => Variant.Type.Vector3,
            _ when type == typeof(Vector4) => Variant.Type.Vector4,
            _ when type == typeof(Rect2) => Variant.Type.Rect2,
            _ when type == typeof(Transform2D) => Variant.Type.Transform2D,
            _ when type == typeof(Transform3D) => Variant.Type.Transform3D,
            _ when type == typeof(Projection) => Variant.Type.Projection,
            _ when type == typeof(Basis) => Variant.Type.Basis,
            _ when type == typeof(Quaternion) => Variant.Type.Quaternion,
            _ when type == typeof(Plane) => Variant.Type.Plane,
            _ when type == typeof(Color) => Variant.Type.Color,

            // Godot Engine Handles
            _ when type == typeof(Rid) => Variant.Type.Rid,
            _ when type == typeof(Callable) => Variant.Type.Callable,
            _ when type == typeof(Signal) => Variant.Type.Signal,

            // Fallback
            _ => Variant.Type.Object
        };
    }

    #endregion
}
