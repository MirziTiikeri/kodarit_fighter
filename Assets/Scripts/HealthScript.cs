using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon;

public class HealthScript : MonoBehaviour
{
    public float MaxHealth = 100f;
    public float Health;

    private float HitTimer = 0.15f;
    public bool IsHit = false;
    
    public Rigidbody2D MyRigidbody2D;

    public Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0) {
            Die();
        }
    }

    public void TakeDamage(float Damage) {
        if (!IsHit) {
            if(GetComponent<FighterScript>().BlockCheck == true){
                Health -= Damage/2;
                MyRigidbody2D.velocity = new Vector2((GetComponent<Movement>().Facing * -1.5f),1f);
            } else {
                Health -= Damage;
                StartCoroutine(DamageAnimation());
            }  
        }
    }

    IEnumerator DamageAnimation(){
        IsHit = true;
        MyRigidbody2D.velocity = new Vector2((GetComponent<Movement>().Facing * -2.5f), 2.5f);
        Animator.SetTrigger("TakeDamage");
        yield return new WaitForSeconds(HitTimer);
        IsHit = false;
    }

    void Die() {
        Animator.SetTrigger("Die");
        StartCoroutine(Dying());
    }

    IEnumerator Dying(){
        IsHit = true;
        MyRigidbody2D.velocity = new Vector2(0f,MyRigidbody2D.velocity.y);
        yield return new WaitForSeconds(5f);
    }

}
