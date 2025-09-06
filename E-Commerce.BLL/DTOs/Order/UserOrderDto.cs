using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.DTOs.Order;
public class UserOrderResponseDto
{
    public int CountOfItems { get; set; }
    public decimal TotalAmoutForeachOrder { get; set; }
}
