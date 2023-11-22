namespace project_cafe.Data
{
    internal class MonthlyAction
    {
        public int Id { get; set; }
        public string Month { get; set; }
        public ICollection<Action> Actions { get; set; }
        public override string ToString()
        {
            return Month;
        }
    }
}
