using UnityEngine;

[CreateAssetMenu(menuName = "IconDB")]
public class IconDatabase : ScriptableObject
{
    public IconData[] icons;
}

[System.Serializable]
public class IconData
{
    public int id;
    public Sprite sprite;
}
