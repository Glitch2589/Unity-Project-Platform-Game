using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MiniGameCameraFollow : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
        if(player.transform.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
        }
        if (player.transform.position.y < transform.position.y - 5f)
        {
            Debug.Log("Game over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
