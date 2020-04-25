namespace Library.Model
{
    public class Publisher
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Publisher(string id, string name)
        {
            Id=id;
            Name = name;
        }
    }
}