using UnityEditor;
using UnityEngine;
using System.Collections;

namespace Altamir.ItemSystem.Editor
{
    public partial class ISQualityDatabaseEditor : EditorWindow
    {
        const int SPRITE_BUTTON_SIZE = 62;

        const string DATABASE_NAME = @"altQualityDatabase.asset";
        const string DATABASE_PATH = @"Database";
        const string DATABASE_FULL_PATH = @"Assets/" + DATABASE_PATH + "/" + DATABASE_NAME;

        ISQualityDatabase qualityDatabase;
        ISQuality selectedItem;
        Texture2D selectedTexture;
        Vector2 _scrollPosi;

        int selectedIndex = -1;

        [MenuItem("AL-IS/Database/Quality Editor %#i")]
        public static void Init()
        {
            ISQualityDatabaseEditor windows = EditorWindow.GetWindow<ISQualityDatabaseEditor>();
            windows.minSize = new Vector2(400, 300);
            windows.titleContent.text = "Quality Database";
            windows.Show();
        }


        void OnEnable()
        {
            qualityDatabase = ScriptableObject.CreateInstance<ISQualityDatabase>();
            qualityDatabase = qualityDatabase.GetDatabase<ISQualityDatabase>(DATABASE_PATH, DATABASE_NAME); 
        }

        void OnGUI()
        {
            if (qualityDatabase == null)
            {
                Debug.LogWarning("Quality databese not loader!");
                return;
            }

            ListView();

            EditorGUILayout.BeginHorizontal("BOX", GUILayout.ExpandWidth(true));
            ButtonBar();
            EditorGUILayout.EndHorizontal();
        }

        void ButtonBar()
        {
            EditorGUILayout.LabelField("Qualitis: " + qualityDatabase.Count);
            if (GUILayout.Button("Add"))
            {
                qualityDatabase.Add(new ISQuality());
            }
        }

    }
    
}