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
        Punto []vertices=new Punto[4];
        Random aleatorio= new Random();
        double intensidad;
        double radio;
        double posx;
        double posy;
        double distancia;

        public screen(int ancho, int alto): base (ancho,alto)
        {

        }
          protected override void OnLoad(EventArgs e)
          {
              base.OnLoad(e);
              radio = 0.2f;
              GL.LoadIdentity();
              GL.MatrixMode(MatrixMode.Projection);
              GL.Ortho(0, 1, 0, 1, -1, 1);
              
              foco.valores(0.5, 0.5, 0);
              vertices[0] = new Punto(); vertices[0].valores(0f, 0f, 0f);
              vertices[1] = new Punto(); vertices[1].valores(0.5f, 0f, 0f);
              vertices[2] = new Punto(); vertices[2].valores(0.5f, 0.5f, 0f);
              vertices[3] = new Punto(); vertices[3].valores(0f, 0.5f, 0.5f);
          }

          protected override void OnUpdateFrame(FrameEventArgs e)
          {
              base.OnUpdateFrame(e);
              GL.Clear(ClearBufferMask.ColorBufferBit);
              GL.ClearColor(1f, 0.5f, 0.5f, 0f);
          }
          protected override void OnRenderFrame(FrameEventArgs e)
          {
              base.OnRenderFrame(e);

        

             GL.Begin(PrimitiveType.Quads);




             for (int i = 0; i < 4; i++)
             {
                 distancia=Math.Sqrt(
                     Math.Pow(foco.x-vertices[i].x,2)+
                     Math.Pow(foco.x-vertices[i].y,2)+
                     Math.Pow(foco.x-vertices[i].z,2));
                 GL.Color3(1 * distancia, 1 * distancia, 1 * distancia);
                 GL.Vertex2(vertices[i].x,vertices[i].y);

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

          protected override void OnMouseMove(OpenTK.Input.MouseMoveEventArgs e)
          {
              base.OnMouseMove(e);
              posx = 0.001 * e.Mouse.X;
              posy = 0.001 * e.Mouse.Y;
          }



    }
}
