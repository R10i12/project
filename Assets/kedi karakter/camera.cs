using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField] private float mouseX;
    [SerializeField] private float mouseY;
    [SerializeField] private float maxLimit;
    [SerializeField] private float minLimit;
    [SerializeField] private Transform point;
    //private Vector3 hedefVector;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        //hedefVector = transform.eulerAngles;
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        transform.eulerAngles += new Vector3(0, mouseX, 0);
        transform.eulerAngles -= new Vector3(mouseY, 0, 0);
        point.eulerAngles -= new Vector3(mouseY, -mouseX, 0);
       /* float startValue=point.eulerAngles.y;
        if (-180 < startValue && startValue < maxLimit)
            transform.eulerAngles = new Vector3(maxLimit, transform.eulerAngles.y, transform.eulerAngles.z);
        if (minLimit < startValue && startValue < 180)
            transform.eulerAngles = new Vector3(minLimit, transform.eulerAngles.y, transform.eulerAngles.z);
       */

    }
}
