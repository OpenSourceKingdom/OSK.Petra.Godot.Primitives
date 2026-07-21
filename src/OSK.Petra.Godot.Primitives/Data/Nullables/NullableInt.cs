using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSK.Petra.Godot.Primitives.Data.Nullables;

/// <summary>
/// Represents an int resource that is optionally set in the editor
/// </summary>
[GlobalClass]
[Tool]
public partial class NullableInt: NullableVariant<int>
{
}
