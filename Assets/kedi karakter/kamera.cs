using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform followPoint;
    [SerializeField] private Vector3 offset = new Vector3(0, 4, -6);

    public void LateUpdate()
    {


      transform.position = followPoint.position;
      // transform.LookAt(player);
        if (Input.GetMouseButtonDown(2)) // Mouse tekerleðine basýlýnca
        {
            ResetCameraPosition();
        }
    }
    void ResetCameraPosition()
    {
        // followPoint karakterin arkasýna taþýnýr
        followPoint.position = player.position + player.rotation * offset;

        // Ýsteðe baðlý: followPoint karakterle ayný yöne baksýn
        followPoint.rotation = Quaternion.LookRotation(player.forward);
    }
}
