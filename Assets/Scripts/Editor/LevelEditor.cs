using Snake.GameLogic;
using Snake.Model;
using Snake.Root;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Snake.Editor
{
    public sealed class LevelEditor : EditorWindow
    {
        private readonly EditorStylesCreator _creator = new();
        private BlockContext _blockContext;
        private SnakeRoot _root;
        private SnakeCircles _snakeCircles = new();
        private readonly List<IBlock> _blocks = new();
        private readonly List<IDisposable> _disposables = new();
        private Transform _parent;
        private BlockType _type;
        private int _health;
        private int _abilitySeconds;

        [MenuItem("Window/Level editor")]
        public static void Open()
        {
            var window = GetWindow<LevelEditor>();
            window.Show();
        }

        private void OnGUI()
        {
            EditorGUILayout.Space(10);
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.Space(50);
            var labelStyle = _creator.Create().WithColor(Color.red).WithFontStyle(FontStyle.Bold).WithSize(24).End();
            EditorGUILayout.LabelField("Level Editor", labelStyle);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginVertical();
            var textStyle = _creator.Create().WithColor(Color.blue).WithSize(18).End();

            EditorGUILayout.LabelField("Parent", textStyle);
            EditorGUILayout.Space(10);
            _parent = (Transform)EditorGUILayout.ObjectField(_parent, typeof(Transform), true);
            EditorGUILayout.Space(10);

            EditorGUILayout.LabelField("Snake Root", textStyle);
            EditorGUILayout.Space(10);
            _root = (SnakeRoot)EditorGUILayout.ObjectField(_root, typeof(SnakeRoot), true);
            EditorGUILayout.Space(20);

            EditorGUILayout.LabelField("Block Prefab", textStyle);
            EditorGUILayout.Space(10);
            _blockContext = (BlockContext)EditorGUILayout.ObjectField(_blockContext, typeof(BlockContext), true);
            EditorGUILayout.Space(20);
            _type = (BlockType)EditorGUILayout.EnumPopup("Block Type", _type);
            EditorGUILayout.LabelField("Health", textStyle);
            EditorGUILayout.Space(20);
            _health = EditorGUILayout.IntField(_health);
            EditorGUILayout.LabelField("Ability Seconds", textStyle);
            EditorGUILayout.Space(20);
            _abilitySeconds = EditorGUILayout.IntField(_abilitySeconds);
            EditorGUILayout.EndVertical();
            EditorGUILayout.Space(25);

            if (GUILayout.Button("Create Block"))
            {
                var provider = new BlockProvider(_snakeCircles);
                var context = Instantiate(_blockContext, _parent);
                var block = provider.GetBlock(_type, _health, _abilitySeconds);
                _blocks.Add(block);
                var presenter = new BlockPresenter(_snakeCircles, block, context);
                _disposables.Add(presenter);
                _root.Init(_snakeCircles);
                _root.DisposableDestroyer.SetDisposables(_disposables);
                SetDirty(_root, "Root");
                SetDirty((Object)_root.DisposableDestroyer, "DisposeRoot");
            }

            if (GUI.changed)
            {
                SetDirty(this, "Level Editor modify");
            }
        }

        
        private void SetDirty<T>(T recordObject, string modify) where T : Object
        {
            Undo.RecordObject(recordObject, modify);
            EditorUtility.SetDirty(recordObject);
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
    }
}
