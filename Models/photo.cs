using System;

namespace backend.Models
{
    public class photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        public User user { get; set; }
        public long UserId { get; set; }

    }
}