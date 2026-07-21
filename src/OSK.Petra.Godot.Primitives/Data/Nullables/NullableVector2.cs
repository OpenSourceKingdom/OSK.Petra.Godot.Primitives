using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSK.Petra.Godot.Primitives.Data.Nullables;

/// <summary>
/// Represents a vector2 resource that is optionally set in the editor
/// </summary>
[Tool]
[GlobalClass]
public partial class NullableVector2: NullableVariant<Vector2>
{
}
