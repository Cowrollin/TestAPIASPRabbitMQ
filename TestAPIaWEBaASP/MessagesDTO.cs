using Microsoft.Extensions.Primitives;
using static System.Net.Mime.MediaTypeNames;

namespace TestAPIaWEBaASP
{
    public class MessagesDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        public string Message { get; set; }
    }
}
