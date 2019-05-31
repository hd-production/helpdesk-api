namespace HdProduction.HelpDesk.Api.Models.Comments
{
    public class CommentRequest
    {
        public string Text { get; set; }
        public long? ReplyToCommentId { get; set; }
    }
}