using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [Header("설정")]
    [SerializeField] private float rotationSpeed = 50f; // 초당 회전 속도
    [SerializeField] private Vector3 rotationAxis = Vector3.up; // 회전 축 (보통 Y축)

    private List<Transform> playersOnPlatform = new List<Transform>();

    void Update()
    {
        // 1. 원판 자체를 회전시킴
        float angle = rotationSpeed * Time.deltaTime;

        // 2. 원판 위의 플레이어들도 같이 회전시킴
        RotatePlayers(angle);
    }

    private void RotatePlayers(float angle)
    {
        foreach (Transform player in playersOnPlatform)
        {
            if (player == null) continue;

            // 회전 중심점(Pivot) 정의
            Vector3 pivot = transform.position;

            // 중심점에서 플레이어까지의 벡터 (반경)
            Vector3 relativePosition = player.position - pivot;

            // 회전 쿼터니언 생성
            Quaternion rotation = Quaternion.AngleAxis(angle, rotationAxis);

            // 벡터를 회전시키고 다시 중심점에 더해 새로운 위치 결정
            player.position = pivot + (rotation * relativePosition);

            // 플레이어의 몸체(Rotation)도 같이 회전시키고 싶다면 추가
            player.Rotate(rotationAxis, angle);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어 태그 확인 (태그가 Player로 설정되어 있어야 함)
        if (other.CompareTag("Player"))
        {
            if (!playersOnPlatform.Contains(other.transform))
            {
                playersOnPlatform.Add(other.transform);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playersOnPlatform.Remove(other.transform);
        }
    }
}