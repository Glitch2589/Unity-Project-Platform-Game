using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float characterMovementSpeed = 5;
    public Animator animator;
    public Rigidbody2D rb;


    void Start()
    {
        transform.position = new Vector3(PlayerPrefs.GetFloat("CharacterPositionX"), PlayerPrefs.GetFloat("CharacterPositionY"), 0) ;
    }

    void Update()
    {
        Vector3 moveDirectionKey = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        animator.SetFloat("Horizontal", moveDirectionKey.y);
        animator.SetFloat("Vertical", moveDirectionKey.x);
        animator.SetFloat("Magnitude", moveDirectionKey.magnitude);
        rb.velocity = new Vector2(moveDirectionKey.x* characterMovementSpeed, moveDirectionKey.y* characterMovementSpeed);
        SavePosition(transform.position.x, transform.position.y, 0);

    }
    void SavePosition(float x, float y, float z)
    {
        PlayerPrefs.SetFloat("CharacterPositionX", x);
        PlayerPrefs.SetFloat("CharacterPositionY", y);
        PlayerPrefs.SetFloat("CharacterPositionZ", z);

    }
}
