using System.Collections;
using UnityEngine;

public class Character : Unit
{
    [SerializeField]
    private int lives = 5;
    [SerializeField]
    private float speed = 3.0F;
    [SerializeField]
    private float jumpForce = 15.0F;

    private bool isGrounded = false;

    private Bullet bullet;

    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        bullet = Resources.Load<Bullet>("Bullet");


    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        if (isGrounded) State = CharState.Idle;

        if (Input.GetButton("Fire1")) Shoot();

        if (Input.GetButton("Horizontal")) Run();
        if (isGrounded && Input.GetButtonDown("Jump")) Jump();
    }

    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        sprite.flipX = direction.x < 0.0F;
        if (isGrounded) State = CharState.Run;
    }

    //Коммент

    private void Jump()
    {
        State = CharState.Jump;
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Shoot()
    {
        Vector3 position = transform.position; position.y += 0.85F;
        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;
        newBullet.Parent = gameObject;
        newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0F : 1.0F);
    }

    public override void ReceiveDamage()
    {
        lives--;

        Debug.Log(lives);
    }
    private void CheckGround()
    {
        if (!isGrounded) State = CharState.Jump;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3F);
        isGrounded = colliders.Length > 1;

    }
    /*жопажопажопажопа
     */
}

public enum CharState
{
    Idle,
    Run,
    Jump
}
