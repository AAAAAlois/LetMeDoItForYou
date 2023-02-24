using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPScam : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] Transform orientation;
    [SerializeField] Transform player;
    [SerializeField] Transform playerObj;
    [SerializeField] Rigidbody rb;

    [SerializeField] float rotationSpeed;

    [SerializeField] CameraStyle currentStyle;
    [SerializeField] Transform combatLookAt;

    [SerializeField] bool isCursorVisible = false;

    public enum CameraStyle
    {
        Basic,
        Combat,
        Topdown
    }
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = isCursorVisible;

        if (isCursorVisible)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        if(currentStyle == CameraStyle.Basic)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

            if (inputDir != Vector3.zero)
            {
                playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
            }
        }
        
        else if(currentStyle == CameraStyle.Combat)
        {
            Vector3 dirToCombatLookAt = combatLookAt.position - new Vector3(transform.position.x, combatLookAt.position.y, transform.position.z);
            orientation.forward = dirToCombatLookAt.normalized;

            playerObj.forward = dirToCombatLookAt.normalized;
        }

        
    }
}
