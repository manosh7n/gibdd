using SQLite;

namespace gibdd
{
    [Table ("Messages")]
    public class Messages
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string message { get; set; }

        public Messages(string message)
        {
            this.message = message;
        }
        
        public Messages(){}
    }
}