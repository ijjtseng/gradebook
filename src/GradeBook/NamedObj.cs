namespace GradeBook
{
    public class NamedObj // base class for inheritance
    {
        public NamedObj(string name)
        {
            Name = name; 
        }
        public string Name //property - encapsulate state and data, get set
        {
            get; set;
        }
    }
}