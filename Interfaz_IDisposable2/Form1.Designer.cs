namespace Interfaz_IDisposable2
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_instan = new System.Windows.Forms.Button();
            this.btn_GC_Collect = new System.Windows.Forms.Button();
            this.btn_Null = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_instan
            // 
            this.btn_instan.Location = new System.Drawing.Point(30, 50);
            this.btn_instan.Name = "btn_instan";
            this.btn_instan.Size = new System.Drawing.Size(92, 43);
            this.btn_instan.TabIndex = 0;
            this.btn_instan.Text = "instanciar";
            this.btn_instan.UseVisualStyleBackColor = true;
            this.btn_instan.Click += new System.EventHandler(this.btn_instan_Click);
            // 
            // btn_GC_Collect
            // 
            this.btn_GC_Collect.Location = new System.Drawing.Point(269, 50);
            this.btn_GC_Collect.Name = "btn_GC_Collect";
            this.btn_GC_Collect.Size = new System.Drawing.Size(127, 43);
            this.btn_GC_Collect.TabIndex = 1;
            this.btn_GC_Collect.Text = "G.C. Colletc";
            this.btn_GC_Collect.UseVisualStyleBackColor = true;
            this.btn_GC_Collect.Click += new System.EventHandler(this.btn_GC_Collect_Click);
            // 
            // btn_Null
            // 
            this.btn_Null.Location = new System.Drawing.Point(150, 50);
            this.btn_Null.Name = "btn_Null";
            this.btn_Null.Size = new System.Drawing.Size(102, 43);
            this.btn_Null.TabIndex = 2;
            this.btn_Null.Text = "nullear";
            this.btn_Null.UseVisualStyleBackColor = true;
            this.btn_Null.Click += new System.EventHandler(this.btn_Null_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Null);
            this.Controls.Add(this.btn_GC_Collect);
            this.Controls.Add(this.btn_instan);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_instan;
        private System.Windows.Forms.Button btn_GC_Collect;
        private System.Windows.Forms.Button btn_Null;
    }
}

