using System;
using System.Drawing;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace ConsoleApplication1
{
    class screen:GameWindow
    {

        Punto[] punto = new Punto[10000];
        Punto foco= new Punto();
        Punto []vertices=new Punto[8];
        Transformaciones transformar=new Transformaciones();
        Random aleatorio= new Random();
        double intensidad;
        double radio;
        double posx;
        double posy;
        double distancia;
        double angulo;

        public screen(int ancho, int alto): base (ancho,alto)
        {

        }
          protected override void OnLoad(EventArgs e)
          {
              base.OnLoad(e);
              radio = 0.2f;
              GL.LoadIdentity();
              GL.MatrixMode(MatrixMode.Projection);
          //  Matrix4 matriz = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1, 50.0f);
           // GL.LoadMatrix(ref matriz);
              GL.Ortho(-5, 5, -5, 5, 0, 1);
           // GL.Enable(EnableCap.DepthTest);
              
              //foco.valores(0.5, 0.5, 0);
              vertices[0] = new Punto(); vertices[0].valores(0f, 0f, 0f);
              vertices[1] = new Punto(); vertices[1].valores(1f, 0f, 0f);
              vertices[2] = new Punto(); vertices[2].valores(1f, 1f, 0f);
              vertices[3] = new Punto(); vertices[3].valores(0f, 1f, 0F);
            vertices[4] = new Punto(); vertices[4].valores(0f, 0f, 1f);
            vertices[5] = new Punto(); vertices[5].valores(1f, 0f, 1f);
            vertices[6] = new Punto(); vertices[6].valores(1f, 1f, 1f);
            vertices[7] = new Punto(); vertices[7].valores(0f, 1f, 1F);
            
              vertices[0] = transformar.rotar(vertices[0], 45);
              vertices[1] = transformar.rotar(vertices[1], 45);
              vertices[2] = transformar.rotar(vertices[2], 45);
              vertices[3] = transformar.rotar(vertices[3], 45);

        }

          protected override void OnUpdateFrame(FrameEventArgs e)
          {
              base.OnUpdateFrame(e);
              GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
              GL.ClearColor(0f, 0f, 0f, 0f);
          }
          protected override void OnRenderFrame(FrameEventArgs e)
          {

            base.OnRenderFrame(e);
            GL.LoadIdentity();
            GL.Scale(0.5, 0.5, 0.5);
          //  GL.Rotate(angulo, 0, 0, 1);
             

             GL.Begin(PrimitiveType.LineLoop);
            
            GL.Vertex3(vertices[0].x, vertices[0].y, vertices[0].z);

            GL.Vertex3(vertices[1].x, vertices[1].y, vertices[1].z);
            GL.Vertex3(vertices[2].x, vertices[2].y, vertices[2].z);
            GL.Vertex3(vertices[3].x, vertices[3].y, vertices[3].z);
          
            GL.End();

        
          
            if(angulo> 360)
            {
                angulo = 0;
            }
            angulo++;

             SwapBuffers();
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
            foco.valores(posx, posy, 0);
        }



    }
}
