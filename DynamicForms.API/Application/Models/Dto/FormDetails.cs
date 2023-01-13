using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Dto
{
    public class FormDetails
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool? UserPassed { get; set; }
        public int SubmitsCount { get; set; }
    }
}
