using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO_DTO
{
    public class ProductUpdateDTO
    {
        public int ProductId { get; set; }
        public string productName { get; set; }
        public int catagoryId { get; set; }
    }
}
