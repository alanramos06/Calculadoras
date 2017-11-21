using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraMetodosNumericos
{
    class Funciones
    {
        public double f1(double Masa, double Tiempo, double Velocidad, double C)
        {
            double funcion = 0, euler = 0, gravedad = 9.8;
            euler = Math.Exp(1);
            funcion = (gravedad * Masa / C) * (1 - Math.Pow(euler, -(C / Masa * Tiempo))) - Velocidad;

            return funcion;
        }

        public double f2(double Masa, double Tiempo, double Velocidad, double C)
        {
            double funcion = 0, euler = 0, gravedad = 9.8;
            euler = Math.Exp(1);
            funcion = (gravedad * Masa / C) * (1 - Math.Pow(euler, -(C / Masa * Tiempo))) - Velocidad + C;

            return funcion;
        }
    }
}
