namespace ui
{
    partial class FormMaps
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
            this.gMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.txtDepto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDepto = new System.Windows.Forms.Button();
            this.btnCiudad = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnHeatMap = new System.Windows.Forms.Button();
            this.btnFecha = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.btnVariableGeneral = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVariable = new System.Windows.Forms.TextBox();
            this.btnVariableTabla = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // gMapControl
            // 
            this.gMapControl.Bearing = 0F;
            this.gMapControl.CanDragMap = true;
            this.gMapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl.GrayScaleMode = false;
            this.gMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl.LevelsKeepInMemmory = 5;
            this.gMapControl.Location = new System.Drawing.Point(12, 12);
            this.gMapControl.MarkersEnabled = true;
            this.gMapControl.MaxZoom = 2;
            this.gMapControl.MinZoom = 2;
            this.gMapControl.MouseWheelZoomEnabled = true;
            this.gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl.Name = "gMapControl";
            this.gMapControl.NegativeMode = false;
            this.gMapControl.PolygonsEnabled = true;
            this.gMapControl.RetryLoadTile = 0;
            this.gMapControl.RoutesEnabled = true;
            this.gMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl.ShowTileGridLines = false;
            this.gMapControl.Size = new System.Drawing.Size(828, 722);
            this.gMapControl.TabIndex = 0;
            this.gMapControl.Zoom = 0D;
            // 
            // txtDepto
            // 
            this.txtDepto.Location = new System.Drawing.Point(993, 49);
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Size = new System.Drawing.Size(100, 22);
            this.txtDepto.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(889, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Departamento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1019, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filtros";
            // 
            // btnDepto
            // 
            this.btnDepto.Location = new System.Drawing.Point(1099, 47);
            this.btnDepto.Name = "btnDepto";
            this.btnDepto.Size = new System.Drawing.Size(76, 24);
            this.btnDepto.TabIndex = 4;
            this.btnDepto.Text = "Aceptar";
            this.btnDepto.UseVisualStyleBackColor = true;
            this.btnDepto.Click += new System.EventHandler(this.btnDepto_Click);
            // 
            // btnCiudad
            // 
            this.btnCiudad.Location = new System.Drawing.Point(1099, 84);
            this.btnCiudad.Name = "btnCiudad";
            this.btnCiudad.Size = new System.Drawing.Size(76, 24);
            this.btnCiudad.TabIndex = 7;
            this.btnCiudad.Text = "Aceptar";
            this.btnCiudad.UseVisualStyleBackColor = true;
            this.btnCiudad.Click += new System.EventHandler(this.btnCiudad_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(889, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Municipio";
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(993, 86);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(100, 22);
            this.txtCiudad.TabIndex = 5;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(846, 221);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(361, 479);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.SeleccionarRegistro);
            // 
            // btnHeatMap
            // 
            this.btnHeatMap.Location = new System.Drawing.Point(1082, 706);
            this.btnHeatMap.Name = "btnHeatMap";
            this.btnHeatMap.Size = new System.Drawing.Size(125, 28);
            this.btnHeatMap.TabIndex = 8;
            this.btnHeatMap.Text = "Show Heat Map";
            this.btnHeatMap.UseVisualStyleBackColor = true;
            this.btnHeatMap.Click += new System.EventHandler(this.btnHeatMap_Click);
            // 
            // btnFecha
            // 
            this.btnFecha.Location = new System.Drawing.Point(1099, 122);
            this.btnFecha.Name = "btnFecha";
            this.btnFecha.Size = new System.Drawing.Size(76, 24);
            this.btnFecha.TabIndex = 11;
            this.btnFecha.Text = "Aceptar";
            this.btnFecha.UseVisualStyleBackColor = true;
            this.btnFecha.Click += new System.EventHandler(this.btnFecha_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(889, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Fecha";
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(993, 124);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(100, 22);
            this.txtFecha.TabIndex = 9;
            // 
            // btnVariableGeneral
            // 
            this.btnVariableGeneral.Location = new System.Drawing.Point(1099, 161);
            this.btnVariableGeneral.Name = "btnVariableGeneral";
            this.btnVariableGeneral.Size = new System.Drawing.Size(76, 24);
            this.btnVariableGeneral.TabIndex = 14;
            this.btnVariableGeneral.Text = "General";
            this.btnVariableGeneral.UseVisualStyleBackColor = true;
            this.btnVariableGeneral.Click += new System.EventHandler(this.btnVariable_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(889, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Variable";
            // 
            // txtVariable
            // 
            this.txtVariable.Location = new System.Drawing.Point(993, 176);
            this.txtVariable.Name = "txtVariable";
            this.txtVariable.Size = new System.Drawing.Size(100, 22);
            this.txtVariable.TabIndex = 12;
            // 
            // btnVariableTabla
            // 
            this.btnVariableTabla.Location = new System.Drawing.Point(1099, 191);
            this.btnVariableTabla.Name = "btnVariableTabla";
            this.btnVariableTabla.Size = new System.Drawing.Size(76, 24);
            this.btnVariableTabla.TabIndex = 15;
            this.btnVariableTabla.Text = "Tabla";
            this.btnVariableTabla.UseVisualStyleBackColor = true;
            this.btnVariableTabla.Click += new System.EventHandler(this.btnVariableTabla_Click);
            // 
            // FormMaps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 741);
            this.Controls.Add(this.btnVariableTabla);
            this.Controls.Add(this.btnVariableGeneral);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtVariable);
            this.Controls.Add(this.btnFecha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.btnHeatMap);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btnCiudad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCiudad);
            this.Controls.Add(this.btnDepto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDepto);
            this.Controls.Add(this.gMapControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMaps";
            this.Text = "FormMaps";
            this.Load += new System.EventHandler(this.FormMaps_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl;
        private System.Windows.Forms.TextBox txtDepto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDepto;
        private System.Windows.Forms.Button btnCiudad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnHeatMap;
        private System.Windows.Forms.Button btnFecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Button btnVariableGeneral;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtVariable;
        private System.Windows.Forms.Button btnVariableTabla;
    }
}