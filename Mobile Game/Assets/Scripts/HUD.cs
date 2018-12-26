using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HUD : MonoBehaviour
{
    public Sprite[] HeartSprites;

    public Image HeartUI;

    private PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();    
    }

    // Update is called once per frame
    void Update()
    {
        HeartUI.sprite = HeartSprites[player.currentHealth];
    }
}
