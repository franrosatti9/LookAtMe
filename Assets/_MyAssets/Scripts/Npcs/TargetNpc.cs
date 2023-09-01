using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetNpc : BaseNpc
{
    public int maxPoses;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public override void LookAt(Transform target)
    {
        // Hacer que haga pose random tal vez aca
        int rdm = Random.Range(1, maxPoses + 1);
        anim.SetTrigger("Pose" + rdm);
        transform.LookAt(new Vector3(target.position.x, 1, target.position.z));
    }
}
