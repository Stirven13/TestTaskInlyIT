using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewInteract : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public float oscillationSpeed = 2f;
    public float oscillationHeight = 0.5f;

    private Vector3 initialPosition;
    public Transform visualObject;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = visualObject.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (visualObject == null) return;

        visualObject.Rotate(0, rotationSpeed * Time.deltaTime, 0);

        float newY = initialPosition.y + Mathf.Sin(Time.time * oscillationSpeed) * oscillationHeight;
        visualObject.localPosition = new Vector3(initialPosition.x, newY, initialPosition.z);
    }

    private void OnCollisionStay(Collision collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player == null) { return; }
        if (!player.IsUse()) { return; }
        player.TakeDamage(50);
        Destroy(gameObject);
    }

}
