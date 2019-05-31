namespace HdProduction.HelpDesk.Domain.Entities
{
  public enum ActionType
  {
    None, 
    AddedComment, EditedComment, RemovedComment,
    AssigneeChanged, 
    AddedAttachment, RemovedAttachment
  }
}