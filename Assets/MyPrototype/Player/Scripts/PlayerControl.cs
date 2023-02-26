using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public delegate void PlayerInteract();

    public event PlayerInteract EPlayerInteract;

    public bool IsAxeColected;

    private void Awake()
    {
        IsAxeColected = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {

            EPlayerInteract?.Invoke();

        }

    }

    public void ColectAxe()
    {
        IsAxeColected = true;
    }

}
