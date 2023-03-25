using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_control : MonoBehaviour
{
    public Rigidbody body;
    public float moveSpeed;
    public float jumpForce;
    public float sens_mouse_x;
    public float sens_mouse_y;
    public Transform forwardPoint;
    public Transform rightPoint;
    public bool canJump;
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Terrain" ||other.gameObject.tag == "Ground"){
            canJump = true;
        }
    }
    private void OnCollisionExit(Collision other) {
         if(other.gameObject.tag == "Terrain" ||other.gameObject.tag == "Ground"){
            canJump = false;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        float forward = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;
        float right = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        //body.AddForce(new Vector3(right, 0, forward) * Time.deltaTime);
        //transform.position += new Vector3(right, 0, forward);
        body.AddForce((forwardPoint.position - transform.position) * forward);
        body.AddForce((rightPoint.position - transform.position) * right);
        if(Input.GetKey(KeyCode.Space) && canJump){
            body.AddForce(Vector3.up * jumpForce);
            canJump = false;
        }
        float hor = sens_mouse_x * Input.GetAxis("Mouse X");
        float ver = sens_mouse_y * Input.GetAxis("Mouse Y");
        transform.Rotate(ver, hor, 0);
        if(transform.position.y < -30){
            //restart scene
            SceneManager.LoadScene(0);
        }
    }
}
