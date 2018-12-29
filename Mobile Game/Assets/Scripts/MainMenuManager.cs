using System;
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

    private Transform cameraTransform;
    private Transform cameraDesiredLookAt;

    public GameObject Player;
   
    public ReSkinAnimation reskin;

   // public int index;

    // public string spriteSheetName; //=  "character";
    // public int index = 1;

    // Use this for initialization
    void Awake()
    {
        ChangePlayerSkin(GameManager.Instance.currentSkinIndex);

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

        int textureIndex = 1;
        Sprite[] textures = Resources.LoadAll<Sprite>("Player");
        foreach (Sprite texture in textures)
        {
            GameObject container = Instantiate(shopButtonPrefab) as GameObject;
            container.GetComponent<Image>().sprite = texture;
            container.transform.SetParent(shopButtonContainer.transform, false);

            int index = textureIndex;
            container.GetComponent<Button>().onClick.AddListener(() => ChangePlayerSkin(index));
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
        if (index == 1)
        {
            reskin.indexia = 1;
        }
        if (index == 2)
        {
            reskin.indexia = 2;
        }
        if(index == 3)
        {
            reskin.indexia = 3;
        }
        if (index == 4)
        {
            reskin.indexia = 4;
        }
        GameManager.Instance.currentSkinIndex = index;
        // ChangePlayerSkin(4);
    }
    /*
    private void ChangePlayerSkin(int index)
    {
        Debug.Log("Change player skin");

        var subSprites = Resources.LoadAll<Sprite>("Characters/" + spriteSheetName + index);

        foreach (var renderer in Player.GetComponentsInChildren<SpriteRenderer>())
        {
            string spriteName = renderer.sprite.name;
            var newSprite = Array.Find(subSprites, item => item.name == spriteName);

            if (newSprite)
            {
                renderer.sprite = newSprite;
            }
        }
     }*/
    /*
    private void LateUpdate()
    {
        var subSprites = Resources.LoadAll<Sprite>("Characters/" + spriteSheetName + index);

        foreach (var renderer in GetComponentsInChildren<SpriteRenderer>())
        {
            string spriteName = renderer.sprite.name;
            var newSprite = Array.Find(subSprites, item => item.name == spriteName);

            if (newSprite)
            {
                renderer.sprite = newSprite;
            }
        }
    }*/


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
