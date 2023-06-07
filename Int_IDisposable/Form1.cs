using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Int_IDisposable
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
        public void EjemploUsing()
        {
            using (DesechableEjemplo ej = new DesechableEjemplo())
            {
                ej.MetodoEjemplo();
            }
        }
        public void EjemploInstaciar()
        {
            DesechableEjemplo ej = new DesechableEjemplo();
            ej.MetodoEjemplo();
            ej.Dispose();
        }
    }
    public class DesechableEjemplo : IDisposable
    {
        public void MetodoEjemplo()
        {
            Console.WriteLine("Hola Mundo!");
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }      
    }    

}
