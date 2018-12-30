﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MainMenuManager : MonoBehaviour {

   // public GameObject player;
    //public GameObject[] playerSkins;

    public GameObject levelButtonPrefab;
    public GameObject levelButtonContainer;
    public GameObject shopButtonPrefab;
    public GameObject shopButtonContainer;
    public Text currencyText;

    private Transform cameraTransform;
    private Transform cameraDesiredLookAt;

    public GameObject Player;
   
    public ReSkinAnimation reskin;

   // public int index;

    // public string spriteSheetName; //=  "character";
    // public int index = 1;

    // Use this for initialization
    private void Start()
    {
        ChangePlayerSkin(GameManager.Instance.currentSkinIndex);
        currencyText.text = "Currency : " + GameManager.Instance.currency.ToString();
        //reskin.index = 4;
        // ChangePlayerSkin (GameManager.Instance.currentSkinIndex);
        cameraTransform = Camera.main.transform;

        Sprite[] thumbnails = Resources.LoadAll<Sprite>("Levels");
        foreach (Sprite thumbnail in thumbnails)
        {
            GameObject container = Instantiate(levelButtonPrefab) as GameObject;
            container.GetComponent<Image>().sprite = thumbnail;
            container.transform.SetParent(levelButtonContainer.transform, false);

            string sceneName = thumbnail.name;
            container.GetComponent<Button>().onClick.AddListener(() => LoadLevel(sceneName));
        }

        int textureIndex = 0;
        Sprite[] textures = Resources.LoadAll<Sprite>("Player");
        foreach (Sprite texture in textures)
        {
            GameObject container = Instantiate(shopButtonPrefab) as GameObject;
            container.GetComponent<Image>().sprite = texture;
            container.transform.SetParent(shopButtonContainer.transform, false);

            int index = textureIndex;
            container.GetComponent<Button>().onClick.AddListener(() => ChangePlayerSkin(index));

            if (index == 0 && GameManager.Instance.skinAvailability <= 3)
            {
                container.transform.GetChild(0).gameObject.SetActive(false);

            }

            if (index == 1 && GameManager.Instance.skinAvailability >= 1)
            {
                  container.transform.GetChild(0).gameObject.SetActive(false) ;

            }
            if (index == 2 && GameManager.Instance.skinAvailability >= 2)
            {
                container.transform.GetChild(0).gameObject.SetActive(false);

            }
            if (index == 3 && GameManager.Instance.skinAvailability >= 3)
            {
                container.transform.GetChild(0).gameObject.SetActive(false);

            }
            textureIndex++;
        }
    }


    // Update is called once per frame
    private void Update()
    {

        //Debug.Log(reskin.index);
        if (cameraDesiredLookAt != null)
        {
            cameraTransform.rotation = Quaternion.Slerp(cameraTransform.rotation, cameraDesiredLookAt.rotation, 3 * Time.deltaTime);
        }
    }

    private void LoadLevel(string sceneName)
    {
        Debug.Log(sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public void LookAtMenu (Transform menuTransform)
    {

        // Camera.main.transform.LookAt(menuTransform.position);
        cameraDesiredLookAt = menuTransform;
    }

    public void ChangePlayerSkin(int index)
    {
        int cost = 0;


        //  if ((GameManager.Instance.skinAvailability == 0))
        //   {
        if (index == 0 && GameManager.Instance.skinAvailability <=3)
        {
           // GameManager.Instance.currency -= cost;
            GameManager.Instance.Save();
            GameManager.Instance.currentSkinIndex = 0;
            Debug.Log(index);
            reskin.indexia = 0;
        }
        if (index == 1 && GameManager.Instance.skinAvailability == 0 && GameManager.Instance.currency >= cost)
            {
                GameManager.Instance.currency -= cost;
                GameManager.Instance.Save();
                GameManager.Instance.currentSkinIndex = 1;
                GameManager.Instance.skinAvailability += 1;
                Debug.Log(index);
                reskin.indexia = 1;
            }
        if (index == 2 && GameManager.Instance.skinAvailability == 1 && GameManager.Instance.currency >= cost)
        {
            GameManager.Instance.currency -= cost;
            GameManager.Instance.Save();
            GameManager.Instance.currentSkinIndex = 2;
            GameManager.Instance.skinAvailability += 1;
            Debug.Log(index);
            reskin.indexia = 2;
        }
        if (index == 3 && GameManager.Instance.skinAvailability == 2 && GameManager.Instance.currency >= cost)
        {
            GameManager.Instance.currency -= cost;
            GameManager.Instance.Save();
            GameManager.Instance.currentSkinIndex = 3;
            GameManager.Instance.skinAvailability += 1;
            Debug.Log(index);
            reskin.indexia = 3;
        }

        // Player skin 1!!!
        if (index == 1 && GameManager.Instance.skinAvailability == 1)
        {
            GameManager.Instance.currentSkinIndex = 1;

            GameManager.Instance.Save();
          //  GameManager.Instance.currentSkinIndex = 1;
       
            Debug.Log(index);
            reskin.indexia = 1;
        }
        if (index == 1 && GameManager.Instance.skinAvailability == 2)
        {
            GameManager.Instance.currentSkinIndex = 1;
            GameManager.Instance.Save();
          //  GameManager.Instance.currentSkinIndex = 1;

            Debug.Log(index);
            reskin.indexia = 1;
        }
        if (index == 1 && GameManager.Instance.skinAvailability == 3)
        {
            GameManager.Instance.currentSkinIndex = 1;
           // GameManager.Instance.skinAvailability -= ;
            GameManager.Instance.Save();
           // GameManager.Instance.currentSkinIndex = 1;

            Debug.Log(index);
            reskin.indexia = 1;
        }

        // Player skin 2!!
        if (index == 2 && GameManager.Instance.skinAvailability == 3 )
        {
            GameManager.Instance.currentSkinIndex = 2;

            GameManager.Instance.Save();
           // GameManager.Instance.currentSkinIndex = 2;
            Debug.Log(index);
            reskin.indexia = 2;
        }
        if (index == 2 && GameManager.Instance.skinAvailability == 2)
        {
            GameManager.Instance.currentSkinIndex = 2;
            GameManager.Instance.Save();
            // GameManager.Instance.currentSkinIndex = 2;
            Debug.Log(index);
            reskin.indexia = 2;
        }

        // Player skin 3!!

        if (index == 3 && GameManager.Instance.skinAvailability == 3)
        {
            GameManager.Instance.currentSkinIndex = 3;

            GameManager.Instance.Save();
            // GameManager.Instance.currentSkinIndex = 2;
            Debug.Log(index);
            reskin.indexia = 3;
        }
        /*
        int cost = 0;
        if ((GameManager.Instance.skinAvailability == 3))
        {
            if (index == 0 && GameManager.Instance.currency >= cost)
            {
                GameManager.Instance.currency -= cost;
                GameManager.Instance.Save();
                GameManager.Instance.currentSkinIndex = 0;

                Debug.Log(index);
                reskin.indexia = 0;
            }
            if (index == 1 && GameManager.Instance.currency >= cost)
            {
                GameManager.Instance.currency -= cost;
                GameManager.Instance.Save();
                GameManager.Instance.currentSkinIndex = 1;

                Debug.Log(index);

                reskin.indexia = 1;
            }
            if (index == 2 && GameManager.Instance.currency >= cost)
            {
                GameManager.Instance.currency -= cost;
                GameManager.Instance.Save();
                GameManager.Instance.currentSkinIndex = 2;

                Debug.Log(index);

                reskin.indexia = 2;
            }
            if (index == 3 && GameManager.Instance.currency >= cost)
            {
                GameManager.Instance.currency -= cost;
                GameManager.Instance.Save();
                GameManager.Instance.currentSkinIndex = 3;

                Debug.Log(index);

                reskin.indexia = 3;
            }
        }

        if ((GameManager.Instance.skinAvailability == 2))
        {
            if (index == 0 && GameManager.Instance.currency >= cost)
            {
                GameManager.Instance.currency -= cost;
                GameManager.Instance.Save();
                GameManager.Instance.currentSkinIndex = 0;

                Debug.Log(index);
                reskin.indexia = 0;
            }
            if (index == 1 && GameManager.Instance.currency >= cost)
            {
                GameManager.Instance.currency -= cost;
                GameManager.Instance.Save();
                GameManager.Instance.currentSkinIndex = 1;

                Debug.Log(index);

                reskin.indexia = 1;
            }
            if (index == 2 && GameManager.Instance.currency >= cost)
            {
                GameManager.Instance.currency -= cost;
                GameManager.Instance.Save();
                GameManager.Instance.currentSkinIndex = 2;

                Debug.Log(index);

                reskin.indexia = 2;
            }
        }

        if ((GameManager.Instance.skinAvailability == 1))
        {
            if (index == 0 && GameManager.Instance.currency >= cost)
            {
                GameManager.Instance.currency -= cost;
                GameManager.Instance.Save();
                GameManager.Instance.currentSkinIndex = 0;

                Debug.Log(index);
                reskin.indexia = 0;
            }
            if (index == 1 && GameManager.Instance.currency >= cost)
            {
                GameManager.Instance.currency -= cost;
                GameManager.Instance.Save();
                GameManager.Instance.currentSkinIndex = 1;

                Debug.Log(index);

                reskin.indexia = 1;
            }
        }

        if ((GameManager.Instance.skinAvailability == 0))
        {
            if (index == 0 && GameManager.Instance.currency >= cost)
            {
                GameManager.Instance.currency -= cost;
                GameManager.Instance.Save();
                GameManager.Instance.currentSkinIndex = 0;

                Debug.Log(index);
                reskin.indexia = 0;
            }
        }
        else
        {
            //You do not have the skin, do you want to buy it?
            int cost = 0;
            if (GameManager.Instance.currency >= cost)
            {
                GameManager.Instance.currency -= cost;
                GameManager.Instance.skinAvailability += 1 << index;
                GameManager.Instance.Save();

            }


        }*/



    }
    
    

  
    private void FixedUpdate()
    {
        
    }


    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

      //  SceneManager.LoadScene("level2");
    }

    public void levelToLoad()
    {
        SceneManager.LoadScene("level1");
    }

}
