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
              foco.valores(0.5,0.5,0);
              for (int i = 0; i < 10000; i++)
              {
                  punto[i] = new Punto();
                  punto[i].valores(aleatorio.NextDouble(), aleatorio.NextDouble(), 0);

              }
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
              for(int i=0;i<10000;i++){

                 intensidad=1/Math.Sqrt(
                     Math.Pow(foco.x- punto[i].x ,2)+
                     Math.Pow(foco.y- punto[i].y ,2)+
                     Math.Pow(foco.z- punto[i].z ,2));
                     

                  GL.Color3(intensidad * radio, intensidad * radio, intensidad * radio);
                  GL.Vertex2(punto[i].x,punto[i].y);
              }
               GL.End();

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



    }
}
