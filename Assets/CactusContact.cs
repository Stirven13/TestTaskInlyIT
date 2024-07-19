using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusContact : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                Player player = collision.gameObject.GetComponent<Player>();
                if (player == null) { return; }
                player.TakeDamage(1);
                break;
        }
    }
}
