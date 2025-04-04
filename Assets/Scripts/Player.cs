using UnityEngine;
using UnityEngine.Video;

public class Player : MonoBehaviour
{
    public float speed;

    // Input Axis 값을 받을 전역변수 선언
    float hAxis;
    float vAxis;
    bool wDown;
    Vector3 moveVec;
    
    Animator anim; 
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // GetAxisRaw() : Axis값을 정수로 반환하는 함수
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");
        
        // normalized : 모든 벡터값을 1로
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        
        transform.position += moveVec * speed* (wDown ? 0.3f : 1f) * Time.deltaTime;
       
       anim.SetBool("isRun", moveVec != Vector3.zero);
       anim.SetBool("isWalk", wDown);
       
       transform.LookAt(transform.position + moveVec);
    }
}
