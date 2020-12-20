using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{

    public static void SaveProgress(AchievementManager achievementManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/savedata.dyc";
        FileStream stream = new FileStream(path, FileMode.Create);

        AchievementData data = new AchievementData(achievementManager);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static AchievementData LoadAchievements()
    {
        string path = Application.persistentDataPath + "/savedata.dyc";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            if(stream.Length > 0)
            {
                AchievementData data = formatter.Deserialize(stream) as AchievementData;
                stream.Close();
                return data;
            }
            else
            {
                return null;
            }

        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void SaveUserData(ProfileManager profileManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/userdata.dyc";
        FileStream stream = new FileStream(path, FileMode.Create);

        ProfileData data = new ProfileData(profileManager);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ProfileData LoadUserdata()
    {
        string path = Application.persistentDataPath + "/userdata.dyc";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            if (stream.Length > 0)
            {
                ProfileData data = formatter.Deserialize(stream) as ProfileData;
                stream.Close();
                return data;
            }
            else
            {
                return null;
            }

        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }


}
