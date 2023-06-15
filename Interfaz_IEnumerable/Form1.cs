using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz_IEnumerable
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

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            Producto p = new Producto() { Codigo = "7794563987651", Descripcion = "Coca Cola 1.5", Precio = 100 };
        }
    }
    public class Producto : IEnumerable
    {
        // ean 13: 7794563987651
        //pais :   779
        //empresa :   4563 
        //producto:       98765
        //dv:                  1
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
   

        public IEnumerator GetEnumerator()
        {
            return new EnumeradorProducto_1(this);
        }
    }
    public class EnumeradorProducto_1 : IEnumerator
    {
        Producto producto;
        string retorno;
        bool rta;
        int[] desde = {0,3,7,12};
        int[] cuanto = {3,4,5,1};
        int c;
        public EnumeradorProducto_1(Producto pProducto)
        {
            Reset();
            producto = pProducto; 
        }
        public object Current => retorno;

        public bool MoveNext()
        {
            if (c < 4) { retorno = producto.Codigo.Substring(desde[c], cuanto[c]); }
            else { rta = false; }
            c++;
            return rta;
        }

        public void Reset()
        {
            retorno = "";
            rta = true;
            c = 0;
        }
    }
}
