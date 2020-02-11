using System.Reflection;
using System.Windows;

namespace LSystem.Themes
{
    public class ThemeResourceKey : ResourceKey
    {
        private readonly string _name;
        public ThemeResourceKey(string name)
        {
            _name = name;
        }
        public override Assembly Assembly => null;
    }

    public static class ResourceKeys
    {
        public static ResourceKey PanelBackgroundKey { get; } = new ThemeResourceKey(nameof(PanelBackgroundKey));
        public static ResourceKey PanelBorderBrushKey { get; } = new ThemeResourceKey(nameof(PanelBorderBrushKey));
        
        public static ResourceKey WindowBackgroundKey { get; } = new ThemeResourceKey(nameof(WindowBackgroundKey));
        public static ResourceKey WindowBorderBrushKey { get; } = new ThemeResourceKey(nameof(WindowBorderBrushKey));
    }
}
