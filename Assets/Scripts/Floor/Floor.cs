using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log($"OnParticleCollision {gameObject.name}");
    }
}
