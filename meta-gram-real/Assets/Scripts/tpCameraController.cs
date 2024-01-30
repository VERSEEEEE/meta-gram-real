using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class tpCameraController : MonoBehaviour
{
    public GameObject Target;
    public float offsetX = 0.0f;
    public float offsetY = 20.0f;
    public float offsetZ = -19.0f;
    float CameraSpeed = 10.0f;

    float xmove = 0;  // X축 누적 이동량
    float ymove = 0;  // Y축 누적 이동량

    Vector3 TargetPos;

    void Start()
    {
        transform.rotation = Quaternion.Euler(new Vector3(35, 0, 0));
    }

    void Update()
    {
        //  마우스 우클릭 중에만 카메라 무빙 적용
        if (Input.GetMouseButton(1))
        {
            xmove += Input.GetAxis("Mouse X"); // 마우스의 좌우 이동량을 xmove 에 누적합니다.
            ymove -= Input.GetAxis("Mouse Y"); // 마우스의 상하 이동량을 ymove 에 누적합니다.
            transform.rotation = Quaternion.Euler(ymove, xmove, 0); // 이동량에 따라 카메라의 바라보는 방향을 조정합니다.
        }
        
        TargetPos = new Vector3(
            Target.transform.position.x + offsetX,
            Target.transform.position.y + offsetY,
            Target.transform.position.z + offsetZ
            );

        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);
    }
}
