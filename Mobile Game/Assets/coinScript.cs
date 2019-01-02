using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{
    float delayTime = 0.10f;


    public bool enter = true;
    public bool stay = true;
    public bool exit = true;

    public float restartDelay = 5f;         // Time to wait before restarting the level

    float restartTimer;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider2D other)
    {
        if (enter)
        {
            Debug.Log("entered");
        }
    }
    // stayCount allows the OnTriggerStay to be displayed less often
    // than it actually occurs.
    private float stayCount = 0.0f;
    /*
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
    */

    private void OnTriggerStay2D(Collider2D other)
    {
        /*
        if (other.gameObject.CompareTag("platform"))
        {
            transform.parent = other.transform;
        }*/
        if (stay && other.gameObject.CompareTag("Player"))
        {
            if (stayCount > 0.001f)
            {
                //  pivotJoint.enabled = !pivotJoint.enabled;
                //pivotJoint.gameObject.SetActive(false);
                GameManager.Instance.currency += 1;
                GameManager.Instance.Save();
                Destroy(this.gameObject);
                Debug.Log("staying");
                stayCount = stayCount - 0.001f;
            }
            else
            {
                restartTimer = restartTimer + Time.deltaTime;
                stayCount = stayCount + Time.deltaTime;
            }
        }
    }

    private void OnCollisionExit(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Player.transform.parent = null;
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
