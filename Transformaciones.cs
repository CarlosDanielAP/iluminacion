using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Transformaciones
    {

        public Transformaciones()
        {

        }

        public Punto rotar(Punto vertice, double angulo)
    {
        vertice.x = vertice.x * Math.Cos(angulo) + vertice.y * Math.Sin(angulo);
        vertice.y = -1 * vertice.x * Math.Sin(angulo) + vertice.y * Math.Cos(angulo);
        vertice. z= vertice.z;
        return vertice;
        
    }

    }
}
