using Miro.Lite.Api.Dto;
using Miro.Lite.Api.Entities;

namespace Miro.Lite.Api.Mapping;

public static class UserStoryMapping
{
    public static UserStory ToEntity (this UserStoryDto dto)
    {
        return new()
        {
            Id = dto.Id,
            Title = dto.Title,
            Description = dto.Description,
            Priority = dto.Priority
        };
    }

    public static UserStoryDto ToDto (this UserStory entity)
    {
        return new (entity.Id, entity.Title, entity.Description, entity.Priority);
    }
}
