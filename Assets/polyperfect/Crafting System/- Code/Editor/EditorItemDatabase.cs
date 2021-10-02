using PolyPerfect.Crafting.Framework;
using PolyPerfect.Crafting.Integration;

namespace PolyPerfect.Common.Edit
{
    /// <summary>
    ///     Easy lookup of items from Object sources
    /// </summary>
    public static class EditorItemDatabase
    {
        static EditorItemDatabase()
        {
            var dataLookup = new SpecifiedDataAccessorLookup<RuntimeID>();

            dataLookup.SetAccessor(() => new EditorItemNameAccessor());
            dataLookup.SetAccessor(() => new EditorItemIconAccessor());

            Data = dataLookup;
        }

        public static IReadOnlyDataAccessorLookup<RuntimeID> Data { get; }
    }
}