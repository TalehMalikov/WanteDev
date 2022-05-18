namespace WanteDev.Models
{
    public class ProgrammingCategoryModel : BaseModel
    {
        public string? Name { get; set; }   
        public override object Clone()
        {
            throw new System.NotImplementedException();
        }

        public override bool IsValid(out string message)
        {
            throw new System.NotImplementedException();
        }
    }
}