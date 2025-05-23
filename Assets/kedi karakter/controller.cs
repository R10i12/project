using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    [SerializeField] private bool rotateNow;
    public float speed;
    [SerializeField] private Vector3 movementVector;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform yavrum;

    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;
    private Rigidbody rb;
    float rotationSpeed = 1f;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        movementVector = new Vector3(horizontal, 0, vertical);
        Vector3 tempMovementVector =  Vector3.zero;
        tempMovementVector += transform.forward * movementVector.z;
        tempMovementVector += transform.right * movementVector.x;
        
       
        
        
        movementVector.Normalize();
        rb.MovePosition(transform.position + tempMovementVector * speed*Time.deltaTime);

       // Vector3 rotation = new Vector3(cameraTransform.eulerAngles.x,0,0);
       // transform.rotation = Quaternion.LookRotation(rotation);//boþ kodlar bunlarý siktir et

        CalisLutfen();
    }
    private void CalisLutfen()
    {
        float X = Input.GetAxis("Mouse X") * rotationSpeed;
        Vector3 rotation= new Vector3(0,X,0);
        yavrum.Rotate(rotation);
    }
}
