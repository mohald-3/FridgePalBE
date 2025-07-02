using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Items
{
    public class AnalyzeImageRequestDto
    {
        public IFormFile Image { get; set; }
    }
}
