using UnityEngine;

public class Plaza_Ldoor : MonoBehaviour
{
    public Vector3 targetPosition; // 이동하고자 하는 목표 위치
    public float moveSpeed = 5f; // 이동 속도

    private bool isMoving = false;

    private void Update()
    {
        // 마우스 버튼 클릭 시 이동 시작
        if (Input.GetMouseButton(0) && !isMoving)
        {
            SetTargetPosition();
        }

        // 이동 중일 때만 이동
        if (isMoving)
        {
            MoveToTarget();
        }
    }

    // 클릭된 위치를 목표 위치로 설정
    private void SetTargetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                targetPosition = hit.point;
                targetPosition.y = transform.position.y; // 클릭된 위치의 y값을 현재 오브젝트의 y값으로 맞춰줌
                isMoving = true;
            }
        }
    }

    // 목표 위치로 이동
    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // 목표 위치에 도달했는지 확인
        if (transform.position == targetPosition)
        {
            isMoving = false;
        }
    }
}
