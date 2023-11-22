namespace project_cafe.Data
{
    internal class Action
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Period { get; set; }
        public int MonthlyActionId { get; set; }
        public MonthlyAction MonthlyAction { get; set; }
        public override string ToString()
        {
            return $"{Name} | {Period}";
        }
    }
}
