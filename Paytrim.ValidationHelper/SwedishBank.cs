namespace Paytrim.ValidationHelper
{
    public class SwedishBank
    {
        public SwedishBank(string name, int type, int comment, string regex)
        {
            Name = name;
            Type = type;
            Comment = comment;
            Regex = regex;
        }

        public string Name { get; set; }
        public int Type { get; set; }
        public int Comment { get; set; }
        public string Regex { get; set; }
    }
}
