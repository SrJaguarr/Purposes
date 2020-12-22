using UnityEngine;

[CreateAssetMenu(menuName = "ColorDB")]
public class ColorDatabase : ScriptableObject
{
    public ColorData[] colors;
}

[System.Serializable]
public class ColorData
{
    public int id;
    public Sprite sprite;
    public Sprite bigBG;
    public Sprite litBG;
}
