using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class CameraController : NetworkBehaviour
{
    [SerializeField] private GameObject cam;

    public void Update()
    {
        if (!IsOwner) return;
       cam.transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }
}
