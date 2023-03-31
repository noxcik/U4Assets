using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_control : MonoBehaviour
{
    
    public float moveSpeed;
    public float jumpForce;
    public float sens_mouse_x;
    public float sens_mouse_y;
    public Transform forwardPoint;
    public Transform rightPoint;
    public Transform camera; 

    float normalMoveSpeed;
    float smallerMoveSpeed;
    bool onGround;
    bool canJump=true;

    Rigidbody body;
    Animator anim;
    
    private void OnCollisionStay(Collision other) {
        
        onGround = true;
        
        if(other.gameObject.tag == "Water"){
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
    private void OnCollisionExit(Collision other) {
         if(other.gameObject.tag == "Terrain" ||other.gameObject.tag == "Ground"){
            onGround = false;
        }
    }

    private void Start() {
        body = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        normalMoveSpeed  = moveSpeed;
        smallerMoveSpeed = moveSpeed * 0.7f;
    }
    IEnumerator Jump() // fix: Теперь в отдельной функции, для более правильного прыжка и порядка кода
    {
        body.velocity = Vector3.zero;
        body.AddForce(Vector3.up * jumpForce);
        canJump = false; 
        yield return new WaitForSeconds(1);
        canJump = true; // Через секунду снова можем прыгать
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float forward = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;
        float right = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        if(forward != 0 && right != 0){
            moveSpeed = smallerMoveSpeed;
        }else{
            moveSpeed = normalMoveSpeed;
        }
        if(forward != 0 || right != 0){
            anim.SetBool("Run", true);
        }else{
            anim.SetBool("Run", false);
        }
        body.AddForce((forwardPoint.position - transform.position) * forward);
        body.AddForce((rightPoint.position - transform.position) * right);
        if(Input.GetKey(KeyCode.Space) && onGround && canJump && Physics.Raycast(transform.position, Vector3.down, 1f)){// На земле, можем прыгать и под ногами что-то есть
            //Debug.Log("Press Space");
            StartCoroutine(Jump());
        }
        float hor = sens_mouse_x * Input.GetAxis("Mouse X");
        float ver = sens_mouse_y * Input.GetAxis("Mouse Y");
        transform.Rotate(0, hor, 0);
        camera.Rotate(ver, 0, 0);
        if(camera.rotation.x < -60){
            camera.rotation = Quaternion.Euler(-60, 0, 0);
            Debug.Log("fvgbhnjk");
        }
        if(camera.rotation.x > 60){
            camera.rotation = Quaternion.Euler(60, 0, 0);
        }
        if(transform.position.y < -30){
            //restart scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // именно текущую сцену
        }
    }
}
