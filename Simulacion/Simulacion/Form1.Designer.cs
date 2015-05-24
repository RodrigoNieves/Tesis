namespace Simulacion
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cmbAlgoritmo = new System.Windows.Forms.ComboBox();
            this.lbAlgoritmo = new System.Windows.Forms.Label();
            this.cmbColdStart = new System.Windows.Forms.ComboBox();
            this.lbColdStart = new System.Windows.Forms.Label();
            this.lbUsuarios = new System.Windows.Forms.Label();
            this.txtUsuariosSimulacion = new System.Windows.Forms.TextBox();
            this.lbNCiclos = new System.Windows.Forms.Label();
            this.txtNCiclos = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(669, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Simular";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(12, 126);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(732, 81);
            this.txtLog.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cmbAlgoritmo
            // 
            this.cmbAlgoritmo.FormattingEnabled = true;
            this.cmbAlgoritmo.Items.AddRange(new object[] {
            "Random",
            "Experto",
            "Inversion",
            "Usuario",
            "Problema",
            "SVD"});
            this.cmbAlgoritmo.Location = new System.Drawing.Point(12, 26);
            this.cmbAlgoritmo.Name = "cmbAlgoritmo";
            this.cmbAlgoritmo.Size = new System.Drawing.Size(183, 21);
            this.cmbAlgoritmo.TabIndex = 2;
            // 
            // lbAlgoritmo
            // 
            this.lbAlgoritmo.AutoSize = true;
            this.lbAlgoritmo.Location = new System.Drawing.Point(13, 7);
            this.lbAlgoritmo.Name = "lbAlgoritmo";
            this.lbAlgoritmo.Size = new System.Drawing.Size(50, 13);
            this.lbAlgoritmo.TabIndex = 3;
            this.lbAlgoritmo.Text = "Algoritmo";
            this.lbAlgoritmo.Click += new System.EventHandler(this.label1_Click);
            // 
            // cmbColdStart
            // 
            this.cmbColdStart.FormattingEnabled = true;
            this.cmbColdStart.Items.AddRange(new object[] {
            "Random",
            "Experto"});
            this.cmbColdStart.Location = new System.Drawing.Point(16, 72);
            this.cmbColdStart.Name = "cmbColdStart";
            this.cmbColdStart.Size = new System.Drawing.Size(179, 21);
            this.cmbColdStart.TabIndex = 4;
            // 
            // lbColdStart
            // 
            this.lbColdStart.AutoSize = true;
            this.lbColdStart.Location = new System.Drawing.Point(16, 53);
            this.lbColdStart.Name = "lbColdStart";
            this.lbColdStart.Size = new System.Drawing.Size(179, 13);
            this.lbColdStart.TabIndex = 5;
            this.lbColdStart.Text = "Algoritmo al no tener recomendacion";
            // 
            // lbUsuarios
            // 
            this.lbUsuarios.AutoSize = true;
            this.lbUsuarios.Location = new System.Drawing.Point(238, 7);
            this.lbUsuarios.Name = "lbUsuarios";
            this.lbUsuarios.Size = new System.Drawing.Size(103, 13);
            this.lbUsuarios.TabIndex = 6;
            this.lbUsuarios.Text = "Numero de Usuarios";
            // 
            // txtUsuariosSimulacion
            // 
            this.txtUsuariosSimulacion.Location = new System.Drawing.Point(241, 26);
            this.txtUsuariosSimulacion.Name = "txtUsuariosSimulacion";
            this.txtUsuariosSimulacion.Size = new System.Drawing.Size(133, 20);
            this.txtUsuariosSimulacion.TabIndex = 7;
            this.txtUsuariosSimulacion.Text = "100";
            // 
            // lbNCiclos
            // 
            this.lbNCiclos.AutoSize = true;
            this.lbNCiclos.Location = new System.Drawing.Point(241, 52);
            this.lbNCiclos.Name = "lbNCiclos";
            this.lbNCiclos.Size = new System.Drawing.Size(90, 13);
            this.lbNCiclos.TabIndex = 8;
            this.lbNCiclos.Text = "Numero de Ciclos";
            // 
            // txtNCiclos
            // 
            this.txtNCiclos.Location = new System.Drawing.Point(241, 73);
            this.txtNCiclos.Name = "txtNCiclos";
            this.txtNCiclos.Size = new System.Drawing.Size(133, 20);
            this.txtNCiclos.TabIndex = 9;
            this.txtNCiclos.Text = "30";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 213);
            this.progressBar.Maximum = 1000;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(741, 23);
            this.progressBar.TabIndex = 10;
            this.progressBar.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 248);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.txtNCiclos);
            this.Controls.Add(this.lbNCiclos);
            this.Controls.Add(this.txtUsuariosSimulacion);
            this.Controls.Add(this.lbUsuarios);
            this.Controls.Add(this.lbColdStart);
            this.Controls.Add(this.cmbColdStart);
            this.Controls.Add(this.lbAlgoritmo);
            this.Controls.Add(this.cmbAlgoritmo);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cmbAlgoritmo;
        private System.Windows.Forms.Label lbAlgoritmo;
        private System.Windows.Forms.ComboBox cmbColdStart;
        private System.Windows.Forms.Label lbColdStart;
        private System.Windows.Forms.Label lbUsuarios;
        private System.Windows.Forms.TextBox txtUsuariosSimulacion;
        private System.Windows.Forms.Label lbNCiclos;
        private System.Windows.Forms.TextBox txtNCiclos;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

