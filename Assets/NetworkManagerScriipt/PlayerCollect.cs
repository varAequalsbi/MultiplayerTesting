using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerCollect : NetworkBehaviour
{
    private NetworkVariable<int> item = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner );

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Destroy(collision.gameObject);

            AddItemServerRpc();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Client id: "+OwnerClientId +" Item: "+item.Value);
        }
    }

    [ServerRpc]
    
    private void AddItemServerRpc()
    {
        item.Value = item.Value + 1;
    }

    
}
