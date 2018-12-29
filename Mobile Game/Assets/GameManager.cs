using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public int currentSkinIndex = 1;
    public int currency = 0;
    public int skinAvailability = 2;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);

        if(PlayerPrefs.HasKey("CurrentSkin"))
        {
            // We had a previous session
            currentSkinIndex = PlayerPrefs.GetInt("CurrentSkin");
            currency = PlayerPrefs.GetInt("Currency");
            skinAvailability = PlayerPrefs.GetInt("SkinAvailability");
        }
        else
        {
            PlayerPrefs.SetInt("CurrentSkin", currentSkinIndex);
            PlayerPrefs.SetInt("Currency", currency);
            PlayerPrefs.SetInt("SkinAvailability", 2);
        }
    }

    private void Save()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
