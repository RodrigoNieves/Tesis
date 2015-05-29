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
            this.label1 = new System.Windows.Forms.Label();
            this.lbCiclosCompletados = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbTotalCiclos = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbRDadas = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbRPorDar = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbTotalResuelto = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbTotalFallado = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbTotalSubioNivel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbParcialResuelto = new System.Windows.Forms.Label();
            this.lbParcialFallado = new System.Windows.Forms.Label();
            this.lbParcialSubioNivel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbAlumnosCompletos = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbAlumnosRendidos = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbSinRecomendaciones = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbTiempo = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbIdSimulacion = new System.Windows.Forms.Label();
            this.panelGrafica = new System.Windows.Forms.Panel();
            this.pbGrafica = new System.Windows.Forms.PictureBox();
            this.panelGrafica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGrafica)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(712, 12);
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
            this.txtLog.Location = new System.Drawing.Point(12, 198);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(775, 81);
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
            this.progressBar.Location = new System.Drawing.Point(12, 285);
            this.progressBar.Maximum = 1000;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(784, 23);
            this.progressBar.TabIndex = 10;
            this.progressBar.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(396, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Ciclos completados: ";
            // 
            // lbCiclosCompletados
            // 
            this.lbCiclosCompletados.AutoSize = true;
            this.lbCiclosCompletados.Location = new System.Drawing.Point(533, 7);
            this.lbCiclosCompletados.Name = "lbCiclosCompletados";
            this.lbCiclosCompletados.Size = new System.Drawing.Size(25, 13);
            this.lbCiclosCompletados.TabIndex = 12;
            this.lbCiclosCompletados.Text = "000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(558, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "de";
            // 
            // lbTotalCiclos
            // 
            this.lbTotalCiclos.AutoSize = true;
            this.lbTotalCiclos.Location = new System.Drawing.Point(583, 7);
            this.lbTotalCiclos.Name = "lbTotalCiclos";
            this.lbTotalCiclos.Size = new System.Drawing.Size(25, 13);
            this.lbTotalCiclos.TabIndex = 14;
            this.lbTotalCiclos.Text = "000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(396, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Recomendaciones dadas: ";
            // 
            // lbRDadas
            // 
            this.lbRDadas.AutoSize = true;
            this.lbRDadas.Location = new System.Drawing.Point(533, 24);
            this.lbRDadas.Name = "lbRDadas";
            this.lbRDadas.Size = new System.Drawing.Size(43, 13);
            this.lbRDadas.TabIndex = 16;
            this.lbRDadas.Text = "000000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(580, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "de";
            // 
            // lbRPorDar
            // 
            this.lbRPorDar.AutoSize = true;
            this.lbRPorDar.Location = new System.Drawing.Point(606, 26);
            this.lbRPorDar.Name = "lbRPorDar";
            this.lbRPorDar.Size = new System.Drawing.Size(43, 13);
            this.lbRPorDar.TabIndex = 18;
            this.lbRPorDar.Text = "000000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(396, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Total problemas resueltos: ";
            // 
            // lbTotalResuelto
            // 
            this.lbTotalResuelto.AutoSize = true;
            this.lbTotalResuelto.Location = new System.Drawing.Point(533, 41);
            this.lbTotalResuelto.Name = "lbTotalResuelto";
            this.lbTotalResuelto.Size = new System.Drawing.Size(13, 13);
            this.lbTotalResuelto.TabIndex = 20;
            this.lbTotalResuelto.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(396, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Total problemas fallados: ";
            // 
            // lbTotalFallado
            // 
            this.lbTotalFallado.AutoSize = true;
            this.lbTotalFallado.Location = new System.Drawing.Point(533, 58);
            this.lbTotalFallado.Name = "lbTotalFallado";
            this.lbTotalFallado.Size = new System.Drawing.Size(13, 13);
            this.lbTotalFallado.TabIndex = 22;
            this.lbTotalFallado.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(396, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Total incrementos de nivel: ";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // lbTotalSubioNivel
            // 
            this.lbTotalSubioNivel.AutoSize = true;
            this.lbTotalSubioNivel.Location = new System.Drawing.Point(533, 75);
            this.lbTotalSubioNivel.Name = "lbTotalSubioNivel";
            this.lbTotalSubioNivel.Size = new System.Drawing.Size(13, 13);
            this.lbTotalSubioNivel.TabIndex = 24;
            this.lbTotalSubioNivel.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(570, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Problemas resueltos en ciclo:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(570, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Problemas Fallados en ciclo: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(570, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(148, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Incrementos de nivel en ciclo:";
            // 
            // lbParcialResuelto
            // 
            this.lbParcialResuelto.AutoSize = true;
            this.lbParcialResuelto.Location = new System.Drawing.Point(721, 41);
            this.lbParcialResuelto.Name = "lbParcialResuelto";
            this.lbParcialResuelto.Size = new System.Drawing.Size(13, 13);
            this.lbParcialResuelto.TabIndex = 28;
            this.lbParcialResuelto.Text = "0";
            // 
            // lbParcialFallado
            // 
            this.lbParcialFallado.AutoSize = true;
            this.lbParcialFallado.Location = new System.Drawing.Point(721, 58);
            this.lbParcialFallado.Name = "lbParcialFallado";
            this.lbParcialFallado.Size = new System.Drawing.Size(13, 13);
            this.lbParcialFallado.TabIndex = 29;
            this.lbParcialFallado.Text = "0";
            // 
            // lbParcialSubioNivel
            // 
            this.lbParcialSubioNivel.AutoSize = true;
            this.lbParcialSubioNivel.Location = new System.Drawing.Point(721, 76);
            this.lbParcialSubioNivel.Name = "lbParcialSubioNivel";
            this.lbParcialSubioNivel.Size = new System.Drawing.Size(13, 13);
            this.lbParcialSubioNivel.TabIndex = 30;
            this.lbParcialSubioNivel.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(399, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Alumnos Completos:";
            // 
            // lbAlumnosCompletos
            // 
            this.lbAlumnosCompletos.AutoSize = true;
            this.lbAlumnosCompletos.Location = new System.Drawing.Point(533, 92);
            this.lbAlumnosCompletos.Name = "lbAlumnosCompletos";
            this.lbAlumnosCompletos.Size = new System.Drawing.Size(13, 13);
            this.lbAlumnosCompletos.TabIndex = 32;
            this.lbAlumnosCompletos.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(570, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "Alumnos Rendidos:";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // lbAlumnosRendidos
            // 
            this.lbAlumnosRendidos.AutoSize = true;
            this.lbAlumnosRendidos.Location = new System.Drawing.Point(721, 92);
            this.lbAlumnosRendidos.Name = "lbAlumnosRendidos";
            this.lbAlumnosRendidos.Size = new System.Drawing.Size(13, 13);
            this.lbAlumnosRendidos.TabIndex = 34;
            this.lbAlumnosRendidos.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(399, 110);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 13);
            this.label13.TabIndex = 35;
            this.label13.Text = "Sin recomendaciones: ";
            // 
            // lbSinRecomendaciones
            // 
            this.lbSinRecomendaciones.AutoSize = true;
            this.lbSinRecomendaciones.Location = new System.Drawing.Point(536, 109);
            this.lbSinRecomendaciones.Name = "lbSinRecomendaciones";
            this.lbSinRecomendaciones.Size = new System.Drawing.Size(13, 13);
            this.lbSinRecomendaciones.TabIndex = 36;
            this.lbSinRecomendaciones.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(570, 110);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 13);
            this.label14.TabIndex = 37;
            this.label14.Text = "Tiempo transcurrido: ";
            // 
            // lbTiempo
            // 
            this.lbTiempo.AutoSize = true;
            this.lbTiempo.Location = new System.Drawing.Point(692, 109);
            this.lbTiempo.Name = "lbTiempo";
            this.lbTiempo.Size = new System.Drawing.Size(13, 13);
            this.lbTiempo.TabIndex = 38;
            this.lbTiempo.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(13, 96);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 13);
            this.label15.TabIndex = 39;
            this.label15.Text = "Id Simulación";
            // 
            // lbIdSimulacion
            // 
            this.lbIdSimulacion.AutoSize = true;
            this.lbIdSimulacion.Location = new System.Drawing.Point(89, 96);
            this.lbIdSimulacion.Name = "lbIdSimulacion";
            this.lbIdSimulacion.Size = new System.Drawing.Size(0, 13);
            this.lbIdSimulacion.TabIndex = 40;
            // 
            // panelGrafica
            // 
            this.panelGrafica.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGrafica.AutoScroll = true;
            this.panelGrafica.Controls.Add(this.pbGrafica);
            this.panelGrafica.Location = new System.Drawing.Point(12, 126);
            this.panelGrafica.Name = "panelGrafica";
            this.panelGrafica.Size = new System.Drawing.Size(775, 66);
            this.panelGrafica.TabIndex = 41;
            // 
            // pbGrafica
            // 
            this.pbGrafica.Location = new System.Drawing.Point(0, 0);
            this.pbGrafica.Name = "pbGrafica";
            this.pbGrafica.Size = new System.Drawing.Size(100, 50);
            this.pbGrafica.TabIndex = 0;
            this.pbGrafica.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 320);
            this.Controls.Add(this.panelGrafica);
            this.Controls.Add(this.lbIdSimulacion);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lbTiempo);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lbSinRecomendaciones);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lbAlumnosRendidos);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lbAlumnosCompletos);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbParcialSubioNivel);
            this.Controls.Add(this.lbParcialFallado);
            this.Controls.Add(this.lbParcialResuelto);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbTotalSubioNivel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbTotalFallado);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbTotalResuelto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbRPorDar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbRDadas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbTotalCiclos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbCiclosCompletados);
            this.Controls.Add(this.label1);
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
            this.panelGrafica.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbGrafica)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCiclosCompletados;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbTotalCiclos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbRDadas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbRPorDar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbTotalResuelto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbTotalFallado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbTotalSubioNivel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbParcialResuelto;
        private System.Windows.Forms.Label lbParcialFallado;
        private System.Windows.Forms.Label lbParcialSubioNivel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbAlumnosCompletos;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbAlumnosRendidos;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbSinRecomendaciones;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbTiempo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbIdSimulacion;
        private System.Windows.Forms.Panel panelGrafica;
        private System.Windows.Forms.PictureBox pbGrafica;
    }
}

