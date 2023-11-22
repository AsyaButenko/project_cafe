namespace project_cafe.Data
{
    internal class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Good> Goods { get; set; }
        public override string ToString()
        {
            return Name; 
        }
    }
}
