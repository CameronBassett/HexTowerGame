using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    NavmeshGen navMeshGen;


    public int moveSpeed;
    public float maxVelocity;

    public bool jumpCheck;
    public bool jumpCheck2;
    // Start is called before the first frame update
    void Start()
    {
        jumpCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * moveSpeed/2, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.back * moveSpeed/2, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Rotate(Vector3.down * moveSpeed);
            //gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left * moveSpeed/2, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Rotate(Vector3.up * moveSpeed);
            //gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * moveSpeed/2, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.Space) && (jumpCheck2 == true) && (jumpCheck == false))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * moveSpeed * 3.5f, ForceMode.Impulse);
            jumpCheck2 = false;
            jumpCheck = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && (jumpCheck == true))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * moveSpeed * 4, ForceMode.Impulse);
            jumpCheck = false;
        }

        if (Input.GetKeyUp(KeyCode.U))
        {
            navMeshGen.UpdateLinks();
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }


        if (GetComponent<Rigidbody>().velocity.sqrMagnitude > maxVelocity)
        {
            GetComponent<Rigidbody>().velocity *= 0.95f;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("jumpcheck triggered");
        jumpCheck = true;
        jumpCheck2 = true;
    }
}

