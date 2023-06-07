using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz_IDisposable2
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
        Documento d;
        private void btn_instan_Click(object sender, EventArgs e)
        {
            d = new Documento();
        }
        private void btn_Null_Click(object sender, EventArgs e)
        {
            //antes de ejecutar el null podemos preguntar si el objeto a nullear contiene un metodo
            //Dispose()
            // como las interfaces typan podemos verificar si el documento es del tipo IDisposable
            // con un if ejecutamo el Dispose() si lo tiene
            if(d is IDisposable) {d.Dispose();}
            d = null; // dejo el objeto como basura. Ahora depende del gardbage collector
        }
        private void btn_GC_Collect_Click(object sender, EventArgs e)
        {
            GC.Collect();
        }
    }
    public class Documento : IDisposable
        {
        //una clase que implementa una interfaaz debe implementar sus metodos

        // podemos utilizar un bool para desabilitar el finalizador si usea el Dispose:
        //bool a = true;
        ~Documento() { /* if (a)*/ MessageBox.Show("se ejecuto ~Documento (finalizador) "); }
        //el finalizador se ejecuta cuando termina el ciclo de vida del objeto y pasa el gardbage collector
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            MessageBox.Show("Se ejecuto el destructor");
            //el destructor se ejecuta cuando el programador lo indique
            //se puede utilizar para soltar recursos no administrados por 
            //sistema como el consumo de una base de datos
            // a = false;
        }

    }



}
