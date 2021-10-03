using System;

namespace PolyPerfect.Crafting.Integration
{
    public class CreateMenuTitleAttribute : Attribute
    {
        public CreateMenuTitleAttribute(string title)
        {
            Title = title;
        }

        public string Title { get; }
    }
}