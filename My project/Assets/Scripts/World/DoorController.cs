using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float _distance = 2f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, _distance))
            {
                if (hit.collider.tag == "Door")
                {
                    Door door = hit.collider.GetComponent<Door>();
                    door._isOpened = !door._isOpened;
                }    
            }
        }
    }
}
