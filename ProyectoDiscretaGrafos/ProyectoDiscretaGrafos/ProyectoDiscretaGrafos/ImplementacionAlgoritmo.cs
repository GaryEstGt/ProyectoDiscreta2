using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoDiscretaGrafos
{
    public class ImplementacionAlgoritmo
    {
        public ImplementacionAlgoritmo(int V)
        {
            this.V = V;
            for (int i = 0; i <= V; ++i)
                ady.Add(new List<Node>()); //inicializamos lista de adyacencia
            dijkstraEjecutado = false;
        }
        public class Node : IComparable<Node>{
            public int first;
            public double second;
        public Node(int d, double p)
        {                          //constructor
            this.first = d;
            this.second = p;
        }
            public int CompareTo(Node other)
        {              //es necesario definir un comparador para el correcto funcionamiento del PriorityQueue
            if (second > other.second) return 1;
            if (second == other.second) return 0;
            return -1;
        }
    };


        private List<List<Node>> ady = new List<List<Node>>(); //lista de adyacencia
        private double[] distancia = new double[1000];          //distancia[ u ] distancia de vértice inicial a vértice con ID = u
        private bool[] visitado = new bool[1000];   //para vértices visitados
        private PriorityQueue<Node> Q = new PriorityQueue<Node>(); //priority queue implementada
        private int V;                                      //numero de vertices
        private int[] previo = new int[1000];              //para la impresion de caminos
        private bool dijkstraEjecutado;

        private void init()
        {
            for (int i = 0; i <= V; ++i)
            {
                distancia[i] = 1000;  //inicializamos todas las distancias con valor infinito
                visitado[i] = false; //inicializamos todos los vértices como no visitados
                previo[i] = -1;      //inicializamos el previo del vertice i con -1
            }
        }
        private void relajacion(int actual, int adyacente, double peso)
        {
            //Si la distancia del origen al vertice actual + peso de su arista es menor a la distancia del origen al vertice adyacente
            if (distancia[actual] + peso < distancia[adyacente])
            {
                distancia[adyacente] = distancia[actual] + peso;  //relajamos el vertice actualizando la distancia
                previo[adyacente] = actual;                         //a su vez actualizamos el vertice previo
                Q.Enqueue(new Node(adyacente, distancia[adyacente])); //agregamos adyacente a la cola de prioridad
            }
        }
        public void dijkstra(int inicial)
        {
            init(); //inicializamos nuestros arreglos
            Q.Enqueue(new Node(inicial, 0)); //Insertamos el vértice inicial en la Cola de Prioridad
            distancia[inicial] = 0;      //Este paso es importante, inicializamos la distancia del inicial como 0
            int actual, adyacente;
                double peso;
            while (!Q.isEmpty())
            {                   //Mientras cola no este vacia
                actual = Q.Dequeue().first;            //Obtengo de la cola el nodo con menor peso, en un comienzo será el inicial
                //Q.remove();                           //Sacamos el elemento de la cola
                if (visitado[actual]) continue; //Si el vértice actual ya fue visitado entonces sigo sacando elementos de la cola
                visitado[actual] = true;         //Marco como visitado el vértice actual

                for (int i = 0; i < ady.ElementAt(actual).Count; ++i)
                { //reviso sus adyacentes del vertice actual
                    adyacente = ady.ElementAt(actual).ElementAt(i).first;   //id del vertice adyacente
                    peso = ady.ElementAt(actual).ElementAt(i).second;        //peso de la arista que une actual con adyacente ( actual , adyacente )
                    if (!visitado[adyacente])
                    {        //si el vertice adyacente no fue visitado
                        relajacion(actual, adyacente, peso); //realizamos el paso de relajacion
                    }
                }
            }

            MessageBox.Show("Distancias mas cortas iniciando en vertice %d\n"+ inicial);
            String datos = "";
            for (int i = 1; i <= V; ++i)
            {
              datos+= "Vertice %d , distancia mas corta = %d\n"+ i+" "+ distancia[i];
            }
            MessageBox.Show(datos);
            dijkstraEjecutado = true;
        }
        public void addEdge(int origen, int destino, double peso, bool dirigido)
        {
            ady.ElementAt(origen).Add(new Node(destino, peso));    //grafo diridigo
            if (!dirigido)
                ady.ElementAt(destino).Add(new Node(origen, peso)); //no dirigido
        }

        public void printShortestPath(int destino)
        {
            if (!dijkstraEjecutado)
            {
                MessageBox.Show("Es necesario ejecutar el algorithmo de Dijkstra antes de poder imprimir el camino mas corto");
               
            }
            print(destino);
          
        }

        //Impresion del camino mas corto desde el vertice inicial y final ingresados
        public void print(int destino)
        {
            if (previo[destino] != -1)    //si aun poseo un vertice previo
                print(previo[destino]);  //recursivamente sigo explorando
            MessageBox.Show("%d "+ destino);        //terminada la recursion imprimo los vertices recorridos
        }

        public int getNumberOfVertices()
        {
            return V;
        }

        public void setNumberOfVertices(int numeroDeVertices)
        {
            V = numeroDeVertices;
        }

    }
}
