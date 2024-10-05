using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; }
        public int Status { get; set; }
        public string? Message { get; set; }

        public T? Data { get; set; }

        public List<T>? Errors { get; set; }

    }
}
