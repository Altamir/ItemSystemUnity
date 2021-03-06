﻿using UnityEditor;
using UnityEngine;
using System.Collections;
namespace Altamir.ItemSystem.Editor
{
    public partial class ISQualityDatabaseEditor 
    {
        

        void ListView()
        {
            _scrollPosi = EditorGUILayout.BeginScrollView(_scrollPosi, GUILayout.ExpandHeight(true));

            DisplayQualitys();

            EditorGUILayout.EndScrollView();
        }

        private void DisplayQualitys()
        {
            for (int cnt = 0; cnt < qualityDatabase.Count; cnt++)
            {
                if (qualityDatabase.Get(cnt).Icon)
                    selectedTexture = qualityDatabase.Get(cnt).Icon.texture;
                else
                   selectedTexture = null;
                
                if(GUILayout.Button(selectedTexture,
                                GUILayout.Width(SPRITE_BUTTON_SIZE),
                                GUILayout.Height(SPRITE_BUTTON_SIZE)))
                {
                    int controlerID = EditorGUIUtility.GetControlID(FocusType.Passive);
                    EditorGUIUtility.ShowObjectPicker<Sprite>(null, true, null, controlerID);
                    selectedIndex = cnt;
                }

                string commandName = Event.current.commandName;
                if (commandName == "ObjectSelectorUpdated")
                {
                    if(selectedIndex != -1)
                    {
                        qualityDatabase.Get(selectedIndex).Icon = (Sprite)EditorGUIUtility.GetObjectPickerObject();
                    }
                    Repaint();
                }
            

                qualityDatabase.Get(cnt).Name =  GUILayout.TextField(qualityDatabase.Get(cnt).Name);

                GUILayout.Button("X");
            }
        }
    }
}