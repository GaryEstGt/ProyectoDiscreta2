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
                    Program.vertices[posVertice].setId(posVertice+1);
                    posVertice++;
                    if (posVertice == Program.vertices.Length)
                    {
                        button4.Enabled = true;
                        button2.Enabled = false;
                    }
                    textBox2.Clear();
                }
         
            }
         

          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Program.Implementacion = new ImplementacionAlgoritmo(Program.vertices.Length);

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
                int IdInicial = 0;
                int IdFinal = 0;
                for (int i = 0; i < Program.vertices.Length; i++)
                {
                    if (Program.vertices[i].getNombre() == comboBox1.Text)
                    {
                        IdInicial = Program.vertices[i].getId()-1;
                    }
                    if (Program.vertices[i].getNombre() == comboBox2.Text)
                    {
                        IdFinal = Program.vertices[i].getId()-1;
                    }
                }
                Arista arista1 = new Arista();
                aristas[posArista] = arista1;
                aristas[posArista].setInicial(Program.vertices[IdInicial]);
                aristas[posArista].setFinal(Program.vertices[IdFinal]);
                aristas[posArista].setPeso(Convert.ToDouble(textBox3.Text));
                Program.aristas = new Arista[aristas.Length];
                Program.aristas = aristas;
                Program.Implementacion.addEdge(aristas[posArista].getInicial().getId(), aristas[posArista].getFinal().getId(), Convert.ToDouble(textBox3.Text),true);

                MessageBox.Show("Conexión realizada correctamente");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AlgoritmoDijkstra frm2 = new AlgoritmoDijkstra();
            AlgoritmoDijkstra.posVertice = posVertice;
            AlgoritmoDijkstra.posArista = posArista;
            frm2.Show();
            this.Hide();
        }
    }
}
