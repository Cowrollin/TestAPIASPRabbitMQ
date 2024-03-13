using System.ComponentModel.DataAnnotations;

namespace TestAPIaWEBaASP.Data
{
    public class MessageDB
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }

        public string Message { get; set; }
    }
}
