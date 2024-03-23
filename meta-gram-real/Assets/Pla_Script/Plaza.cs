using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plaza : MonoBehaviour
{
    public GameObject Ldoor;
    public GameObject Rdoor;
    private bool canMove;
    private Vector3 LdoorOpenPosition;
    private Vector3 RdoorOpenPosition;
    private Vector3 LdoorClosePosition;
    private Vector3 RdoorClosePosition;
    [SerializeField] private float openSpeed;

    void Start()
    {
        canMove = false;
        LdoorClosePosition = Ldoor.transform.position;
        RdoorClosePosition = Rdoor.transform.position;
        LdoorOpenPosition = LdoorClosePosition + Vector3.right * 2.1f;
        RdoorOpenPosition = RdoorClosePosition - Vector3.right * 2.1f;
    }

    void Update()
    {
        if (!canMove)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.CompareTag("SelectableBtn"))
                    {
                        Debug.Log("btn click");
                        canMove = true;
                    }
                }
            }
        }
        else
        {
            if (Ldoor.transform.position != LdoorOpenPosition || Rdoor.transform.position != RdoorOpenPosition)
            {
                Ldoor.transform.position = Vector3.MoveTowards(Ldoor.transform.position, LdoorOpenPosition, openSpeed * Time.deltaTime);
                Rdoor.transform.position = Vector3.MoveTowards(Rdoor.transform.position, RdoorOpenPosition, openSpeed * Time.deltaTime);
            }
            else
            {
                StartCoroutine(CloseDoorAfterDelay(2f));
            }
        }
    }

    IEnumerator CloseDoorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // 문이 열린 상태를 유지한 후에 닫히도록 대기
        Ldoor.transform.position = Vector3.MoveTowards(Ldoor.transform.position, LdoorClosePosition, openSpeed * Time.deltaTime);
        Rdoor.transform.position = Vector3.MoveTowards(Rdoor.transform.position, RdoorClosePosition, openSpeed * Time.deltaTime);
        if (Ldoor.transform.position == LdoorClosePosition && Rdoor.transform.position == RdoorClosePosition)
        {
            canMove = false;
        }
    }
}
