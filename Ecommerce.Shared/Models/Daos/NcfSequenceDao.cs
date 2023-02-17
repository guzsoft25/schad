namespace Ecommerce.Shared.Models.Daos
{
    public class NcfSequenceDao
    {
        public long SequenceId { get; set; }
        public string Serie { get; set; }
        public string VoucherType { get; set; }
        public int StartSequence { get; set; }
        public int EndSequence { get; set; }
        public int? LastUsedSequence { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public bool IsActive { get; set; }
    }
}








