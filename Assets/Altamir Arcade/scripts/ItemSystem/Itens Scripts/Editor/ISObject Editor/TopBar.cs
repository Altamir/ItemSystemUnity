using UnityEngine;
using System.Collections;
using UnityEditor;

namespace Altamir.ItemSystem.Editor
{
    public partial class ISObjectEditor : EditorWindow
    {
        void TopTabBar()
        {
            GUILayout.BeginHorizontal("BOX", GUILayout.ExpandWidth(true));

            GUILayout.Button("Weapons");
            GUILayout.Button("Armor");
            GUILayout.Button("Potions");
            GUILayout.Button("About");

            GUILayout.EndHorizontal();
        }
    }
}