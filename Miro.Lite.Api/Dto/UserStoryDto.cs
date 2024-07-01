using Miro.Lite.Api.Enums;

namespace Miro.Lite.Api.Dto;

public record UserStoryDto(int Id, string Title, string? Description, UserStoryPriority Priority);

