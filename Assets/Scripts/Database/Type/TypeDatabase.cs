using UnityEngine;

[CreateAssetMenu(menuName = "TypeDB")]
public class TypeDatabase : ScriptableObject
{
    public TypeData[] types;
}

[System.Serializable]
public class TypeData
{
    public int id;
    public string adjetivo;
    public string singular;
    public string plural;
    public int defaultRepetitions;
    public int defaultNumberOf;
    public int maxRepetitions;
    public int maxNumberOf;
    public int maxRepetitionsCaracter;
    public int maxNumberOfCaracter;
}
