using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace ConsoleApplication1
{
    class screen:GameWindow
    {

        Punto[] punto = new Punto[10000];
        Punto foco= new Punto();
        Random aleatorio= new Random();
        double intensidad;
        double radio;
        double posx;
        double posy;

        public screen(int ancho, int alto): base (ancho,alto)
        {

        }
          protected override void OnLoad(EventArgs e)
          {
              base.OnLoad(e);
              radio = 0.2f;
              GL.LoadIdentity();
              GL.MatrixMode(MatrixMode.Projection);
              GL.Ortho(0, 1, 0, 1, 0, 1);
             
          }

          protected override void OnUpdateFrame(FrameEventArgs e)
          {
              base.OnUpdateFrame(e);
              GL.Clear(ClearBufferMask.ColorBufferBit);
              GL.ClearColor(0f, 0f, 0f, 0f);
          }
          protected override void OnRenderFrame(FrameEventArgs e)
          {
              base.OnRenderFrame(e);

        

             GL.Begin(PrimitiveType.Points);
            
               GL.End();
               foco.valores(posx, posy, 0);
              this.SwapBuffers();
          }

          protected override void OnKeyPress(KeyPressEventArgs e)
          {
              base.OnKeyPress(e);
              if (e.KeyChar == 'a')
              {
                  foco.x += 0.1;
              }
              if (e.KeyChar == 's')
              {
                  foco.x -= 0.1;
              }
          }

          protected override void OnMouseMove(OpenTK.Input.MouseMoveEventArgs e)
          {
             /* base.OnMouseMove(e);
              posx = 0.001 * e.Mouse.X;
              posy = 0.001 * e.Mouse.Y;*/
          }



    }
}
