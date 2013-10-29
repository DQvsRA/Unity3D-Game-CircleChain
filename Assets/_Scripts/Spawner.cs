using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject greenCirclePrefab;
    public int maxCircle = 10;
    public int count = 0;

	// Use this for initialization
	void Start () {
        while (count < maxCircle)
        {
            Instantiate(greenCirclePrefab, transform.position, transform.rotation);
            count++;
        }	
	}
}
