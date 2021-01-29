using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer _callButton;

    [SerializeField]
    private int _requiredCoins = 0;

    [SerializeField]
    private Elevator _elevator;

    private bool _elevatrorCalled = false;

    private void Start()
    {
        _elevator = GameObject.Find("Elevator").GetComponent<Elevator>();
        if (_elevator == null)
        {

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (Input.GetKeyDown(KeyCode.E) && player.CoinCount() >= _requiredCoins)
            {
                if (_elevatrorCalled)
                {
                    _callButton.material.color = Color.red;
                } else
                {
                    _callButton.material.color = Color.green;
                    _elevatrorCalled = true;
                }
                _elevator.CallElevator();
            }
        }       
    }
}
