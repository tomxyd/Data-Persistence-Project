using System.IO;
using UnityEngine;

public class ReadInput : MonoBehaviour
{
    public static ReadInput Instance { get; private set; }



    private void Awake()
    {
        LoadData();

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public string playerName;
    public string highScorePlayer;
    public int highScore;
    public void ReadStringInput(string s)
    {
        playerName = s;
    }
    [System.Serializable]
    public class HighScoreData
    {
        public string name;
        public int score;
    }

    public void SaveData()
    {
        HighScoreData data = new HighScoreData();
        data.name = highScorePlayer;
        data.score = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScoreData data = JsonUtility.FromJson<HighScoreData>(json);
            highScorePlayer = data.name;
            highScore = data.score;
        }
    }

}
