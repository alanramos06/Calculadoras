using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraMetodosNumericos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcularB_Click(object sender, EventArgs e)
        {
            double masa = 0, tiempo = 0, velocidad = 0, errorE = 0, c1 = 0, c2 = 0, c3 = 0, funcion1 = 0, funcion2 = 0,
                funcion3 = 0, errorA = 100, vAct = 0, vAnt = 0, aux = 0;
            int i = 0;

            try
            {
                masa = Convert.ToDouble(txtMasaB.Text);
                tiempo = Convert.ToDouble(txtTiempoB.Text);
                velocidad = Convert.ToDouble(txtVelocidadB.Text);
                errorE = Convert.ToDouble(txtErrorEB.Text);

                Random r = new Random();
                Funciones f = new Funciones();
                c1 = r.Next(0, 32767);
                c2 = r.Next(0, 32767);

                funcion1 = f.f1(masa, tiempo, velocidad, c1);
                funcion2 = f.f1(masa, tiempo, velocidad, c2);
                while (funcion1 * funcion2 > 0)
                {
                    c2 = r.Next(0, 32767);
                    funcion2 = f.f1(masa, tiempo, velocidad, c2);
                }

                while (errorA > errorE)
                {
                    c3 = (c1 + c2) / 2;
                    vAct = c3;
                    funcion3 = f.f1(masa, tiempo, velocidad, c3);
                    errorA = Math.Abs(((vAct - vAnt) / vAct) * 100);
                    vAnt = c3;
                    i++;

                    if (funcion1 * funcion3 < 0)
                    {
                        funcion2 = funcion3;
                        c2 = c3;
                    }
                    else if (funcion2 * funcion3 < 0)
                    {
                        funcion1 = funcion3;
                        c1 = c3;
                    }
                }
                txtResultadoB.Text = Convert.ToString(Math.Round(c3, 5));
                txtIteracionesB.Text = Convert.ToString(i);
                txtErrorAB.Text = Convert.ToString(Math.Round(errorA, 5));
                btnCalcularB.Enabled = false;
            }
            catch {
                MessageBox.Show("Ingresó algún caracter inválido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCalcularPF_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCalcularS_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCalcPF_Click(object sender, EventArgs e)
        {
            double masa = 0, tiempo = 0, velocidad = 0, errorE = 0, c = 0, funcion = 0, errorA = 100, vAct = 0, vAnt = 0;
            int i = 0;
            try
            {
                Random r = new Random();
                c = r.Next(0, 3276); //Se toma un número aleatorio para comenzar las iteraciones

                masa = Convert.ToDouble(txtMasaPF.Text);
                tiempo = Convert.ToDouble(txtTiempoPF.Text);
                velocidad = Convert.ToDouble(txtVelocidadPF.Text);
                errorE = Convert.ToDouble(txtErrorEPF.Text);
                Funciones f = new Funciones();

                funcion = f.f2(masa, tiempo, velocidad, c); //Se manda llamar la clase con la función que se usará
                vAct = funcion; //Se asigna el resultado de la función al valor actual

                i++; //Aumenta una iteración

                while (errorA > errorE)
                {
                    c = vAct; //"c" toma el valor valor actual, es decir, el último valor de la función
                    vAnt = c; //Se usa el valor actual como el anterior para obtener nuevos datos
                    funcion = f.f2(masa, tiempo, velocidad, c); //Mandar llamar la función
                    vAct = funcion; //El valor actual toma el valor del reultado de la función
                    errorA = Math.Abs(((vAct - vAnt) / vAct) * 100); //Se obtiene el nuevo error aproximado
                    i++; //El contador de las iteraciones aumenta una vez
                }
                txtResultadoPF.Text = Convert.ToString(Math.Round(vAct, 5));
                txtIteracionesPF.Text = Convert.ToString(i);
                txtErrorAPF.Text = Convert.ToString(Math.Round(errorA, 5));
                btnCalcPF.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Ingresó algún caracter inválido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCalcS_Click(object sender, EventArgs e)
        {
            double masa = 0, tiempo = 0, velocidad = 0, errorE = 0, c1 = 0, c2 = 0, funcion1 = 0, funcion2 = 0, errorA = 100, vAct = 0, vAnt = 0, aux = 0, funcion3, c3;
            int i = 0;
            try
            {
                Random r = new Random();
                c1 = r.Next(0, 50);
                c2 = r.Next(0, 50);

                masa = Convert.ToDouble(txtMasaS.Text);
                tiempo = Convert.ToDouble(txtTiempoS.Text);
                velocidad = Convert.ToDouble(txtVelocidadS.Text);
                errorE = Convert.ToDouble(txtErrorES.Text);
                Funciones f = new Funciones();


                while (errorA > errorE)
                {
                    funcion1 = f.f1(masa, tiempo, velocidad, c1);
                    funcion2 = f.f1(masa, tiempo, velocidad, c2);
                    aux = c2 - (funcion2 * (c1 - c2)) / (funcion1 - funcion2);
                    c1 = c2;
                    c2 = aux;
                    vAnt = aux;
                    funcion1 = f.f1(masa, tiempo, velocidad, c1);
                    funcion2 = f.f1(masa, tiempo, velocidad, c2);
                    aux = c2 - ((funcion2 * (c2 - c1)) / (funcion2 - funcion1));
                    vAct = aux;
                    errorA = Math.Abs(((vAct - vAnt) / vAct) * 100);
                    i++;
                }
                txtResultadoS.Text = Convert.ToString(Math.Round(vAct, 5));
                txtIteracionesS.Text = Convert.ToString(i);
                txtErrorAS.Text = Convert.ToString(Math.Round(errorA, 5));
                btnCalcS.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Ingresó algún caracter inválido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
