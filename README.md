# Quantum Radar

A simple C# console application that simulates a traffic radar system. The project demonstrates Object-Oriented Programming (OOP) and SOLID principles while keeping the implementation simple and extensible.

## Features

- Receives vehicle observations containing:
  - Plate Number
  - Date
  - Car Type
  - Speed
  - Seatbelt Status
- Validates observations using configurable traffic rules.
- Generates zero or more traffic violations for each observation.
- Issues fines containing all detected violations and their fees.
- Retrieves all issued fines.
- Counts how many times each traffic rule has been violated.

## Current Rules

- Truck maximum speed: **60 km/h**
- Private car maximum speed: **80 km/h**
- Seatbelt must be fastened

## Project Structure

```text
Abstractions/
Entities/
Rules/
Services/
Program.cs
```

## Technologies

- C#
- .NET
- Object-Oriented Programming (OOP)
- SOLID Principles
