using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Furniture", order = 1)]
public class Furniture : ScriptableObject
{
    public string furnitureName;
    public Sprite sprite;
    public GameObject model;
}
