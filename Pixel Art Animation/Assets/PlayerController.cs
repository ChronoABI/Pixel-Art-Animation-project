using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField]Rigidbody2D rb;

    bool facingRight = true;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        MovementControl(Input.GetAxisRaw("Horizontal"));
    }

    void MovementControl(float hInput)
    {
        rb.velocity = new Vector2(hInput * speed * Time.fixedDeltaTime, rb.velocity.y);
        if (hInput != 0)
        {
            anim.SetInteger("State", 1);
        }
        else
        {
            anim.SetInteger("State", 0);
        }
        if (hInput<0 && facingRight )
        {
            Flip();
        }
        else if (hInput>0 && !facingRight)
        {
            Flip();
        }
    }
    
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(new Vector3(0, 180, 0));

    }
}
