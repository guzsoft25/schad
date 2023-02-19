using Ecommerce.Shared.Models.Daos;
using Ecommerce.Shared.Models.Dtos;
using Ecommerce.Shared.Utilities;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace Ecommerce.Desktop
{
    public partial class FormInvoices : Form
    {
        public FormInvoices()
        {
            InitializeComponent();
        }

        private List<InvoiceDetailDto> invoiceDetails = new List<InvoiceDetailDto>();
        private List<ProductDto> Products = new List<ProductDto>();
        private List<CustomerDto> Customers = new List<CustomerDto>();

        private double TotalAmount;
        private double SubTotalAmount;
        private double TotalItbisAmount;
        private int TotalItems;

        private string errorMessage;

        private void FormInvoices_Load(object sender, EventArgs e)
        {
            GetCustomers();
            PopulateCustomerComboBox();

            GetProducts();
            PopulateProductComboBox();
        }

        private void GetCustomers()
        {
            using (var httpClient = new HttpClient()) {

                Customers.Clear();
                var result = httpClient.GetFromJsonAsync<List<CustomerDto>>
                    ("https://localhost:7174/api/Customer").Result;

                if (result != null) {
                    Customers = result;
                }
            }
        }
        private void GetProducts()
        {
            using (var httpClient = new HttpClient()) {

                Products.Clear();
                var result = httpClient.GetFromJsonAsync<List<ProductDto>>
                    ("https://localhost:7174/api/Product").Result;

                if (result != null) {
                    Products = result;
                }
            }
        }

        //Customer ComboBox
        private void PopulateCustomerComboBox()
        {
            //comboCustomer.Items.Clear();
            comboCustomer.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboCustomer.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboCustomer.DataSource = Customers;
            comboCustomer.DisplayMember = "Name";
            comboCustomer.ValueMember = "CustomerId";

        }
        private void PopulateProductComboBox()
        {
            //comboCustomer.Items.Clear();
            comboProduct.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboProduct.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboProduct.DataSource = Products;
            comboProduct.DisplayMember = "Name";
            comboProduct.ValueMember = "ProductId";

        }
        private void PopulateSelectedProductGrid()
        {

            //Dategrid Configurations
            gridSelectedProducts.DataSource = null;
            gridSelectedProducts.DataSource = invoiceDetails;

            gridSelectedProducts.Update();
            gridSelectedProducts.Refresh();
        }
        private void UpdateTotals()
        {
            SubTotalAmount = (double)invoiceDetails.Sum(x => x.TotalAmount);
            TotalItbisAmount = SubTotalAmount * (0.18);
            TotalAmount = Math.Round((SubTotalAmount + TotalItbisAmount), 2);
            TotalItems = invoiceDetails.Count();

            txtInvoiceTotal.Text = TotalAmount.ToString();
            lblTotalItems.Text = TotalItems.ToString();
            txtSubTotal.Text = SubTotalAmount.ToString();
            txtItbis.Text = TotalItbisAmount.ToString();

            NumQuantity.Value = 1;
        }

        private void Reset()
        { 
           invoiceDetails.Clear();
            PopulateSelectedProductGrid();
            UpdateTotals();

            txtRnc.Text = string.Empty;
            txtCustomerType.Text = string.Empty;
            comboCustomer.SelectedItem = null;

            comboProduct.SelectedItem = null;
            txtUnitPrice.Text = string.Empty;

        }

        private void comboCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            comboCustomer.DroppedDown = false;
        }

        private void comboCustomer_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCustomer.SelectedValue != null) {
                var customer = (CustomerDto)comboCustomer.SelectedItem;
                txtRnc.Text = customer.Rnc;
                txtCustomerType.Text = customer.CustomerType;
            }
            
        }

        private void comboProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            comboProduct.DroppedDown = false;
        }

        private void comboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboProduct.SelectedValue != null) {
                var product = (ProductDto)comboProduct.SelectedItem;
                txtUnitPrice.Text = product.Price.ToString();

                NumQuantity.Focus();
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(comboProduct.SelectedItem != null) {

                var selectedProduct = (ProductDto)comboProduct.SelectedItem;
                var currentItem = invoiceDetails.FirstOrDefault(x => x.ProductId == selectedProduct.ProductId);

                if (currentItem == null) {
                    invoiceDetails.Add(new InvoiceDetailDto {
                        Price = selectedProduct.Price,
                        ProductId = selectedProduct.ProductId,
                        ProductName = selectedProduct.Name,
                        Quantity = (int)NumQuantity.Value,
                        TotalAmount = ((int)NumQuantity.Value) * selectedProduct.Price

                    });

                    PopulateSelectedProductGrid();
                    UpdateTotals();
                     
                }
                else {
                    DialogResult result = MessageBox.Show($"Este producto ya se encuentra en la lista. Esta seguro de editarlo ?", "Confirmation", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes) {
                        invoiceDetails.Remove(currentItem);
                        invoiceDetails.Add(new InvoiceDetailDto {
                            Price = selectedProduct.Price,
                            ProductId = selectedProduct.ProductId,
                            ProductName = selectedProduct.Name,
                            Quantity = (int)NumQuantity.Value,
                            TotalAmount = ((int)NumQuantity.Value) * selectedProduct.Price
                        });

                        PopulateSelectedProductGrid();
                        UpdateTotals();
                    }
                }


            }
            else { 
                MessageBox.Show($"Favor seleccionar un producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridSelectedProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridSelectedProducts.Rows.Count > 0) {
                int rowNo = e.RowIndex;
                int productId = int.Parse(gridSelectedProducts.Rows[rowNo].Cells[0].Value.ToString());

                DialogResult result = MessageBox.Show($"Está seguro de eliminar el producto seleccionado ?", "Confirmation", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes) {
                    var item = invoiceDetails.FirstOrDefault(x => x.ProductId == productId);

                    if (item != null) {
                        invoiceDetails.Remove(item);

                        PopulateSelectedProductGrid();
                        UpdateTotals();
                    }
                }
            }
           
        }

        private void btnSaveInvoice_Click(object sender, EventArgs e)
        {
            if (invoiceDetails.Count > 0)
            {

                if (comboCustomer.SelectedItem != null)
                {
                    var newInvoice = new InvoiceDto {
                        CustomerId = (long)comboCustomer.SelectedValue,
                        Details = invoiceDetails
                    };

                    //Call Invoice Api Here..
                    string url = "https://localhost:7174/api/Invoice";

                    var response = HttpUtilities.Post<InvoiceDto, ResponseDto>(url, newInvoice, ref errorMessage);

                    if (response != null) {

                        if (!response.isError) {
                            MessageBox.Show("La factura fue creada exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Reset();
                            GetCustomers();
                            PopulateCustomerComboBox();
                            PopulateProductComboBox();

                            DialogResult result = MessageBox.Show($"Desea imprimir su factura ?", "Confirmation", MessageBoxButtons.YesNo);

                            if(result == DialogResult.Yes) {
                                MessageBox.Show("Lo sentimos :( está funcionalidad aun se encuentra en desarrollo");
                            }

                        }
                        else {
                            MessageBox.Show($"{response.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else {
                        MessageBox.Show("No fue posible crear la factura. Favor contactar a su administrador de sistemas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else {
                    MessageBox.Show($"Favor seleccionar un cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show($"Seleccione por lo menos un articulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewInvoice_Click(object sender, EventArgs e)
        {
            if (invoiceDetails.Count > 0)
            {
                DialogResult result = MessageBox.Show($"Existe una transacción en proceso. Desea continuar con una nueva?", "Confirmation", MessageBoxButtons.YesNo);

                if(result == DialogResult.Yes)
                {
                    Reset();
                }
            }
            else
            {
                Reset();
            }


        }
    }
}
