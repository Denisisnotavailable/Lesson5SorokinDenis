 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] float _angleOpenDoor = 110f;
    [SerializeField] float _angleCloseDoor = 0;
    [SerializeField] float _speed = 2;

    public bool _isOpened = false;


    private void Update()
    {
        if (_isOpened == true)
        {
            OpenDoor();
        }
        else CloseDoor();
    }

    void OpenDoor()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,
                             Quaternion.Euler(transform.rotation.x, _angleOpenDoor, transform.rotation.z),
                             _speed * Time.deltaTime);
    }

    void CloseDoor()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,
                             Quaternion.Euler(transform.rotation.x, _angleCloseDoor, transform.rotation.z),
                             _speed * Time.deltaTime);
    }

}
