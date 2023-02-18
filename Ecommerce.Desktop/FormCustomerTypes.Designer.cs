namespace Ecommerce.Desktop
{
    partial class FormCustomerTypes
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
            this.lblTypeId = new System.Windows.Forms.Label();
            this.txtCustomerTypeId = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.groupTypes = new System.Windows.Forms.GroupBox();
            this.gridCustomerType = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomerType)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTypeId
            // 
            this.lblTypeId.AutoSize = true;
            this.lblTypeId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTypeId.Location = new System.Drawing.Point(55, 18);
            this.lblTypeId.Name = "lblTypeId";
            this.lblTypeId.Size = new System.Drawing.Size(62, 21);
            this.lblTypeId.TabIndex = 0;
            this.lblTypeId.Text = "Tipo ID:";
            // 
            // txtCustomerTypeId
            // 
            this.txtCustomerTypeId.Enabled = false;
            this.txtCustomerTypeId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCustomerTypeId.Location = new System.Drawing.Point(123, 18);
            this.txtCustomerTypeId.Name = "txtCustomerTypeId";
            this.txtCustomerTypeId.ReadOnly = true;
            this.txtCustomerTypeId.Size = new System.Drawing.Size(116, 23);
            this.txtCustomerTypeId.TabIndex = 2;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDescription.Location = new System.Drawing.Point(23, 51);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(94, 21);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Descripción:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(123, 51);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(231, 23);
            this.txtDescription.TabIndex = 4;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // groupTypes
            // 
            this.groupTypes.Controls.Add(this.gridCustomerType);
            this.groupTypes.Location = new System.Drawing.Point(12, 144);
            this.groupTypes.Name = "groupTypes";
            this.groupTypes.Size = new System.Drawing.Size(344, 298);
            this.groupTypes.TabIndex = 5;
            this.groupTypes.TabStop = false;
            this.groupTypes.Text = "Tipos registrados";
            // 
            // gridCustomerType
            // 
            this.gridCustomerType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCustomerType.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridCustomerType.Location = new System.Drawing.Point(6, 22);
            this.gridCustomerType.MultiSelect = false;
            this.gridCustomerType.Name = "gridCustomerType";
            this.gridCustomerType.ReadOnly = true;
            this.gridCustomerType.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.gridCustomerType.RowTemplate.Height = 25;
            this.gridCustomerType.Size = new System.Drawing.Size(328, 260);
            this.gridCustomerType.TabIndex = 1;
            this.gridCustomerType.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCustomerType_CellContentDoubleClick);
            this.gridCustomerType.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCustomerType_CellDoubleClick);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.Location = new System.Drawing.Point(245, 16);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 29);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(18, 90);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 48);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(107, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 48);
            this.button1.TabIndex = 8;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormCustomerTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 463);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.groupTypes);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtCustomerTypeId);
            this.Controls.Add(this.lblTypeId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormCustomerTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento Tipo de clientes";
            this.Load += new System.EventHandler(this.FormCustomerTypes_Load);
            this.groupTypes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomerType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblTypeId;
        private TextBox txtCustomerTypeId;
        private Label lblDescription;
        private TextBox txtDescription;
        private GroupBox groupTypes;
        private DataGridView gridCustomerType;
        private Button btnDelete;
        private Button btnSave;
        private Button button1;
    }
}