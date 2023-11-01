# CADExtension Plugin Project

## Description

This project is a C# plugin for AutoCAD that provides two commands:

1. **DrawColumn**: This command allows the user to create a column application plan by providing information through a user interface.

2. **AddIntersectionPoints**: This command detects intersections between polylines and adds vertices at those intersection points.

## Features

- **DrawColumn Command**:
  - Prompts the user for column information (e.g., section, height, reinforcement).
  - Generates a column application plan based on the provided information.
  - Displays the plan in the AutoCAD environment.

- **AddIntersectionPoints Command**:
  - Identifies intersections between existing polylines.
  - Inserts vertices at the intersection points to enhance precision.

## How to Use

### Installing CADExtension Plugin

1. **Install AutoCAD**:
   - Ensure you have AutoCAD installed on your system. If not, you can download and install it from the [official AutoCAD website](https://www.autodesk.com/products/autocad/overview).

2. **Download CADExtension**:
   - Go to the [Releases section](https://github.com/sickbubble/CADExtension/releases) of this repository on GitHub.

3. **NETLOAD in AutoCAD**:
   - Open AutoCAD and type `NETLOAD` in the command line to load a .NET assembly.

4. **Load CADExtension**:
   - Browse and select the CADExtension.dll file from your downloaded plugin files.

5. **Execute Commands**:
   - After successfully loading CADExtension, you can now use the following commands:

### Using DrawColumn Command

1. **Command Syntax**:
   - Type `DrawColumn` in the AutoCAD command line and press Enter.

2. **User Interface**:
   - Follow the prompts in the user interface to provide information about the column (e.g., section, height, reinforcement).

3. **View the Plan**:
   - The generated column application plan will be displayed in the AutoCAD environment.

### Using AddIntersectionPoints Command

1. **Command Syntax**:
   - Type `AddIntersectionPoints` in the AutoCAD command line and press Enter.

2. **Intersection Detection**:
   - The command will detect intersections between existing polylines.

3. **Vertex Insertion**:
   - Vertices will be added at the intersection points to enhance precision.

## Dependencies

- AutoCAD


## Contributing

- Contributions are welcome! If you find a bug or have an enhancement in mind, please [open an issue](https://github.com/sickbubble/CADExtension/issues) or [create a pull request](https://github.com/sickbubble/CADExtension/pulls).

