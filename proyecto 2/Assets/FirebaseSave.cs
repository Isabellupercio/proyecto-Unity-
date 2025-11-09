using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;

public class FirebaseSave : MonoBehaviour
{
    DatabaseReference dbRef;

    void Start()
    {
        dbRef = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void SavePlayerProgress(string playerId, int coins, int level1, int level2)
    {
        PlayerData data = new PlayerData(coins, level1, level2);
        string json = JsonUtility.ToJson(data);

        dbRef.Child("players").Child(playerId).SetRawJsonValueAsync(json).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
                Debug.Log("✅ Datos guardados en Firebase.");
            else
                Debug.LogError("❌ Error al guardar los datos.");
        });
    }
}

[System.Serializable]
public class PlayerData
{
    public int coins;
    public int level1Progress;
    public int level2Progress;

    public PlayerData(int c, int l1, int l2)
    {
        coins = c;
        level1Progress = l1;
        level2Progress = l2;
    }
}
