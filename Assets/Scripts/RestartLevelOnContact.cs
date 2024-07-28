using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class RestartLevelOnContact : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<LevelLoader>().RestartLevel();
    }
}
