using System;
using System.IO;
using System.Linq;
using PolyPerfect.Common;
using UnityEditor;
using UnityEngine;

namespace PolyPerfect.Crafting.Integration
{
    [CreateAssetMenu]
    public class PathLocatorObject : PolyObject
    {
        public override string __Usage =>
            $"Used to avoid hard-coding paths through the Asset Database. Scripts will look it up by name using {nameof(PathLocatorObject)}.FindDirectory().";

#if UNITY_EDITOR
        public static string FindDirectory(string locatorName)
        {
            try
            {
                var locators = AssetDatabase.FindAssets($"t:{nameof(PathLocatorObject)}");
                return Path.GetDirectoryName(locators.Select(AssetDatabase.GUIDToAssetPath).Single(p => Path.GetFileNameWithoutExtension(p) == locatorName));
            }
            catch (Exception e)
            {
                throw new Exception($"Error while looking for {nameof(PathLocatorObject)} titled {locatorName} in assets.\nDetails:\n{e}");
            }
        }
#endif
    }
}