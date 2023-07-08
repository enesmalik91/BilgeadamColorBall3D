using System;
using UnityEngine;

public class PlayerClamp : MonoBehaviour
{
    public PlayerController playerController;
    public float xClamp;
    
    public float zBackOffset;
    public float zForwardOffset;

    private Vector3 playerPosition;

    private void Update()
    {
        ClampPosition();
        
        MoveZPos();
    }

    private void ClampPosition()
    {
        playerPosition = transform.position;
        
        playerPosition.x = Mathf.Clamp(transform.position.x, -xClamp, xClamp);
        playerPosition.z = Mathf.Clamp(transform.position.z, zBackOffset, zForwardOffset);

        transform.position = playerPosition;
    }

    private void MoveZPos()
    {
        if(playerController.isFinish) return;
        
        zBackOffset += playerController.forwardSpeed * Time.deltaTime;
        zForwardOffset += playerController.forwardSpeed * Time.deltaTime;
    }
}