using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BaseNpc : MonoBehaviour
{
    public Animator anim;
    public bool isDead = false;
    public float sightRange = 5f;

    [SerializeField] GameObject bloodFx;
    [SerializeField] GameObject explosionFx;
    
    [SerializeField] float sightAngle = 80f;
    [SerializeField] LayerMask sightObstacleMask;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        isDead = false;
    }
    
    public virtual void LookAt(Transform target)
    {
        // Hacer que haga pose random tal vez aca
        transform.LookAt(new Vector3(target.position.x, 1, target.position.z));
    }
    
    #region Sight
    public bool IsInSight(Transform target) //Bool para verificar si el enemigo detectó al jugador dentro de su rango de visión
    {
        if (target == null) return false;
        Vector3 diff = target.position - transform.position;
        float distance = diff.magnitude;
        if (distance > sightRange) return false;

        Vector3 front = transform.forward;

        if (!InAngle(diff, front)) return false;

        if (!IsInView(diff.normalized, distance, sightObstacleMask)) return false;

        return true;
    }
    
    bool InAngle(Vector3 from, Vector3 to)
    {
        float angleToTarget = Vector3.Angle(from, to);
        return angleToTarget < sightAngle / 2;
    }
    bool IsInView(Vector3 dirToTarget, float distance, LayerMask maskObstacle)
    {
        return !Physics.Raycast(transform.position, dirToTarget, distance, maskObstacle);
    }
    #endregion
    public void Die()
    {
        Instantiate(bloodFx, transform.position, Quaternion.identity);
        Instantiate(explosionFx, transform.position, Quaternion.identity);
        GameManager.instance.NpcDead();
        // EXPLODE
        //anim.SetTrigger("Die");
        Destroy(gameObject);
    }
}
