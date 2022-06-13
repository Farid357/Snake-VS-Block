using UnityEngine;

namespace Snake.Editor
{
    public sealed class EditorStylesCreator : IStyle
    {
        private GUIStyle _style;

        public IStyle Create()
        {
            _style = new();
            return this;
        }

        public GUIStyle End() => _style;

        public IStyle WithColor(Color color)
        {
            _style.normal.textColor = color;
            return this;
        }

        public IStyle WithFontStyle(FontStyle fontStyle)
        {
            _style.fontStyle = fontStyle;
            return this;
        }

        public IStyle WithSize(int size)
        {
            _style.fontSize = size;
            return this;
        }
    }
}
