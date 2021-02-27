using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Quaternion = System.Numerics.Quaternion;

public class SetRotationOfPlane : MonoBehaviour
{
    public GameObject GameBoard;
    // set rotation component here, and make it somewhat.
    private float SpeedX = 5;
    private float SpeedZ = 5;
    private float RotationX;
    private float RotationZ;
    public GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        SpeedX = 5;
        SpeedZ = 5;
        RotationX = 0;
        RotationZ = 0;
    }

    // Update is called once per frame
    void Update()
    {
        RotationX = SpeedX * Input.GetAxis("Mouse X");
        RotationZ = SpeedZ * Input.GetAxis("Mouse Y");
        GameBoard.transform.Rotate(-RotationZ, 0, RotationX);

        if (Player.transform.position.y <= -50)
            Player.transform.position = new Vector3(0, 50, 0);
    }
}
