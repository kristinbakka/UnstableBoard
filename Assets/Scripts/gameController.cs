using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public Rigidbody Player;
    //This is the object that determines whare the camera is focusing
    public Rigidbody CameraCenterObject;
    public GameObject GameBoard;
    
    // Set plane rotation
    private float SpeedX = 5;
    private float SpeedZ = 5;
    private float RotationX;
    private float RotationZ;

    
    void Start()
    {
        // Set plane rotation
        SpeedX = 5;
        SpeedZ = 5;
        RotationX = 0;
        RotationZ = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Set plane rotation
        RotationX = SpeedX * Input.GetAxis("Mouse X");
        RotationZ = SpeedZ * Input.GetAxis("Mouse Y");
        GameBoard.transform.Rotate(-RotationZ, 0, RotationX);

        if (Player.transform.position.y <= -50)
            Player.transform.position = new Vector3(0, 50, 0);
        
        
        // Set camera position
        var playerHeight = Player.transform.position.y;
        if (playerHeight == 10)
        {
            CameraCenterObject.transform.position = new Vector3(0, 0, 0);
            CameraCenterObject.velocity = Vector3.zero;
        }else if (playerHeight <= -10)
        {
            CameraCenterObject.velocity = Vector3.up * Player.velocity.y;
        }
    }
}
