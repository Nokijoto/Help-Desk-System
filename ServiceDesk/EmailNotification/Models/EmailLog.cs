namespace EmailNotification.Models
{
    namespace EmailNotification.Models
    {
        public class EmailLog
        {
            public int Id { get; set; }
            public string EmailTo { get; set; }
            public string Subject { get; set; }
            public string Body { get; set; }
            public DateTime SentAt { get; set; }
            public bool Success { get; set; }
            public string ErrorMessage { get; set; }
        }
    }
}
