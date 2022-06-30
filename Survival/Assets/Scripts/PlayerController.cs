using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] // private 상태는 유지하여 이 스크립트 내에서만 수정 가능하도록 하되 유니티 인스펙터 창에서 쉽게 수정할 수 있게 해주도록 함
    private float walkspeed;

    private Rigidbody myRigid; // 플레이어의 실제 육체적인 몸을 의미함
    // Collider는 충돌 영역을 설정하고 Rigidbody는 Collider에 물리학 (중력, 저항 등)을 입히는 것임

    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody>(); // Rigidbody 컴포넌트를 myRigid 변수에 넣는다는 뜻

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal"); // 1(R) -1(L) 0(N) 벡터가 아니라 스칼라임에 유의할 것
        float _moveDirZ = Input.GetAxisRaw("Vertical"); // 정면과 후면, 혹시 코드 intellisense 안 되면 dotnet 4.7.1 깔고 extension에서 snippet 설치할 것

        Vector3 _moveHorizontal = transform.right * _moveDirX; // 좌우 방향, transform.right는 벡터
        Vector3 _moveVertical = transform.forward * _moveDirZ; // 앞뒤 방향, transform.forward는 벡터
        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * walkspeed;

        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime); // 


    }
}