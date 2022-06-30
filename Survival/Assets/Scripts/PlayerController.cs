using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 스피드 조정 변수
    [SerializeField] // private 상태는 유지하여 이 스크립트 내에서만 수정 가능하도록 하되 유니티 인스펙터 창에서 쉽게 수정할 수 있게 해주도록 함
    private float walkSpeed; // 걷는 속도
    [SerializeField]
    private float runSpeed; // 달리는 속도
    private float applySpeed; // 걷는 속도와 달리는 속도를 매개할 변수

    // 상태 판정 변수
    private bool isRun = false;
    private bool isGround = true;

    // 점프 변수
    [SerializeField]
    private float jumpForce;

    // 땅 착지 여부를 위한 변수
    private CapsuleCollider capsuleCollider;

    // 카메라 민감도
    [SerializeField]
    private float lookSensitivity; // 카메라의 민감도

    // 카메라 한계
    [SerializeField]
    private float cameraRotationLimit; // 고개를 움직일 때 최대 움직일 수 있는 각도 설정
    private float currentCameraRotationX = 0; // 기본적으로 카메라는 정면을 보도록 설정

    // 필요한 컴포넌트
    [SerializeField]
    private Camera theCamera;
    private Rigidbody myRigid; // 플레이어의 실제 육체적인 몸을 의미함
    // Collider는 충돌 영역을 설정하고 Rigidbody는 Collider에 물리학 (중력, 저항 등)을 입히는 것임

    // Start is called before the first frame update
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        myRigid = GetComponent<Rigidbody>(); // Rigidbody 컴포넌트를 myRigid 변수에 넣는다는 뜻
        applySpeed = walkSpeed; // 처음에는 applySpeed를 걷는 속도로 초기화
    }

    // Update is called once per frame
    void Update()
    {
        IsGround();
        TryJump();
        TryRun(); // 뛰는지 걷는지 판단하고 움직임을 제어할 것이기 때문에 반드시 Move() 위에 있어야 함
        Move();
        CameraRotation();
        CharactorRotation();
    }

    private void IsGround()
    {
        isGround = Physics.Raycast(transform.position, Vector3.down, capsuleCollider.bounds.extents.y + 0.1f);
    }

    private void TryJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
        }
    }

    private void Jump()
    {
        myRigid.velocity = transform.up * jumpForce;
    }

    private void TryRun()
    {
        if (Input.GetKey(KeyCode.LeftShift)) // shift를 누르면 달림
        {
            Running();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) // 떼면 달리기 취소
        {
            RunningCancel();
        }
    }

    private void Running()
    {

        isRun = true;
        applySpeed = runSpeed;
    }

    private void RunningCancel()
    {
        isRun = false;
        applySpeed = walkSpeed;
    }

    private void Move() // player 이동
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal"); // 1(R) -1(L) 0(N) 벡터가 아니라 스칼라임에 유의할 것
        float _moveDirZ = Input.GetAxisRaw("Vertical"); // 정면과 후면, 혹시 코드 intellisense 안 되면 dotnet 4.7.1 깔고 extension에서 snippet 설치할 것

        Vector3 _moveHorizontal = transform.right * _moveDirX; // 좌우 방향, transform.right는 벡터 (절대적인 좌표 기준이 아니라 agent 기준임)
        Vector3 _moveVertical = transform.forward * _moveDirZ; // 앞뒤 방향, transform.forward는 벡터
        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * applySpeed; // 표준 속도 계산

        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime); // update는 매 프레임마다 실행되기 때문에 순간이동하는 것이 아니라 deltatime으로 자연스럽게 움직이게 해줘야 됨
        // 또한 컴퓨터마다 다른 성능으로 인해 초당 프레임이 다른데, 이 효과를 deltatime이 보정해주는 역할을 함
    }

    private void CameraRotation() // 카메라 상하 회전
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y"); // 마우스 위아래로 움직이는 정도를 변수로 받음
        float _cameraRotationX = _xRotation * lookSensitivity; // 이 받는 정도와 민감도를 곱함
        currentCameraRotationX -= _cameraRotationX; // 이전 각도에서 변화 각도를 더하면 이후 각도가 됨
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit); // 최대로 고개를 움직일 수 있는 각도 설정

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f); // 구한 이후 각도를 Camera의 rotation 성분에 넣어줌
    }

    private void CharactorRotation() // 캐릭터 좌우 회전
    {
        float _yRotation = Input.GetAxisRaw("Mouse X"); // 마우스 좌우로 움직이는 정도를 변수로 받음
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity; // 이 받는 정도와 민감도를 고려하고 벡터로 나타냄
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY)); // player가 움직이도록 myrigid의 moverotation 함수를 이용함
        Debug.Log(myRigid.rotation); // player의 회전 각도를 3요소로 표현
        Debug.Log(myRigid.rotation.eulerAngles); // player의 회전 각도를 4요소로 표현
    }
}