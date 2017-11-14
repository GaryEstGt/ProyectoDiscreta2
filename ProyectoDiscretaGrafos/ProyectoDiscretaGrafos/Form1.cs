using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoDiscretaGrafos
{
    public partial class Form1 : Form
    {
        int posVertice = 0;
        int posArista = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cantidadPaises = Convert.ToInt32(textBox1.Text);
            Program.vertices = new Vertice[cantidadPaises];
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Program.vertices.Length == posVertice)
            {
                MessageBox.Show("Ya ingresó todo los paises");
            }
            else
            {
                bool verificar = false;
                for (int i = 0; i < posVertice; i++)
                {
                    if (Program.vertices[i].getNombre() == textBox2.Text)
                    {
                        verificar = true;
                        textBox2.Clear();
                    }
                }
                if (verificar == true)
                {
                    MessageBox.Show("No puede ingresar dos paises iguales");
                }
                else
                {
                    Vertice Temporal = new Vertice();
                    Program.vertices[posVertice] = Temporal;
                    Program.vertices[posVertice].setNombre(textBox2.Text);
                    posVertice++;
                    if (posVertice == Program.vertices.Length)
                    {
                        button4.Enabled = true;
                    }
                    textBox2.Clear();
                }
         
            }
         

          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < posVertice; i++)
            {
                comboBox1.Items.Add(Program.vertices[i].getNombre());
                comboBox2.Items.Add(Program.vertices[i].getNombre());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Arista[] aristas = new Arista[100];
            if (comboBox1.Text == comboBox2.Text)
            {
                MessageBox.Show("No puede ser el mismo pais");
            }
            else
            {
                Vertice temporal1 = new Vertice();
                temporal1.setNombre(comboBox1.Text);
                Vertice temporal2 = new Vertice();
                temporal2.setNombre(comboBox2.Text);
                Arista arista1 = new Arista();
                aristas[posArista] = arista1;
                aristas[posArista].setInicial(temporal1);
                aristas[posArista].setFinal(temporal2);
                aristas[posArista].setPeso(Convert.ToDouble(textBox3.Text));
                posArista++;
                Program.aristas = new Arista[aristas.Length];
                Program.aristas = aristas;
                MessageBox.Show("Conexión realizada correctamente");
            }
        }
    }
}
