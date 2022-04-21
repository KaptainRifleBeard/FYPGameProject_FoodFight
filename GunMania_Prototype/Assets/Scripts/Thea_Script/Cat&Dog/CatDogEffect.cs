using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CatDogEffect : MonoBehaviour
{
    PhotonView view;
    public sl_Inventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dog")
        {
            if (playerInventory.itemList[0] != null)
            {
                sl_ShootBehavior.bulletCount--;
                playerInventory.itemList[0] = null;
                sl_InventoryManager.RefreshItem();
                StartCoroutine(MoveToFront());

            }
        }
    }

    private IEnumerator MoveToFront()
    {
        yield return new WaitForSeconds(0.1f);
        playerInventory.itemList[0] = playerInventory.itemList[1];
        sl_InventoryManager.RefreshItem();

        yield return new WaitForSeconds(0.1f);
        playerInventory.itemList[1] = null;
        sl_InventoryManager.RefreshItem();

    }
}
