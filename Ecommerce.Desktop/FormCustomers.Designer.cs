namespace Ecommerce.Desktop
{
    partial class FormCustomers
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
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblRnc = new System.Windows.Forms.Label();
            this.txtRnc = new System.Windows.Forms.TextBox();
            this.lblCustomerType = new System.Windows.Forms.Label();
            this.comboCustomerType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridCustomers = new System.Windows.Forms.DataGridView();
            this.btnSaveCustomer = new System.Windows.Forms.Button();
            this.btnNewType = new System.Windows.Forms.Button();
            this.panelNewType = new System.Windows.Forms.Panel();
            this.btnCancelType = new System.Windows.Forms.Button();
            this.btnSaveType = new System.Windows.Forms.Button();
            this.txtCustomerTypeDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblAddnewType = new System.Windows.Forms.Label();
            this.lblNameErrorMessage = new System.Windows.Forms.Label();
            this.lblRncErrorMessage = new System.Windows.Forms.Label();
            this.lblAddressErrorMessage = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomers)).BeginInit();
            this.panelNewType.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCustomerId.Location = new System.Drawing.Point(69, 12);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.Size = new System.Drawing.Size(31, 21);
            this.lblCustomerId.TabIndex = 0;
            this.lblCustomerId.Text = "ID:";
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Enabled = false;
            this.txtCustomerId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCustomerId.Location = new System.Drawing.Point(106, 12);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.ReadOnly = true;
            this.txtCustomerId.Size = new System.Drawing.Size(231, 23);
            this.txtCustomerId.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(24, 48);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(77, 21);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Nombre:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(106, 50);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(474, 23);
            this.txtCustomerName.TabIndex = 3;
            this.txtCustomerName.TextChanged += new System.EventHandler(this.txtCustomerName_TextChanged);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAddress.Location = new System.Drawing.Point(12, 186);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(87, 21);
            this.lblAddress.TabIndex = 4;
            this.lblAddress.Text = "Dirección:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(105, 186);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(475, 71);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblRnc
            // 
            this.lblRnc.AutoSize = true;
            this.lblRnc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRnc.Location = new System.Drawing.Point(54, 94);
            this.lblRnc.Name = "lblRnc";
            this.lblRnc.Size = new System.Drawing.Size(47, 21);
            this.lblRnc.TabIndex = 6;
            this.lblRnc.Text = "RNC:";
            // 
            // txtRnc
            // 
            this.txtRnc.Location = new System.Drawing.Point(106, 94);
            this.txtRnc.Name = "txtRnc";
            this.txtRnc.Size = new System.Drawing.Size(215, 23);
            this.txtRnc.TabIndex = 7;
            this.txtRnc.TextChanged += new System.EventHandler(this.txtRnc_TextChanged);
            // 
            // lblCustomerType
            // 
            this.lblCustomerType.AutoSize = true;
            this.lblCustomerType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCustomerType.Location = new System.Drawing.Point(51, 148);
            this.lblCustomerType.Name = "lblCustomerType";
            this.lblCustomerType.Size = new System.Drawing.Size(48, 21);
            this.lblCustomerType.TabIndex = 8;
            this.lblCustomerType.Text = "Tipo:";
            // 
            // comboCustomerType
            // 
            this.comboCustomerType.FormattingEnabled = true;
            this.comboCustomerType.Location = new System.Drawing.Point(105, 146);
            this.comboCustomerType.Name = "comboCustomerType";
            this.comboCustomerType.Size = new System.Drawing.Size(277, 23);
            this.comboCustomerType.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridCustomers);
            this.groupBox1.Location = new System.Drawing.Point(12, 375);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 226);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Clientes Registrados";
            // 
            // gridCustomers
            // 
            this.gridCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCustomers.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridCustomers.Location = new System.Drawing.Point(6, 22);
            this.gridCustomers.MultiSelect = false;
            this.gridCustomers.Name = "gridCustomers";
            this.gridCustomers.ReadOnly = true;
            this.gridCustomers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.gridCustomers.RowTemplate.Height = 25;
            this.gridCustomers.Size = new System.Drawing.Size(562, 198);
            this.gridCustomers.TabIndex = 0;
            this.gridCustomers.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCustomers_CellContentDoubleClick);
            // 
            // btnSaveCustomer
            // 
            this.btnSaveCustomer.Location = new System.Drawing.Point(12, 302);
            this.btnSaveCustomer.Name = "btnSaveCustomer";
            this.btnSaveCustomer.Size = new System.Drawing.Size(131, 55);
            this.btnSaveCustomer.TabIndex = 11;
            this.btnSaveCustomer.Text = "Guardar";
            this.btnSaveCustomer.UseVisualStyleBackColor = true;
            this.btnSaveCustomer.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNewType
            // 
            this.btnNewType.Location = new System.Drawing.Point(388, 146);
            this.btnNewType.Name = "btnNewType";
            this.btnNewType.Size = new System.Drawing.Size(61, 24);
            this.btnNewType.TabIndex = 12;
            this.btnNewType.Text = "Nuevo";
            this.btnNewType.UseVisualStyleBackColor = true;
            this.btnNewType.Click += new System.EventHandler(this.btnNewType_Click);
            // 
            // panelNewType
            // 
            this.panelNewType.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelNewType.Controls.Add(this.btnCancelType);
            this.panelNewType.Controls.Add(this.btnSaveType);
            this.panelNewType.Controls.Add(this.txtCustomerTypeDescription);
            this.panelNewType.Controls.Add(this.lblDescription);
            this.panelNewType.Controls.Add(this.lblAddnewType);
            this.panelNewType.Location = new System.Drawing.Point(208, 176);
            this.panelNewType.Name = "panelNewType";
            this.panelNewType.Size = new System.Drawing.Size(372, 152);
            this.panelNewType.TabIndex = 13;
            // 
            // btnCancelType
            // 
            this.btnCancelType.Location = new System.Drawing.Point(96, 100);
            this.btnCancelType.Name = "btnCancelType";
            this.btnCancelType.Size = new System.Drawing.Size(75, 23);
            this.btnCancelType.TabIndex = 4;
            this.btnCancelType.Text = "Cancelar";
            this.btnCancelType.UseVisualStyleBackColor = true;
            this.btnCancelType.Click += new System.EventHandler(this.btnCancelType_Click);
            // 
            // btnSaveType
            // 
            this.btnSaveType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSaveType.Location = new System.Drawing.Point(15, 100);
            this.btnSaveType.Name = "btnSaveType";
            this.btnSaveType.Size = new System.Drawing.Size(75, 23);
            this.btnSaveType.TabIndex = 3;
            this.btnSaveType.Text = "Guardar";
            this.btnSaveType.UseVisualStyleBackColor = false;
            this.btnSaveType.Click += new System.EventHandler(this.btnSaveType_Click);
            // 
            // txtCustomerTypeDescription
            // 
            this.txtCustomerTypeDescription.Location = new System.Drawing.Point(96, 41);
            this.txtCustomerTypeDescription.Name = "txtCustomerTypeDescription";
            this.txtCustomerTypeDescription.Size = new System.Drawing.Size(225, 23);
            this.txtCustomerTypeDescription.TabIndex = 2;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDescription.Location = new System.Drawing.Point(6, 41);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(84, 17);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "Descripción:";
            // 
            // lblAddnewType
            // 
            this.lblAddnewType.AutoSize = true;
            this.lblAddnewType.Font = new System.Drawing.Font("Segoe UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lblAddnewType.Location = new System.Drawing.Point(89, 5);
            this.lblAddnewType.Name = "lblAddnewType";
            this.lblAddnewType.Size = new System.Drawing.Size(148, 20);
            this.lblAddnewType.TabIndex = 0;
            this.lblAddnewType.Text = "Agregar Nuevo tipo";
            // 
            // lblNameErrorMessage
            // 
            this.lblNameErrorMessage.AutoSize = true;
            this.lblNameErrorMessage.BackColor = System.Drawing.SystemColors.Control;
            this.lblNameErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblNameErrorMessage.Location = new System.Drawing.Point(106, 76);
            this.lblNameErrorMessage.Name = "lblNameErrorMessage";
            this.lblNameErrorMessage.Size = new System.Drawing.Size(119, 15);
            this.lblNameErrorMessage.TabIndex = 13;
            this.lblNameErrorMessage.Text = "Nombre es requerido";
            // 
            // lblRncErrorMessage
            // 
            this.lblRncErrorMessage.AutoSize = true;
            this.lblRncErrorMessage.BackColor = System.Drawing.SystemColors.Control;
            this.lblRncErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblRncErrorMessage.Location = new System.Drawing.Point(106, 120);
            this.lblRncErrorMessage.Name = "lblRncErrorMessage";
            this.lblRncErrorMessage.Size = new System.Drawing.Size(99, 15);
            this.lblRncErrorMessage.TabIndex = 14;
            this.lblRncErrorMessage.Text = "RNC es requerido";
            // 
            // lblAddressErrorMessage
            // 
            this.lblAddressErrorMessage.AutoSize = true;
            this.lblAddressErrorMessage.BackColor = System.Drawing.SystemColors.Control;
            this.lblAddressErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblAddressErrorMessage.Location = new System.Drawing.Point(106, 260);
            this.lblAddressErrorMessage.Name = "lblAddressErrorMessage";
            this.lblAddressErrorMessage.Size = new System.Drawing.Size(139, 15);
            this.lblAddressErrorMessage.TabIndex = 15;
            this.lblAddressErrorMessage.Text = "La Dirección es requerida";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(149, 302);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(131, 55);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "Limpiar";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDelete.Location = new System.Drawing.Point(343, 13);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 31);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FormCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 613);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.panelNewType);
            this.Controls.Add(this.lblAddressErrorMessage);
            this.Controls.Add(this.lblRncErrorMessage);
            this.Controls.Add(this.lblNameErrorMessage);
            this.Controls.Add(this.btnNewType);
            this.Controls.Add(this.btnSaveCustomer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboCustomerType);
            this.Controls.Add(this.lblCustomerType);
            this.Controls.Add(this.txtRnc);
            this.Controls.Add(this.lblRnc);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtCustomerId);
            this.Controls.Add(this.lblCustomerId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormCustomers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento Clientes";
            this.Load += new System.EventHandler(this.FormCustomers_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomers)).EndInit();
            this.panelNewType.ResumeLayout(false);
            this.panelNewType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblCustomerId;
        private TextBox txtCustomerId;
        private Label lblName;
        private TextBox txtCustomerName;
        private Label lblAddress;
        private TextBox textBox1;
        private Label lblRnc;
        private TextBox txtRnc;
        private Label lblCustomerType;
        private ComboBox comboCustomerType;
        private GroupBox groupBox1;
        private DataGridView gridCustomers;
        private Button btnSaveCustomer;
        private Button btnNewType;
        private Panel panelNewType;
        private Label lblAddnewType;
        private Button btnCancelType;
        private Button btnSaveType;
        private TextBox txtCustomerTypeDescription;
        private Label lblDescription;
        private Label lblNameErrorMessage;
        private Label lblRncErrorMessage;
        private Label lblAddressErrorMessage;
        private Button btnClear;
        private Button btnDelete;
    }
}