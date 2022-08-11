using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPortal : MonoBehaviour
{
    [SerializeField] private GameObject teleportMenu;


    private void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        teleportMenu.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        teleportMenu.SetActive(false);
    }
}
