using System.Drawing.Drawing2D;
using System.Net.Http.Json;
using Ecommerce.Shared.Models.Dtos;
using Ecommerce.Shared.Utilities;

namespace Ecommerce.Desktop
{
    public partial class FormCustomers : Form
    {
        private List<CustomerDto> customers = null;
        private List<CustomerTypeDto> customerTypes = null;
        private string errorMessage = string.Empty;

        public FormCustomers()
        {
            customers = new List<CustomerDto>();
            customerTypes = new List<CustomerTypeDto>();
           
            InitializeComponent();

            panelNewType.Hide();

            lblAddressErrorMessage.Visible = true;
            lblNameErrorMessage.Visible = true;
            lblRncErrorMessage.Visible = true;
            btnSaveCustomer.Enabled = false;
            btnDelete.Visible = false;
            btnSaveCustomer.Text = "Guardar";
        }

        

        private void FormCustomers_Load(object sender, EventArgs e)
        {
            //Get From Service
            GetCustomers();
            GetCustomerTypes();

            //Populate
            PopulateComboBox();
            PopulateGrid();


        }

        private void GetCustomers()
        {
            using (var httpClient = new HttpClient()) {

                customers.Clear();
                var result =  httpClient.GetFromJsonAsync<List<CustomerDto>>
                    ("https://localhost:7174/api/Customer").Result;

                if (result != null) {
                    customers = result;
                }
            }

        }
        public void GetCustomerTypes()
        {
            using (var httpClient = new HttpClient())
            {
                customerTypes.Clear();
                var result = httpClient.GetFromJsonAsync<List<CustomerTypeDto>>
                    ("https://localhost:7174/api/CustomerType").Result;

                if (result != null)
                {
                    customerTypes = result;
                }
            }
        }

        private void PopulateGrid()
        { 
            //Dategrid Configurations
            gridCustomers.DataSource = null;
            gridCustomers.DataSource = customers;
        }

        private void PopulateComboBox()
        {
           //comboCustomerType.Items.Clear();
           comboCustomerType.DropDownStyle = ComboBoxStyle.DropDownList;
           comboCustomerType.DataSource = customerTypes;
           comboCustomerType.DisplayMember = "Description";
           comboCustomerType.ValueMember = "CustomerTypeId";
        }

        private void ClearForm()
        { 
            txtCustomerId.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtRnc.Text = string.Empty;
            textBox1.Text = string.Empty;
            btnDelete.Visible = false;
            btnSaveCustomer.Text = "Guardar";
            PopulateComboBox();
        }

        private void btnCancelType_Click(object sender, EventArgs e)
        {
            panelNewType.Hide();
            txtCustomerTypeDescription.Clear();
        }

        private void btnNewType_Click(object sender, EventArgs e)
        {
            panelNewType.Show();
            txtCustomerTypeDescription.Focus();
        }

        private void btnSaveType_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCustomerTypeDescription.Text))
            {
                string customerTypeDescription = txtCustomerTypeDescription.Text;
                
                var exist = customerTypes.FirstOrDefault(x => x.Description.ToUpper() == customerTypeDescription.ToUpper());

                if(exist == null) {

                    CustomerTypeDto newType = new CustomerTypeDto {
                        Description = customerTypeDescription
                    };

                    string url = "https://localhost:7174/api/CustomerType";

                    var response = HttpUtilities.Post<CustomerTypeDto, ResponseDto>(url, newType, ref errorMessage);

                    if(response != null) {

                        if (!response.isError) {
                            GetCustomerTypes();
                            PopulateComboBox();
                            panelNewType.Hide();

                            txtCustomerTypeDescription.Clear();

                        }
                        else {
                            MessageBox.Show($"{response.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else {
                        MessageBox.Show("No fue posible crear el nuevo tipo. Favor contactar a su administrador de sistemas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else {
                    MessageBox.Show($"El tipo {customerTypeDescription} ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else {
                MessageBox.Show("La descripción del tipo es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCustomerTypeDescription.Focus();
            }
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCustomerName.Text)) {
                lblNameErrorMessage.Visible = false;

                if(!string.IsNullOrEmpty(txtCustomerName.Text) && !string.IsNullOrEmpty(txtRnc.Text) && !string.IsNullOrEmpty(textBox1.Text)) {
                    btnSaveCustomer.Enabled = true;
                }
                
            }
            else {
                lblNameErrorMessage.Visible = true;
                btnSaveCustomer.Enabled = false;
            }
        }

        private void txtRnc_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRnc.Text)) {
                lblRncErrorMessage.Visible = false;
                if (!string.IsNullOrEmpty(txtCustomerName.Text) && !string.IsNullOrEmpty(txtRnc.Text) && !string.IsNullOrEmpty(textBox1.Text))
                {
                    btnSaveCustomer.Enabled = true;
                }
            }
            else {
                lblRncErrorMessage.Visible = true;
                btnSaveCustomer.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text)) {
                lblAddressErrorMessage.Visible = false;
                if (!string.IsNullOrEmpty(txtCustomerName.Text) && !string.IsNullOrEmpty(txtRnc.Text) && !string.IsNullOrEmpty(textBox1.Text))
                {
                    btnSaveCustomer.Enabled = true;
                }
            }
            else {
                lblAddressErrorMessage.Visible = true;
                btnSaveCustomer.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtCustomerId.Text)) {
                //Create New
                var exist = customers.FirstOrDefault(x => x.Rnc == txtRnc.Text);

                if (exist == null) {

                    var selectedType = (CustomerTypeDto)comboCustomerType.SelectedItem;

                    CustomerDto newCustomer = new CustomerDto {
                        Address = textBox1.Text,
                        CustomerType = selectedType.Description,
                        CustomerTypeId = selectedType.CustomerTypeId,
                        Name = txtCustomerName.Text,
                        Rnc = txtRnc.Text,
                        Status = true

                    };

                    string url = "https://localhost:7174/api/Customer";
                    var response = HttpUtilities.Post<CustomerDto, ResponseDto>(url, newCustomer, ref errorMessage);


                    if (response != null)
                    {

                        if (!response.isError)
                        {
                            MessageBox.Show("El cliente fue creado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GetCustomers();
                            PopulateGrid();
                            ClearForm();

                        }
                        else
                        {
                            MessageBox.Show($"{response.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No fue posible crear el cliente. Favor contactar a su administrador de sistemas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else {
                    MessageBox.Show($"El cliente de rnc {txtRnc.Text} ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {
                //Update
                long CustomerId = long.Parse(txtCustomerId.Text);
                string url = $"https://localhost:7174/api/Customer/{CustomerId}";

                var selectedType = (CustomerTypeDto)comboCustomerType.SelectedItem;

                CustomerDto updateCustomer = new CustomerDto {
                    Address = textBox1.Text,
                    CustomerType = selectedType.Description,
                    CustomerTypeId = selectedType.CustomerTypeId,
                    Name = txtCustomerName.Text,
                    Rnc = txtRnc.Text,
                    Status = true

                };
                var response = HttpUtilities.Put<CustomerDto, ResponseDto>(url, updateCustomer, ref errorMessage);

                if (response != null) {

                    if (!response.isError) {
                        MessageBox.Show("El cliente fue modificado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetCustomers();
                        PopulateGrid();
                        ClearForm();

                    }
                    else {
                        MessageBox.Show($"{response.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else {
                    MessageBox.Show("No fue posible modificar el cliente. Favor contactar a su administrador de sistemas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void gridCustomers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowNo = e.RowIndex;
            btnDelete.Visible = true;
            btnSaveCustomer.Text = "Modificar";
            
            string CustomerId = gridCustomers.Rows[rowNo].Cells[0].Value.ToString();
            string Rnc = gridCustomers.Rows[rowNo].Cells[1].Value.ToString();
            string Name = gridCustomers.Rows[rowNo].Cells[2].Value.ToString();
            string Address = gridCustomers.Rows[rowNo].Cells[3].Value.ToString();

            int CustomerTypeId = int.Parse(gridCustomers.Rows[rowNo].Cells[6].Value.ToString());
            //var type = customerTypes.FirstOrDefault(x => x.CustomerTypeId == CustomerTypeId);

            txtCustomerId.Text = CustomerId;
            txtCustomerName.Text = Name;
            txtRnc.Text = Rnc;
            textBox1.Text = Address;
            
            comboCustomerType.SelectedValue = CustomerTypeId;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Está seguro que desea eliminar el cliente {txtCustomerName.Text}", "Confirmation", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes) {

                long CustomerId = long.Parse(txtCustomerId.Text);
                string url = $"https://localhost:7174/api/Customer/{CustomerId}";

                var response = HttpUtilities.Delete<ResponseDto>(url, ref errorMessage);

                if (response != null) {

                    if (!response.isError) {
                        MessageBox.Show("El cliente fue eliminado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetCustomers();
                        PopulateGrid();
                        ClearForm();

                    }
                    else {
                        MessageBox.Show($"{response.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else {
                    MessageBox.Show("No fue posible eliminar el cliente. Favor contactar a su administrador de sistemas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
