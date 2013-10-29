using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    // objects pooling: http://channel9.msdn.com/Events/Windows-Camp/Building-Windows-Games-with-Unity/Deep-dive-Tips-tricks-for-porting-games-from-other-platforms-to-Windows-8
    // bullet 
    public float redBulletXSpeed;
    public float redBulletYSpeed;

    // for 2d position calc
    public Camera cam;
    public float screenX; // = Camera.current.ScreenToWorldPoint( new Vector3 (Screen.width, 0, 0)).x;
    public float screenY; // = Camera.current.ScreenToWorldPoint( new Vector3 (0, Screen.height, 0)).y;
    
	// Use this for initialization
	void Start () {
        cam = Camera.main.GetComponent<Camera>(); // get the Main Camera instance
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate( new Vector3( redBulletXSpeed, redBulletYSpeed, 0 ) * Time.deltaTime );
        //transform.Translate( new Vector3(0f, ySpeed*Time.deltaTime, 0f) );
        // get screen limits
        getCurrentMaxWorldScreen();
        // destroy bullets if off screen
        deleteOffScreenObject();
	}

    public void getCurrentMaxWorldScreen()
    {
        screenX = cam.ScreenToWorldPoint( new Vector3( Screen.width, 0, 0 ) ).x;//Camera.current.ScreenToWorldPoint( new Vector3 (Screen.width, 0, 0)).x;
        screenY = cam.ScreenToWorldPoint( new Vector3( 0, Screen.height, 0 ) ).y;
    }

    public void deleteOffScreenObject()
    {
        // if the GreenCircle goes out the screen we manage to put it back
        if ( transform.position.x > ( screenX ) )
        {
            Destroy( this.gameObject );
        }
        if ( transform.position.x < -screenX )
        {
            Destroy( this.gameObject );
        }
        if ( transform.position.y > screenY )
        {
            Destroy( this.gameObject );
        }
        if ( transform.position.y < -screenY )
        {
            Destroy( this.gameObject );
        }
    }

    public void setBulletXSpeed(float speedX)
    {
        redBulletXSpeed = speedX;
    }

    public void setBulletYSpeed(float speedY)
    {
        redBulletYSpeed = speedY;
    }
}
