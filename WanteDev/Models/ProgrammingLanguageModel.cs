using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanteDev.Models
{
    public class ProgrammingLanguageModel:BaseModel
    {
        public string? Name { get; set; }
        public override object Clone()
        {
            return new ProgrammingLanguageModel()
            {
                Id = Id,
                Name = Name,
                Category= Category
            };
        }
        public ProgrammingCategoryModel? Category { get; set; }
        public override bool IsValid(out string message)
        {
            throw new NotImplementedException();
        }
    }

    
}
