namespace Ecommerce.Shared.Models.Daos
{
    public class CustomerTypeDao
    {
        public int CustomerTypeId { get; set; }
        public string Description { get; set; }

        public bool Status { get; set; }
        public ICollection<CustomerDao> Customers { get; set; }
    }
}




