using System.Linq.Expressions;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rigid;
    public float moveSpeed = 7;
    public float jumpPower = 100f;

    public Transform bottom;
    public LayerMask groundLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        if (dir.sqrMagnitude > 1f) dir.Normalize();

        dir = Camera.main.transform.TransformDirection(dir);

        Vector3 targetVelocity = dir * moveSpeed;
        targetVelocity.y = rigid.linearVelocity.y;
        rigid.linearVelocity = targetVelocity;


        Jump();
    }


    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (!IsGround())
            {
                return;
            }
            else
            {
                rigid.AddRelativeForce(transform.up * jumpPower);
            }
        }
    }

    bool IsGround()
    {

        return Physics.Raycast(bottom.position + Vector3.up * 0.1f, Vector3.down, out RaycastHit hitt,1.5f,groundLayer);
    }
}
