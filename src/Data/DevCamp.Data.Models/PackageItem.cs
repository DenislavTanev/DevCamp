namespace DevCamp.Data.Models
{
    public class PackageItem
    {
        public int Id { get; set; }

        public int PackageId { get; set; }

        public Package Package { get; set; }

        public int ItemId { get; set; }

        public Item Item { get; set; }

        public string Content { get; set; }
    }
}
