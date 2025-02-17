using Trackify.Models;
using Trackify.Models.DTOs;

namespace Trackify.Mappers;

public static class CategoryExtensions
{
    public static CategoryMenuItem ToCategoryMenuItem(this Category category)
    {
        return new CategoryMenuItem
        {
            Id = category.Id,
            Name = category.Name,
            Cards = category.Cards
        };
    }
}