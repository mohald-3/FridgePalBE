using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Items
{
    public class ItemWithImageDto
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int CategoryId { get; set; }

        public IFormFile? Image { get; set; } // for the uploaded image
    }
}
