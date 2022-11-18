using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject target;

    public Material[] mainMat;
    public string DamageType = "Normal";
    public float Damage = 2f;
    public float moveSpeed = 10f;
    //public float Damage = 5f;

    
    private void Update(){
        if(target != null){
            MoveProjectile();
        } else{
            Destroy(gameObject);
        }
    }
    
    private void MoveProjectile(){
        transform.position = Vector3.MoveTowards(transform.position, 
        target.transform.position, moveSpeed * Time.deltaTime);

        if((transform.position - target.transform.position).magnitude < .2f){
            print(target.name);
            print(target.GetComponent<Health>()==null);
            target.GetComponent<Health>().TakeDamage(Damage,DamageType);
            Destroy(gameObject);
        }

    }

    public void SetEnemy(GameObject enemy){
        target = enemy;
    }

    public void SetBulletStats(GameObject enemy,string dmgType,float dmg,int ty){
        target = enemy;
        DamageType = dmgType;
        Damage = dmg;

        gameObject.GetComponent<MeshRenderer>().material = mainMat[ty];
    }
}
