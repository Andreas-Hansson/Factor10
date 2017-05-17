using System.Collections.Generic;

namespace Kitchen
{
    public class ReceiptRepository:IReceiptRepository
    {
        public static string PancakeReceipt = "Pancake";
        public static string MeatballsAndPotatoRecept = "MeatballsAndPotato";

        public List<Receipt> Receipts;

        public ReceiptRepository()
        {
            Receipts = new List<Receipt>();
        }

        public List<Receipt> GetAllReceipts()
        {
            return Receipts;
        }

        public void Add(Receipt receipt)
        {
            Receipts.Add(receipt);
        }
    }
}
