using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float capsuleSpeed = 5f;
    private Vector3 playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        float XAxis = Input.GetAxis("Horizontal");
        playerMovement.x += capsuleSpeed * Time.deltaTime * XAxis;
        float ZAxis = Input.GetAxis("Vertical");
        playerMovement.z += capsuleSpeed * Time.deltaTime * ZAxis;
    }
}
