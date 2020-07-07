using OpenToolkit;
using OpenToolkit.Core;
using OpenToolkit.Windowing.Desktop;
using OpenToolkit.Graphics;
using OpenToolkit.Windowing.Common.Input;
using OpenToolkit.Windowing.Common;
using OpenToolkit.Windowing.GraphicsLibraryFramework;
using System;

namespace engine
{
    public class Game : GameWindow
    {
        public Game(int width, int height, string title) : base(GameWindowSettings.Default, NativeWindowSettings.Default) { }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            KeyboardState input = KeyboardState;

            if (input.IsKeyDown(Key.Escape))
            {
                Close();
            }

            base.OnUpdateFrame(e);
        }
    }
}