using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{
    float delayTime = 0.10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.currency += 1;
            GameManager.Instance.Save();
            Destroy(this.gameObject);
          //  StartCoroutine("delay");
 
          
        }
    }

    IEnumerator delay()
    {
       
        yield return new WaitForSeconds(delayTime);
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
