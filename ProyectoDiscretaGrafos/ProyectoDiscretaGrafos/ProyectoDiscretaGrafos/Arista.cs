using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDiscretaGrafos
{
    class Arista
    {
        private double peso;
        private Vertice Inicial;
        private Vertice Final;
        public void setPeso(double pes)
        {
            peso = pes;
        }
        public double getPeso()
        {
            return peso;
        }
        public void setInicial(Vertice Inicio)
        {
            Inicial = Inicio;
        }
        public Vertice getInicial()
        {
            return Inicial;
        }
        public void setFinal(Vertice fin)
        {
            Final = fin;
        }
        public Vertice getFinal()
        {
            return Final;
        }
    }
}
