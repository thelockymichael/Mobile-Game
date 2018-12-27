using UnityEngine;
using System.Collections;

public class MoveSample : MonoBehaviour
{	
	void Start(){
		iTween.MoveBy(gameObject, iTween.Hash("y", 20, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
	}
}

