using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    public Vector3 pos; // 현재 위치
    float delta = 2.0f; // 상(하)로 이동 가능한 (y) 최대값
    float speed = 1.5f; // 이동 속도

    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        Vector3 v = pos;
        v.y += delta * Mathf.Sin(Time.time * speed); // 상하 이동의 최대치 및 반전 처리
        transform.position = v;
    }
}
