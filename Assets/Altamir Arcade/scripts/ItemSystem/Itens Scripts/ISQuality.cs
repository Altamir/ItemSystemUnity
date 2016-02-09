using UnityEngine;
using System.Collections;
using System;


namespace Altamir.ItemSystem
{
    [System.Serializable]
    public class ISQuality : IISQuality
    {
        [SerializeField]
        string _name;
        [SerializeField]
        Sprite _icon;

        public ISQuality()
        {
            this._name = "Common";
            this._icon = new Sprite();
        }
        public Sprite Icon
        {
            get { return this._icon; }
            set { this._icon = value; }
        }

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
    }
}