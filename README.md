# OSK.Petra.Godot.Primitives

Provides foundational data structures and essential Godot objects designed to span across the entire Petra ecosystem.

## PetraFramework Details

Due to Godot's requirement of needing the node, resource, and other godot specific types to physically exist within the `res://` filesystem in order for Godot to register them within its inspector, 
Petra Godot's implementation utilizes a common, dedicated `PetraFramework` directory:
```
your-project/
└── PetraFramework/
    └── OSK.Petra.Godot.Primitives/
        ├── Data/
        └── Scripts/
    └── ... // Other petra projects
```

To ensure the Petra framework and suite works with your project, please note the following:
- Install the desired nuget packages for the petra framework you are using, then do a build of the project within Visual Studio/etc. to ensure the source files are infused with the godot project and inspector
- *Do Not Modify Injected Files*: The files inside the PetraFramework/ directory are completely transient. Any manual edits, refactors, or changes you make will be overwritten during the next project build, or worse, cause type definition mismatches with the compiled binaries.
- *The petra system is setup to pull in transitive dependencies automatically*: installing Package B and building should pull in Package A and its related Godot specific assets. If you encounter issues with this, please file a bug on the repository.
- **GitIgnore Recommended:** The Petra Godot implementation automatically injects a dedicated directory alongside your codebase during builds. To keep your source control true to your codebase, add the folder to your `.gitignore` file, as an example:
  ```text
  **/PetraFramework/
  ```
## Removal & Cleanup
If you are wanting to remove the package from your project, be sure to delete the related package within the PetraFramework directory after removing the package from your project.