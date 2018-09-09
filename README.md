Demonstration of how to support `msbuild/r` (msbuild with nuget package restore) when adding `<PackageReference/>` via targets.

# Use Case

You may want to dynamically calculate which projects to include in your build based on configuration such as licensing.

# Implementation

See [Runner/Build/AddDynamicReferences.targets](Runner/Build/AddDynamicReferences.targets).

# Pitfalls

Dynamically adding `<PackageReference/>` is only supported by `msbuild` itself.
Visual Studio manages build dependencies internally and does not provide a reasonable way to recognize dependencies added by targets.
You may choose to instruct Visual Studio to always invoke `msbuild` for builds (is that possible?) or have special logic to write dependencies to files and `<Error/>` out and touch the project file to force VS users to reload the project when you detect that you are being built in VS.
