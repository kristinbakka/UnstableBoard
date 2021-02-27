using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraPosition : MonoBehaviour
{
    public Rigidbody Player;
    //This is the object that determines whare the camera is focusing
    public Rigidbody CameraCenterObject;
    private bool FollowPlayerOn;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var playerHeight = Player.transform.position.y;
        if (playerHeight == 10)
        {
            CameraCenterObject.transform.position = new Vector3(0, 0, 0);
            CameraCenterObject.velocity = Vector3.zero;
        }
        
        if (playerHeight <= -10)
        {
            CameraCenterObject.velocity = Vector3.up * Player.velocity.y;
        }
            
        
    }
}
