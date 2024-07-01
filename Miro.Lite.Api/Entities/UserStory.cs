using Miro.Lite.Api.Enums;

namespace Miro.Lite.Api.Entities
{
    public class UserStory
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public UserStoryPriority Priority { get; set; }

    }
}
