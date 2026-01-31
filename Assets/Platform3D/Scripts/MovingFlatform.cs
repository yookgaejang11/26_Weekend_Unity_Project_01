using UnityEngine;

public class MovingFlatform : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private Vector3 moveDirection = Vector3.right; 
    [SerializeField] private float distance = 5f;               
    [SerializeField] private float speed = 2f;

    [Header("Rotate")]
    [SerializeField] private Vector3 rotationSpeed = new Vector3(0, 100f, 0);

    private Vector3 _startPos;

    void Start()
    {
        _startPos = transform.position;
        // 방향 벡터 정규화 (방향만 사용하기 위함)
        moveDirection.Normalize();
    }

    void Update()
    {
        MoveHandle();
        RotateHandle();
    }

    void MoveHandle()
    {
        // PingPong을 사용하여 0 ~ distance 사이를 왕복
        float currentOffset = Mathf.PingPong(Time.time * speed, Mathf.Max(1,distance));
        transform.position = _startPos + (moveDirection * currentOffset);
    }
    void RotateHandle()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, Space.Self);
    }
}
