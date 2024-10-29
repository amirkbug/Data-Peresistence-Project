using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    
    public static GameManager Instance;
    public TMP_InputField usernameInputField;
    public string username;
    public TextMeshProUGUI title;

    public bool textChange = false;
    public bool textShowed = false;
    public int hightScoreLoaded;




    private void Awake()
    {
        

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }


        Instance = this; 
        DontDestroyOnLoad(gameObject);


        
        
        //load data on awake and set the title to score and name
        LoadData();
        title.text =   username+ " : " + hightScoreLoaded; 
        usernameInputField.text = username;

    }



    public void StartGame()
    {
        
        username = usernameInputField.text;

        SceneManager.LoadScene(1);
        
    }


    [System.Serializable]
    class SaveData
    {
        public string username;
        public int highScore;
        
    }

    public void SaveAllData(int highScoreFromMain)
    {
        SaveData data = new SaveData();
        data.username = username;
        data.highScore = highScoreFromMain;
        
        string json = JsonUtility.ToJson(data);
        Debug.Log(json);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            username = data.username;
            hightScoreLoaded = data.highScore;
            

        }
    }

    public void OnChangeText()
    {
        if(usernameInputField.text != username)
        {
            textChange = true;
            
        }
        else
        {
            textChange = false;
            
        }
    }



}
