using System.ComponentModel.DataAnnotations;

namespace Cocoa.Web.Entities
{
    public record MessageDto
    {
        public string Name { get; init; } = string.Empty;

        public string Email { get; init; } = string.Empty;

        public string Phone { get; init; } = string.Empty;

        public string Content { get; init; } = string.Empty;
    }
}