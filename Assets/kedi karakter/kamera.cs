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
        if (Input.GetMouseButtonDown(2)) // Mouse tekerle�ine bas�l�nca
        {
            ResetCameraPosition();
        }
    }
    void ResetCameraPosition()
    {
        // followPoint karakterin arkas�na ta��n�r
        followPoint.position = player.position + player.rotation * offset;

        // �ste�e ba�l�: followPoint karakterle ayn� y�ne baks�n
        followPoint.rotation = Quaternion.LookRotation(player.forward);
    }
}
