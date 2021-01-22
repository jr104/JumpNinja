using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Camera cam;
    

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = new Vector3(player.position.x, cam.transform.position.y, cam.transform.position.z);
    }
}
