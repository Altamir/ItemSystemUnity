using UnityEngine;
using System.Collections;

public interface IISObject
{
    string ISName { get; set; }
    int ISValue { get; set; }
    Sprite ISIcon { get; set; }
	int ISBurden { get; set; }
    ISQuality ISQuality { get; set; }
}
