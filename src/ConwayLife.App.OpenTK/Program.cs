using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

using ConwayLife.System;

namespace ConwayLife.App.OpenTK
{
    internal class Game : GameWindow
    {
        private readonly WorldQueue<IReadOnlyCollection<Coordinate>> _worldQueue;

        internal Game(WorldQueue<IReadOnlyCollection<Coordinate>> worldQueue)
            : base(700, 600, GraphicsMode.Default, "OpenTK Quick Start Sample")
        {
            VSync = VSyncMode.On;
            _worldQueue = worldQueue;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(0.1f, 0.2f, 0.5f, 0.0f);
            GL.Enable(EnableCap.DepthTest);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 64.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            if (Keyboard[Key.Escape])
                Exit();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            if(!_worldQueue.TryTakeReady(out var generation)) return;
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            var modelview = Matrix4.LookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);

            GL.Begin(PrimitiveType.Quads);

            for (var y = 0; y < 9; y++)
            {
                for (var x = 0; x < 9; x++)
                {
                    GL.Color3(1f, 0.0f, 0.2f);
                    if (generation.Contains(new Coordinate(y, x)))
                    {
                        GL.Color3(0.0f, 0.7f, 0.2f);
                    }
                    GL.Vertex3(-0.40f+(x*0.1 + 0.10), -0.40f+(y*0.1), 4.0f);
                    GL.Vertex3(-0.30f + (x * 0.1), -0.40f+(y * 0.1), 4.0f);

                    GL.Vertex3(-0.40f + (x * 0.1), -0.30f+(y * 0.1), 4.0f);
                    GL.Vertex3(-0.30f + (x * 0.1), -0.30f+(y * 0.1), 4.0f);
                }
            }

            GL.End();

            SwapBuffers();
        }

        [STAThread]
        public static void Main()
        {
            var world = new World(9);

            var seed = world.Generation(new List<Coordinate>()
                {
                    new Coordinate(1, 2),
                    new Coordinate(2, 2),
                    new Coordinate(3, 2),

                    new Coordinate(4, 5),
                    new Coordinate(5, 5),
                    new Coordinate(6, 5),

                    new Coordinate(0, 6),
                    new Coordinate(0, 7),
                    new Coordinate(1, 6),
                    new Coordinate(1, 7),

                }).ToList().AsReadOnly();


            var queue = new WorldQueue<IReadOnlyCollection<Coordinate>>();

            var sourceToken = new CancellationTokenSource();

            queue.PerformLogicAsync(sourceToken.Token, (newGeneration) =>  world.Generation(newGeneration).ToList().AsReadOnly(), seed);

            // The 'using' idiom guarantees proper resource cleanup.
            // We request 30 UpdateFrame events per second, and unlimited
            // RenderFrame events (as fast as the computer can handle).
            using (Game game = new Game(queue))
            {
                game.Run(30.0);
            }
            sourceToken.Cancel();
        }
    }
}
