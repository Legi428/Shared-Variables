# Shared Variables

Adds save support to list and name variable components of Game Creator 2 shared across save slots but using the native save system.

# How to use?:

- Use the new `Shared List Variables` or `Shared Name Variables` components to save certain variables using this system.

- You can use the already existing ways of setting and retrieving data that you're used to from `Local List Variables` and `Local Name Variables`.

- To access data across scenes you can have a component with the wanted data on each and have this component use the same ID. Game Creator 2 will automatically load the data on scene change and you can access it there.

### Dependencies

This package requires Game Creator 2 to work and should be compatible with all Unity versions that Game Creator 2 supports.

### Constraints/Known Issues

- Using the special selector for variable names doesn't work in the inspector. This is due to how Game Creator 2 is setupand isn't easily resolved.

### How to Contribute:

Feel free to contribute to this development by forking this repository or just create issues!

### How to Install:

Use the Package Manager to install this package using the following git URL:

`https://github.com/Legi428/Shared-Variables.git`