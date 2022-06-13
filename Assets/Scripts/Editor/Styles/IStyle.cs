using UnityEngine;

namespace Snake.Editor
{
    public interface IStyle
    {
        IStyle WithColor(Color color);
        IStyle WithFontStyle(FontStyle fontStyle);
        IStyle WithSize(int size);
        GUIStyle End();
    }
}
