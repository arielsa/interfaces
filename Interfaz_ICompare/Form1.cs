using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz_ICompare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

        public override string ToString() // sobre escritura del metodo ToString 
        {
            return $"{Nombre} {Apellido} {Edad}";
        }

        public class NombreASC : IComparer<Persona>//puede ser generico y no generico
        {
            public int Compare(Persona x, Persona y)// este metodo retorna -1,0,1. si X se mantiene a la izq de Y ser -1. si en el rodenamiento son iguales ser 0 y si corresponde poner a Y antes que X sera 1
            {
                return string.Compare(x.Nombre,y.Nombre);// este metodo de los string compara y devulve -1,0,1 con el mism ocriterio que arriba
            }
        }
        public class NombreDESC: IComparer<Persona>
        {
            public int Compare(Persona x, Persona y)// este metodo retorna -1,0,1. si X se mantiene a la izq de Y ser -1. si en el rodenamiento son iguales ser 0 y si corresponde poner a Y antes que X sera 1
            {
                return string.Compare(x.Nombre, y.Nombre)*-1;// INVIERTO EL RESULTADO PARA HACER UN DESCENDENTE
            }
        }

        public class ApellidoASC : IComparer<Persona>//puede ser generico y no generico
        {
            public int Compare(Persona x, Persona y)// este metodo retorna -1,0,1. si X se mantiene a la izq de Y ser -1. si en el rodenamiento son iguales ser 0 y si corresponde poner a Y antes que X sera 1
            {
                return string.Compare(x.Apellido, y.Apellido);// este metodo de los string compara y devulve -1,0,1 con el mism ocriterio que arriba
            }
        }

        public class ApellidoDESC : IComparer<Persona>
        {
            public int Compare(Persona x, Persona y)// este metodo retorna -1,0,1. si X se mantiene a la izq de Y ser -1. si en el rodenamiento son iguales ser 0 y si corresponde poner a Y antes que X sera 1
            {
                return string.Compare(x.Apellido, y.Apellido) * -1;// INVIERTO EL RESULTADO PARA HACER UN DESCENDENTE
            }
        }

        public class EdadASC : IComparer<Persona>//puede ser generico y no generico
        {
            public int Compare(Persona x, Persona y)// este metodo retorna -1,0,1. si X se mantiene a la izq de Y ser -1. si en el rodenamiento son iguales ser 0 y si corresponde poner a Y antes que X sera 1
            {
                // creo una ecuacion que retorne el valor que
                // nesecito para quer funcione bien la interfaz
                int rdo = 0; 
                if (x.Edad < y.Edad) rdo = -1;
                if (x.Edad > y.Edad) rdo = 1;  
                return rdo;
            }
        }

    }
}
