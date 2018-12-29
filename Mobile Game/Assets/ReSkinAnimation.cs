using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSkinAnimation : MonoBehaviour
{

    public string spriteSheetName;

    public int indexia;
   

    private void LateUpdate()
    {
      
        var subSprites = Resources.LoadAll<Sprite>("Characters/" + spriteSheetName + indexia);

        foreach (var renderer in GetComponentsInChildren<SpriteRenderer>())
        {
            string spriteName = renderer.sprite.name;
            var newSprite = Array.Find(subSprites, item => item.name == spriteName);

            if (newSprite)
            {
                renderer.sprite = newSprite;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
