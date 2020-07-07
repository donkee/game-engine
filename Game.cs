using OpenToolkit.Windowing.Desktop;
using OpenToolkit.Graphics.OpenGL4;
using OpenToolkit.Windowing.Common.Input;
using OpenToolkit.Windowing.Common;

namespace engine
{
    public class Game : GameWindow
    {
        public Game(int width, int height, string title, double fps) : base(GenerateGameWindowSettings(fps), GenerateNativeWindowSettings(width, height, title)) { }

        private static GameWindowSettings GenerateGameWindowSettings(double fps)
        {
            GameWindowSettings gameWindowSettings = GameWindowSettings.Default;
            gameWindowSettings.RenderFrequency = fps;
            return gameWindowSettings;
        }

        private static NativeWindowSettings GenerateNativeWindowSettings(int width, int height, string title)
        {
            NativeWindowSettings nativeWindowSettings = NativeWindowSettings.Default;
            nativeWindowSettings.Size = new OpenToolkit.Mathematics.Vector2i(width, height);
            nativeWindowSettings.Title = title;
            return new NativeWindowSettings();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            KeyboardState input = KeyboardState;

            if (input.IsKeyDown(Key.Escape))
            {
                Close();
            }

            base.OnUpdateFrame(e);
        }

        protected override void OnLoad()
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            base.OnLoad();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            //Code goes here.

            SwapBuffers();
            base.OnRenderFrame(e);
        }
    }
}