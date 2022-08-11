using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public SpriteRenderer artworkSprite;
    private int selectedOption = 0;

    public CharacterCheck characterCheck;
    public Animator animator;
    private static float bulletLoadTime;
    private int jumpTimes;
    private bool canJump = true;
    public static bool isShooted;

    float horizontalMove = 0f;
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpForce = 9f;
    [SerializeField] int jumpCount = 0;

    public Bullet bulletPrefab;
    public Transform launchOffset;

    Rigidbody2D _rigidbody2d;
    SpriteRenderer _spriteRender;
    Vector2 _startPosition;


    private void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _spriteRender = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        _startPosition = _rigidbody2d.position;

        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        UpdateCharacter(selectedOption);
        if (!PlayerPrefs.HasKey("JumpBoost"))
        {
            PlayerPrefs.SetInt("JumpBoost", 0);
            PlayerPrefs.SetInt("JumpBoost2", 0);
        }
        jumpTimes = PlayerPrefs.GetInt("JumpBoost") + PlayerPrefs.GetInt("JumpBoost2");
    }

    void Update()
    {
        animator.SetFloat("Speed", 1);
        horizontalMove = Input.GetAxisRaw("Horizontal");
        Vector3 move = new Vector3(horizontalMove, 0, 0);
        transform.position += runSpeed * Time.deltaTime * move;
        if(jumpCount == jumpTimes + 1)
        {
            canJump = false;
        }
        animator.SetFloat("yVelocity", _rigidbody2d.velocity.y);
        if (Input.GetButtonDown("Jump") && canJump)
        {
            animator.SetBool("IsJumping", true);
            jumpCount++;
            _rigidbody2d.velocity = Vector3.up * jumpForce;
            //_rigidbody2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);    
        }
        


        if (Input.GetButtonDown("Fire1") && Time.time > bulletLoadTime)
        {
            Instantiate(bulletPrefab, launchOffset.position, transform.rotation);
            bulletLoadTime = Time.time + CharacterStatus.bulletLoad;
            isShooted = true;
        }

    }

    private void UpdateCharacter(int selectedOption)
    {
        CharacterInformation characterInfo = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = characterInfo.characterSprite;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("IsJumping", false);
            jumpCount = 0;
            canJump = true;
        }

    }
}
