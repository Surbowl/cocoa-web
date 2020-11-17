namespace Cocoa.Web.Models
{
    public record MessageModel
    {
        public string Name { get; init; } = string.Empty;

        public string Email { get; init; } = string.Empty;

        public string Content { get; init; } = string.Empty;
    }
}
