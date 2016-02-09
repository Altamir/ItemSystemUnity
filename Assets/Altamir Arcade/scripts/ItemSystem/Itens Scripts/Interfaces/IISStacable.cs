using UnityEngine;
using System.Collections;


namespace Altamir.ItemSystem
{
    public interface IIStacable
    {
        int MaxStack { get; }
        void Stack(int amount);
    }
}