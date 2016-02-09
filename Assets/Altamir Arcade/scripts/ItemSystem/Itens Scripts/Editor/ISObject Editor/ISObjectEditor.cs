using UnityEngine;
using System.Collections;
using UnityEditor;


namespace Altamir.ItemSystem.Editor
{
    public partial class ISObjectEditor : EditorWindow
    {

        [MenuItem("AL-IS/Database/Item System Editor %#w")]
        public static void Init()
        {
            ISObjectEditor windows = EditorWindow.GetWindow<ISObjectEditor>();
            windows.minSize = new Vector2(800, 600);
            windows.titleContent.text = "Item System";
            windows.Show();
        }

        void OnEnable()
        {
            
        }

        void OnGUI()
        {
            TopTabBar();
        }
    }
}