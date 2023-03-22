using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Dto
{
    public record QuestionDto
    {
        public int Position { get; init; }
        public bool IsRequired { get; init; }
        public string Type { get; init; }
        public string Config { get; set; }
    }
}
