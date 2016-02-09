using UnityEditor;
using UnityEngine;
using System.Collections;

namespace Altamir.ItemSystem.Editor
{
    public class ISQualityDatabaseEditor : EditorWindow
    {
        const int SPRITE_BUTTON_SIZE = 92;
        const string DATABASE_FILE_NAME = @"altQualityDatabase.asset";
        const string DATABASE_FOLDER_NAME = @"Database";
        const string DATABASE_FULL_PATH = @"Assets/" + DATABASE_FOLDER_NAME + "/" + DATABASE_FILE_NAME;

        ISQualityDatabase qualityDatabase;
        ISQuality selectedItem;
        Texture2D selectedTexture;

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
            qualityDatabase = AssetDatabase.LoadAssetAtPath(DATABASE_FULL_PATH, typeof(ISQualityDatabase)) as ISQualityDatabase;

            if (qualityDatabase == null)
            {
                if (!AssetDatabase.IsValidFolder("Assets/" + DATABASE_FOLDER_NAME))
                {
                    AssetDatabase.CreateFolder("Assets/", DATABASE_FOLDER_NAME);
                }
                qualityDatabase = ScriptableObject.CreateInstance<ISQualityDatabase>();
                AssetDatabase.CreateAsset(qualityDatabase, DATABASE_FULL_PATH);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }

            selectedItem = new ISQuality();
        }

        void OnGUI()
        {
            AddQualityToDB();
        }
        
        private void AddQualityToDB()
        {
            selectedItem.Name = EditorGUILayout.TextField("Name: ", selectedItem.Name);

            if (selectedItem.Icon)
            {
                selectedTexture = selectedItem.Icon.texture;
            }

            if(GUILayout.Button(selectedTexture, 
                                GUILayout.Width(SPRITE_BUTTON_SIZE),
                                GUILayout.Height(SPRITE_BUTTON_SIZE)))
            {
                int controlerID = EditorGUIUtility.GetControlID(FocusType.Passive);
                EditorGUIUtility.ShowObjectPicker<Sprite>(null, true, null, controlerID);
            }

            string commandName = Event.current.commandName;
            if(commandName == "ObjectSelectorUpdated")
            {
                selectedItem.Icon = (Sprite) EditorGUIUtility.GetObjectPickerObject();
                Repaint();
            }

            if (GUILayout.Button("Save"))
            {
                if (selectedItem == null)
                    return;
                qualityDatabase.database.Add(selectedItem);
                selectedItem = new ISQuality();
            }

        }
    }
    
}