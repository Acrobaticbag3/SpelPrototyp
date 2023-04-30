using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    [SerializeField] private GameObject PickUpText;

    public ItemPickUp senseditem = null;

    private Ray ray;
    private float raycastLength = 5f;
    RaycastHit hit;
    public LayerMask layerstohit;


    private void Update()
    {
        ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, raycastLength, layerstohit))
        {   
            ItemPickUp item = hit.collider.GetComponent<ItemPickUp>();
            if(item)
            {
                senseditem = item;
            }
            else senseditem = null;

            PickUpText.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                item.PickUp();   
            }
        }
        else PickUpText.SetActive(false);
    }


}
