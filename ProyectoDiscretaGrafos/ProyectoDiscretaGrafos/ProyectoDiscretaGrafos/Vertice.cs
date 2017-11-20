using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDiscretaGrafos
{
    class Vertice
    {
        private String Nombre;
        private int Id;
        public void setNombre(String nombre)
        {
            Nombre = nombre;
        }
        public String getNombre()
        {
            return Nombre;
        }
        public void setId(int id)
        {
            Id = id;
        }
        public int getId()
        {
            return Id;
        }
    }
}
