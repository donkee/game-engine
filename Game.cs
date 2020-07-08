using System;
using OpenToolkit.Windowing.Desktop;
using OpenToolkit.Graphics.OpenGL4;
using OpenToolkit.Windowing.Common.Input;
using OpenToolkit.Windowing.Common;

namespace engine
{
    public class Game : GameWindow
    {

        float[] vertices = {
            -0.5f, -0.5f, 0.0f, //Bottom-left vertex
            0.5f, -0.5f, 0.0f, //Bottom-right vertex
            0.0f,  0.5f, 0.0f  //Top vertex
        };
        int VertexBufferObject;
        Shader shader;
        int VertexArrayObject;

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
            nativeWindowSettings.WindowState = WindowState.Normal;
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

        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, Size.X, Size.Y);
            base.OnResize(e);
        }

        protected override void OnLoad()
        {
            VertexBufferObject = GL.GenBuffer();
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            shader = new Shader("shaders/shader.vert", "shaders/shader.frag");
            VertexArrayObject = GL.GenVertexArray();
            // ..:: Initialization code (done once (unless your object frequently changes)) :: ..
            // 1. bind Vertex Array Object
            GL.BindVertexArray(VertexArrayObject);
            // 2. copy our vertices array in a buffer for OpenGL to use
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
            // 3. then set our vertex attributes pointers
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            base.OnLoad();
        }

        protected override void OnUnload()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DeleteBuffer(VertexBufferObject);
            shader.Dispose();
            base.OnUnload();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            shader.Use();
            GL.BindVertexArray(VertexArrayObject);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);

            SwapBuffers();
            base.OnRenderFrame(e);
        }
    }
}