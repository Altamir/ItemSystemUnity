using UnityEngine;
using System.Collections;

namespace Altamir.ItemSystem
{
    public interface IISEquipmentSlot
    {
        string Name { get; set; }
        Sprite Icon { get; set; }
    }
}