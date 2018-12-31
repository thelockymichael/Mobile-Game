using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private int sceneID;
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public int currentSkinIndex = 0;
    public int currency = 0;
    public int skinAvailability = 0;



    // Start is called before the first frame update
   private void Awake()
    {
       
        instance = this;
        DontDestroyOnLoad(gameObject);

        //ReSkinAnimation player = GameObject.Find("Player").GetComponent<ReSkinAnimation>();


        if (PlayerPrefs.HasKey("CurrentSkin"))
        {
            // We had a previous session
            currentSkinIndex = PlayerPrefs.GetInt("CurrentSkin");
            currency = PlayerPrefs.GetInt("Currency");
            skinAvailability = PlayerPrefs.GetInt("SkinAvailability");
        }
        else
        {
            Save();
        }
    }
    public void Save()
    {
        
        PlayerPrefs.SetInt("CurrentSkin", currentSkinIndex);
        PlayerPrefs.SetInt("Currency", currency);
        PlayerPrefs.SetInt("SkinAvailability", skinAvailability);
    }

    // Update is called once per frame
    void Update()

    {
        sceneID = SceneManager.GetActiveScene().buildIndex;

        Debug.Log("Scene id is " + sceneID);

        if (sceneID > 0)
        {

            ReSkinAnimation player = GameObject.Find("/Player").GetComponent<ReSkinAnimation>();

            player.indexia = currentSkinIndex;

            Debug.Log(player);
        }
 



    }
}
