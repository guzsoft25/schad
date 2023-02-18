using Ecommerce.Shared.Models.Dtos;
using Ecommerce.Shared.Utilities;
using System.Net.Http.Json;
using System.Security.Policy;

namespace Ecommerce.Desktop
{
    public partial class FormCustomerTypes : Form
    {
        private List<CustomerTypeDto> customerTypes = null;
        private string errorMessage = string.Empty;
        public FormCustomerTypes()
        {
            customerTypes = new List<CustomerTypeDto>();

            InitializeComponent();

            btnDelete.Visible = false;
            btnSave.Text = "Guardar";
            btnSave.Enabled = false;
        }

        private void FormCustomerTypes_Load(object sender, EventArgs e)
        {
            GetCustomerTypes();
            PopulateGrid();
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
            gridCustomerType.DataSource = null;
            gridCustomerType.DataSource = customerTypes;
        }

        private void ClearForm()
        {
            btnDelete.Visible = false;
            btnSave.Text = "Guardar";
            txtCustomerTypeId.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtDescription.Focus();
            btnSave.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Está seguro que desea eliminar el tipo {txtDescription.Text}", "Confirmation", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {

                long CustomerTypeId = long.Parse(txtCustomerTypeId.Text);
                string url = $"https://localhost:7174/api/CustomerType/{CustomerTypeId}";

                var response = HttpUtilities.Delete<ResponseDto>(url, ref errorMessage);

                if (response != null)
                {

                    if (!response.isError)
                    {
                        MessageBox.Show("El tipo fue eliminado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetCustomerTypes();
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
                    MessageBox.Show("No fue posible eliminar el tipo. Favor contactar a su administrador de sistemas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void gridCustomerType_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridCustomerType_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowNo = e.RowIndex;
            btnDelete.Visible = true;
            btnSave.Text = "Modificar";

            int CustomerTypeId = int.Parse(gridCustomerType.Rows[rowNo].Cells[0].Value.ToString());
            string Description = gridCustomerType.Rows[rowNo].Cells[1].Value.ToString();

            txtCustomerTypeId.Text = CustomerTypeId.ToString();
            txtDescription.Text = Description;

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var customerType = new CustomerTypeDto
            {
                Description = txtDescription.Text
            };

            if (string.IsNullOrEmpty(txtCustomerTypeId.Text))
            {

                //New
                var alreadyExist = customerTypes.FirstOrDefault(x => x.Description.ToUpper() == txtDescription.Text.ToUpper());

                if (alreadyExist == null)
                {

                    string url = "https://localhost:7174/api/CustomerType";
                    var response = HttpUtilities.Post<CustomerTypeDto, ResponseDto>(url, customerType, ref errorMessage);

                    if (response != null)
                    {

                        if (!response.isError)
                        {
                            MessageBox.Show("El tipo fue creado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GetCustomerTypes();
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
                        MessageBox.Show("No fue posible crear el tipo. Favor contactar a su administrador de sistemas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"El tipo {txtDescription.Text} ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {

                int CustomerTypeId = int.Parse(txtCustomerTypeId.Text);

                //Update
                var alreadyExist = customerTypes.FirstOrDefault(x => x.Description.ToUpper() == txtDescription.Text.ToUpper() && x.CustomerTypeId != CustomerTypeId);

                if (alreadyExist == null) {

                    string url = $"https://localhost:7174/api/CustomerType/{CustomerTypeId}";
                    var response = HttpUtilities.Put<CustomerTypeDto, ResponseDto>(url, customerType, ref errorMessage);

                    if (response != null) {

                        if (!response.isError) {
                            MessageBox.Show("El tipo fue modificado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GetCustomerTypes();
                            PopulateGrid();
                            ClearForm();

                        }
                        else {
                            MessageBox.Show($"{response.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else {
                        MessageBox.Show($"La descripción de tipo {txtDescription.Text} ya es utilizado por un registro existente. Favor utilizar otra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
