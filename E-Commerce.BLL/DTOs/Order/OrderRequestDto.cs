using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.DTOs.Orders;

public class OrderRequestDto
{
    public DateTime OrderDate { get; set; }

    public decimal TotalAmount { get; set; }
    
    public string Status { get; set; } = string.Empty;

}
