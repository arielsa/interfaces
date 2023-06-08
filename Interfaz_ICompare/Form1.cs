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

        List<Persona> p;

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void EjecutoCompare(object sender, EjecutoCompareEventArgs e);
        private void Btn_Ejecutar_Click(object sender, EventArgs e)
        {
            p = new List<Persona>();    
            p.AddRange(new Persona[] { new Persona() { Nombre = "juan", Apellido = "adearcos", Edad = 28, },
                                        new Persona() { Nombre = "maura", Apellido = "mimm", Edad = 80, },
                                        new Persona() { Nombre = "lucos", Apellido = "pauito", Edad = 10, },
                                        new Persona() { Nombre = "mirta", Apellido = "garcia", Edad = 19, },
                                        new Persona() { Nombre = "sebastian", Apellido = "vader", Edad = 41, },
                                        });
            foreach (Control c in this.Controls)
            {
                if (c is TextBox) (c as TextBox).Clear();                
            }
            foreach (Persona persona in p){textBox1.Text += $"{ persona.ToString()}{Environment.NewLine }";}

            //variable para capturar persona para el evento
            Persona.NombreASC pna = new Persona.NombreASC();
            pna.EjecutoCompare += EjecutoCompare;
            p.Sort(pna);
            foreach (Persona persona in p){ textBox5.Text += $"{persona.ToString()}{Environment.NewLine}"; }
            
            p.Sort(new Persona.NombreApellidoASC());
            foreach (Persona persona in p) { textBox8.Text += $"{persona.ToString()}{Environment.NewLine}"; }

            //claramente aca el sort esta reaccionando al ICompare. EL sort toma dos personas.atributo de la lista
            //y el compare retorna -1, 0 o 1. y con eso el sort decide hacer un swap o no, entre los elementos.
            //y hace tantos swap hasta que estan rodenados. El sort tiene un algoritmo de ordenamiento.
            //pero el que le dice cual va es la interfase. 

            //si deseo ver que envia en cada iteracion la interface al sort deberiamos crear un evento
            //un evento en la clase con interface que cada vez que se ejecute el compare se desencadene 
            //y envie al formulario que X e Y recibio
            // voy a tener que suscribir cuando instancie el objeto con interfaz al evento que hara todo esto.

        }

        private void label10_Click(object sender, EventArgs e){        }
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
            public event EventHandler<EjecutoCompareEventArgs>EjecutoCompare; //creo la clase para el evento (eventArgs) (debajo de NombreApellidoASC)
            public int Compare(Persona x, Persona y)// este metodo retorna -1,0,1. si X se mantiene a la izq de Y ser -1. si en el rodenamiento son iguales ser 0 y si corresponde poner a Y antes que X sera 1
            {
                int rdo = string.Compare(x.Nombre, y.Nombre);
                //desencadenamieto del evento
                EjecutoCompare?.Invoke(this, new EjecutoCompareEventArgs(x,y,rdo));
                return rdo;
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

        public class NombreApellidoASC : IComparer<Persona>
        {
            NombreASC na = new NombreASC();
            ApellidoASC aa = new ApellidoASC();
            public int Compare(Persona x , Persona y)
            {
                int rdo = na.Compare(x, y);
                return rdo == 0 ? aa.Compare(x,y) : rdo;
            }
        }

       
    }
    public class EjecutoCompareEventArgs : EventArgs // argumento de evento creado
    {
        Persona x, y;
        int rdo = 0;
        //guardo las entradas y la salida en el constructor
        public EjecutoCompareEventArgs(Persona pX, Persona pY, int pRDO)
        {
            x = pX; y = pY; rdo = pRDO;
        }
        //agrego tres propiedades de solo lectura:
        public Persona pxLectura => x;
        public Persona pyLectura => y;
        public int rdoLectura => rdo;
    }

}
