using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MainMenuManager : MonoBehaviour {


    public GameObject levelButtonPrefab;
    public GameObject levelButtoncontainer;

    private Transform cameraTransform;
    private Transform cameraDesiredLookAt;
        

    // Use this for initialization
    void Start()
    {
        cameraTransform = Camera.main.transform;

        Sprite[] thumbnails = Resources.LoadAll<Sprite>("Levels");
        foreach (Sprite thumbnail in thumbnails)
        {
            GameObject container = Instantiate(levelButtonPrefab) as GameObject;
            container.GetComponent<Image>().sprite = thumbnail;
            container.transform.SetParent(levelButtoncontainer.transform, false);

            string sceneName = thumbnail.name;
            container.GetComponent<Button>().onClick.AddListener (() => LoadLevel(sceneName));
        }
    }


    // Update is called once per frame
    private void Update()
    {
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
    /*
    public void LookAtLevelSelectMenu ()
    {
        //float speed = 20f;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Camera.main.transform.Translate(menuTransform.position);
        //Camera.main.transform.LookAt(menuTransform.position); 
        Camera.main.transform.Translate(2500, 0, 0);
       // Camera.main.transform.position = Vector2.MoveTowards(Camera.main.transform.position, menuTransform.position,
       //     speed * Time.deltaTime);
      //  Camera.main.transform.right = menuTransform.position - Camera.main.transform.position;
    }

    public void LookAtShop()
    {
        Camera.main.transform.Translate(-2500, 0, 0);
    }

    public void LookAtMainMenuFromLevelSelect()
    {
        Camera.main.transform.Translate(-2500, 0, 0);
    }

    public void LookAtMainMenuFromShop()
    {
        Camera.main.transform.Translate(2500, 0, 0);
    }
    */
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
