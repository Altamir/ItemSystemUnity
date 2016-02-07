using UnityEditor;
using UnityEngine;
using System.Collections;

namespace Altamir.ItemSystem.Editor
{
    public class ISQualityDatabaseEditor : EditorWindow
    {
        const string DATABASE_FILE_NAME = @"altQualityDatabase.asset";
        const string DATABASE_FOLDER_NAME = @"Database";
        const string DATABASE_FULL_PATH = @"Assets/" + DATABASE_FOLDER_NAME + "/" + DATABASE_FILE_NAME;

        ISQualityDatabase db;

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
            db = AssetDatabase.LoadAssetAtPath(DATABASE_FULL_PATH, typeof(ISQualityDatabase)) as ISQualityDatabase;

            if (db == null)
            {
                if (!AssetDatabase.IsValidFolder("Assets/" + DATABASE_FOLDER_NAME))
                {
                    AssetDatabase.CreateFolder("Assets", DATABASE_FOLDER_NAME);
                }
                db = ScriptableObject.CreateInstance<ISQualityDatabase>();
                AssetDatabase.CreateAsset(db, DATABASE_FULL_PATH);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
        }
    }
}