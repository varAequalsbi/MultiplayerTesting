
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : NetworkBehaviour
{
    // private NetworkVariable<int> randomnumber = new NetworkVariable<int>(1, NetworkVariableReadPermission.Everyone,NetworkVariableWritePermission.Owner);
    private Rigidbody2D rb;
    [SerializeField] float speed = 7f;
    [SerializeField] CinemachineVirtualCamera vc;
   

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            vc.Priority = 1;
        }
        else
        {
            vc.Priority = -1;
        }

       // randomnumber.OnValueChanged += (int previousValue, int newValue) =>
       // {
       //     Debug.Log(OwnerClientId + "randomNumber: " + randomnumber.Value);
       // };
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!IsOwner) return;
        //if (Input.GetKeyDown(KeyCode.T))
       // {
       //     randomnumber.Value = Random.Range(0, 100);
      //  }
        float drix = Input.GetAxisRaw("Horizontal");
        float driy = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(drix * speed, driy * speed);

        // rb.velocity = new Vector2();


    }
}
