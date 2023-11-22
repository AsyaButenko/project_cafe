namespace project_cafe.Data
{
    internal class Good
    {
        public int Id {  get; set; }
        public string Name {  get; set; }
        public string Description {  get; set; }
        public int Quantity { get; set; }
        public string Measure { get; set; }
        public int Price {  get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public override string ToString()
        {
            return $"{Name}  | {Description} |  {Quantity} {Measure}  -  {Price} руб"; 
        }
    }
}
