using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("플레이어 데이터가 준비되었습니다.");
    }

    void Start()
    {
        Debug.Log("사냥 장비를 챙겼습니다.");
    }

    void FixedUpdate()
    {
        Debug.Log("이동");
    }

    void Update()
    {
        Debug.Log("몬스터 사냥!!");
    }

    void LateUpdate()
    {
        Debug.Log("경험치 획득");
    }

    void OnDestroy()
    {
        Debug.Log("플레이어 데이터를 해체하였습니다.");
    }
}