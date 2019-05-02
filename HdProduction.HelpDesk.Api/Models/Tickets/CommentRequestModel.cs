namespace HdProduction.HelpDesk.Api.Models.Tickets
{
    public class CommentRequestModel
    {
        public long TicketId { get; set; }
        public string Text { get; set; }
        public long UserId { get; set; }
        public long? ReplyToCommentId { get; set; }
    }
}