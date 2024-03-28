using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    //스피드 조정 변수
    [SerializeField]
    private float walkSpeed;

    [SerializeField]
    private float lookSensitivity; 

    [SerializeField]
    private float cameraRotationLimit;  
    private float currentCameraRotationX;  

    [SerializeField]
    private Camera camera; 
    private Rigidbody rigidbody;
    private Animator animator;

    public float zoomSpeed = 10.0f;

    enum SceneType { Plaza_verse, Elevator, HomeMinju }
    SceneType currentScene;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        
    }

    void Update()
    {
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        SetWalkSpeed(sceneName);
        
        Move();

        CameraRotation();
        PlayerRotation();

        Zoom();
    }

    private void SetWalkSpeed(string sceneName)
    {
        switch (sceneName)
        {
            case "Plaza_verse":
                walkSpeed = 5000f;
                Debug.Log("setPlazaSpeed");
                break;
            case "Elevator":
                walkSpeed = 2f;
                Debug.Log("setElevatorSpeed");
                break;
            case "HomeMinju":
                walkSpeed = 250f;
                Debug.Log("setHomeSpeed");
                break;
            default:
                // 기본값 설정
                walkSpeed = 5f;
                break;
        }
    }

    private void Move()
    {
        float moveDirX = Input.GetAxis("Horizontal");  
        float moveDirY = Input.GetAxis("Vertical");
        Vector3 moveHorizontal = transform.right * moveDirX; 
        Vector3 moveVertical = transform.forward * moveDirY;
        Vector3 velocity = Vector3.zero;

        if (moveHorizontal != Vector3.zero || moveVertical != Vector3.zero)
        {
            velocity = (moveHorizontal + moveVertical).normalized * walkSpeed; 
            animator.SetBool("isWalk", true);
        }
        else
            animator.SetBool("isWalk", false);

        rigidbody.MovePosition(transform.position + velocity * Time.deltaTime);
    }
    

    private void CameraRotation()
    {
        // if(Input.GetMouseButton(1))
        // {
        //     float xRotation = Input.GetAxisRaw("Mouse Y"); 
        //     float cameraRotationX = xRotation * lookSensitivity;
        
        //     currentCameraRotationX -= cameraRotationX;
        //     currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        //     camera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
        // }
        float xRotation = Input.GetAxisRaw("Mouse Y"); 
        float cameraRotationX = xRotation * lookSensitivity;
        
        currentCameraRotationX -= cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        camera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }

    private void PlayerRotation()
    {
        // if(Input.GetMouseButton(1))
        // {
        //     float yRotation = Input.GetAxisRaw("Mouse X");
        //     Vector3 playerRotationY = new Vector3(0f, yRotation, 0f) * lookSensitivity;
        //     rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(playerRotationY)); 
        // }
        // float yRotation = Input.GetAxisRaw("Mouse X");
        // Vector3 playerRotationY = new Vector3(0f, yRotation, 0f) * lookSensitivity;
        // rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(playerRotationY)); 
        float yRotation = Input.GetAxisRaw("Mouse X"); 
        float cameraRotationY = yRotation * lookSensitivity;

        transform.Rotate(Vector3.up, cameraRotationY);
    }

    private void Zoom()
    {
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;
        if(distance != 0)
        {
            float viewLimit = camera.fieldOfView + distance;
            float minZoom = 30f;
            float maxZoom = 80f;

            camera.fieldOfView = Mathf.Clamp(viewLimit, minZoom, maxZoom);


        }
    } 
}
