using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalMove;
    private float verticalMove;
    private Vector3 playerInput;
    private CharacterController player;
    private Animator animator;

    float gravity = 9.8f;

    float rotY = 0f;

    private bool isWalking = false;

    [Header("Player parameters")]
    public float playerSpeed;
    public float mouseSensitivity = 100.0f;

    [Header("Game Objects")]
    public Transform handweapon;
    public Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        if (!isWalking && (horizontalMove > 0f || verticalMove > 0f)) {
            animator.SetBool("walk", true);
            isWalking = true;
        } else if (isWalking && horizontalMove == 0f && verticalMove == 0f) {
            animator.SetBool("walk", false);
            isWalking = false;
        }

        if (Input.mousePresent)
        {
            float mouseX = Input.GetAxis("Mouse X");
            rotY += mouseX * mouseSensitivity * Time.deltaTime;

            Quaternion localRotation = Quaternion.Euler(0f, rotY, 0.0f);
            player.transform.rotation = localRotation;
        }

        playerInput = new Vector3(horizontalMove , 0, verticalMove);
        
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        player.Move(transform.TransformDirection(playerInput) * playerSpeed * Time.deltaTime);

        if (weapon && Input.GetMouseButtonDown(0)) {
            weapon.Shoot();
        }
    }

    private void FixedUpdate() {
       
    }

    float AngleBetweenPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.z - b.z, a.x - b.x) * Mathf.Rad2Deg;
    }

    public void PickWeapon (Weapon newWeapon) {
        newWeapon.gameObject.transform.parent = handweapon;
        newWeapon.gameObject.transform.localPosition = Vector3.zero;
        Vector3 angle =  newWeapon.gameObject.transform.localEulerAngles;
        angle.x = 0f;
        newWeapon.gameObject.transform.localEulerAngles = angle;
        weapon = newWeapon;
        newWeapon.owner = characterType.PLAYER;
    }
}
