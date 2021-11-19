using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHitCollider : MonoBehaviour
{
    [SerializeField] private bool isHump;
    private ZombieHealth health;

    private void Awake()
    {
        health = GetComponentInParent<ZombieHealth>();
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log($"OnParticleCollision {gameObject.name}");
        if (other.tag.Equals(GameTags.WaterGunParticles.ToString()))
            health.HitTimer += Time.deltaTime * (isHump ? 2 : 1);
    }
}
