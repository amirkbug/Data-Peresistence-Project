using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    
    public static GameManager Instance;


    private void Awake()
    {


        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }


        Instance = this; 
        DontDestroyOnLoad(gameObject);
    }


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }


    public void PlayerNameStore()
    {
        
    }


    
}
