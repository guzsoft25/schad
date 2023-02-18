namespace Ecommerce.Desktop
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void mantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCustomers formCustomers = new FormCustomers();
            formCustomers.ShowDialog(this);
        }

        private void mantenimientoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormCustomerTypes customerTypes = new FormCustomerTypes();
            customerTypes.ShowDialog(this);
        }

        private void facturarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInvoices formInvoices = new FormInvoices();
            formInvoices.ShowDialog(this);
        }
    }
}