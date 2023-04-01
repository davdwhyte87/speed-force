using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUpScObject", menuName = "PowerUps")]
public class PowerUpScObject : ScriptableObject
{

    public string Name;
    public string Description;
    public int Price;
    public GameObject Object;
    public Sprite Artwork;
}
