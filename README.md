Demonstration of how to support `msbuild/r` (msbuild with nuget package restore) when adding `<ProjectReference/>` via targets.

# Use Case

You may want to dynamically calculate which projects to include in your build based on configuration such as licensing.
Thus, you develop an MSBuild target which runs prior to `BeforeResolveReferences` to dynamically scan for and add optional projects by adding `<ProjectReference/>`.
However, you find that these dynamically added `<ProjectReference/>` are ignored by the restore phase of `msbuild/r`.

# Implementation

See [Runner/Build/AddDynamicReferences.targets](Runner/Build/AddDynamicReferences.targets).

# Pitfalls

## Visual Studio

Dynamically adding `<PackageReference/>` is only supported by `msbuild` itself.
Visual Studio manages build dependencies internally and does not provide a reasonable way to recognize dependencies added by targets.
You may choose to instruct Visual Studio to always invoke `msbuild` for builds (is that possible?) or have special logic to write dependencies to files and `<Error/>` out and touch the project file to force VS users to reload the project when you detect that you are being built in VS.

## Private API

This solution relies on a private API.
I have opened https://github.com/NuGet/Home/issues/7288 to inquire about making this a supported scenario or discovering if there might be some other more acceptable mechanism to achieve the same effect.
