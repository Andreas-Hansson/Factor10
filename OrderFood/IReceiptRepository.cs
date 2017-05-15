using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen
{
    public interface IReceiptRepository
    {
        List<Receipt> GetAllReceipts();
    }
}
