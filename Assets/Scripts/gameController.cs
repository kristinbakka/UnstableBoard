using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    // This is the object that determines where the camera is focusing
    public Rigidbody Player;
    public Rigidbody CameraCenterObject;
    public GameObject GameBoard;
    public GameObject PlayerLight;
    
    // Set plane rotation
    private float MouseSpeedX;
    private float MouseSpeedZ;
    private float RotationX;
    private float RotationZ;

    //Game Controller
    private GamePhase _currentPhase;
    private int _currentLevel;
    
    enum GamePhase
    {
        levelInit,
        // All is in place for the level, just click to start.
        levelStart,
        gameplay,
        levelWon,
        animation,
        menu
    }

    void Start()
    {
        _currentPhase = GamePhase.levelStart;
        _currentLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentPhase == GamePhase.levelInit)
        {
            _currentLevel += 1;
            // Spawn Level
            if (_currentLevel == 2)
            {
                // Start new level.
            }
            return;
        }
        // End level animation 

        if (_currentPhase == GamePhase.levelStart)
        {
            if (!Input.GetMouseButtonDown(0))
                return;
            
            _currentPhase = GamePhase.gameplay;
            Player.transform.position = new Vector3(0, 10, 0);
            Player.velocity = new Vector3(0, 0, 0);
            PlayerLight.transform.position = new Vector3(0, 11, 0);
            // --Level stuff
            // Set plane rotation
            MouseSpeedX = 5;
            MouseSpeedZ = -5;
            RotationX = 0;
            RotationZ = 0;
            return;
        }

        if (_currentPhase == GamePhase.gameplay)
        {
            // Set plane rotation
            RotationX = MouseSpeedX * Input.GetAxis("Mouse X");
            RotationZ = MouseSpeedZ * Input.GetAxis("Mouse Y");
            GameBoard.transform.Rotate(RotationZ, 0, RotationX);

            if (Player.transform.position.y < -50)
                _currentPhase = GamePhase.levelWon;
        }

        if (_currentPhase == GamePhase.levelWon)
        {
            // Score up
            // Start animation, next level, or init
            
            // this time
            _currentPhase = GamePhase.levelInit;
        }

        if (_currentPhase == GamePhase.animation)
        {
           //CameraCenterObject.transform.position = Vector3.MoveTowards(0, 0, 0);
        }
        
        // Start new
        
        //if (Player.transform.position.y <= -50)
        //    Player.transform.position = new Vector3(0, 50, 0);
        //
        //
        //
//
        //// Set camera position
        //var playerHeight = Player.transform.position.y;
        //if (playerHeight == 10)
        //{
        //    CameraCenterObject.transform.position = new Vector3(0, 0, 0);
        //    CameraCenterObject.velocity = Vector3.zero;
        //}else if (playerHeight <= -10)
        //{
        //    CameraCenterObject.velocity = Vector3.up * Player.velocity.y;
        //}
    }

}
