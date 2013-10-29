using UnityEngine;
using System.Collections;

public class RedCircle : MonoBehaviour {

    // for mouse controller
    public float mousePos;

    // for 2d position calc
    private Camera cam;

    // prefab to be instantieated
    public GameObject redBulletPrefab;
    public float redBulletXSpeed = 1;
    public float redBulletYSpeed = 1;
    public float bulletSpeed = 5;

	// Use this for initialization
	void Start () {
        cam = Camera.main.GetComponent<Camera>(); // get the Main Camera instance
	}
	
	// Update is called once per frame
	void Update () {
        attachObjectToMouse();
        if ( Input.GetMouseButtonDown( 0 ) )
        {
            // 4 directions 
            for ( int i = 0; i < 4; i++ )
            {
                // calc the direction of the bullet
                redBulletXSpeed = bulletSpeed * Mathf.Cos( i * Mathf.PI / 2 ); //redBullet.xSpeed=bulletSpeed*Math.cos(i*Math.PI/2);
                redBulletYSpeed = bulletSpeed * Mathf.Sin( i * Mathf.PI / 2 ); //redBullet.ySpeed=bulletSpeed*Math.sin(i*Math.PI/2);
                // create a instance of bullet
                GameObject clone = Instantiate( redBulletPrefab, transform.position, transform.rotation ) as GameObject;
                clone.SendMessage( "setBulletXSpeed", redBulletXSpeed );
                clone.SendMessage( "setBulletYSpeed", redBulletYSpeed );
            }
        }
	}

    private void attachObjectToMouse()
    {
        Vector3 screenPos = Input.mousePosition;
        // need convert 2d position (from mouse) to 3d world position
        Vector3 worldPos = new Vector3( cam.ScreenToWorldPoint( screenPos ).x, cam.ScreenToWorldPoint( screenPos ).y, 0 );
        // set the red circle object position
        gameObject.transform.position = worldPos;
    }
}
