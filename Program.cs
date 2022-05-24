global using ImGuiNET;
global using ImGuiNETSFML;
global using SFML.Graphics;
global using SFML.Window;
global using SFML.System;
using System.Runtime.InteropServices;

[DllImport("kernel32.dll")]
static extern IntPtr GetConsoleWindow();

[DllImport("user32.dll")]
static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

var handle = GetConsoleWindow();

// Hide
ShowWindow(handle, 0);

var game = new Game();
game.Run();