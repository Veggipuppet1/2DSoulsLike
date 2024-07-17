using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Transform attackTransform;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private float damageAmount = 1f;
    [SerializeField] private LayerMask attackableLayer;
    [SerializeField] private Transform weapon;
    [SerializeField] private float attackSpeed = 1000f;
    [SerializeField] private float rotationSpeed = 1000f;

    private RaycastHit2D[] hits;
    private bool isAttacking = false;
    private float rotated = 0f;
    private float startingRotation;
    private float attackDuration;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isAttacking) {
            if(Time.time < attackDuration) {
                Debug.Log("finished Attacking");
                isAttacking=false;
                weapon.Rotate(0f,0f,0f);
            }
            rotated += Time.deltaTime*rotationSpeed;
            weapon.Rotate(weapon.rotation.x, weapon.rotation.y, weapon.rotation.z-Time.deltaTime*rotationSpeed);
            // weapon.position = new Vector3(weapon.position.x, weapon.position.y, weapon.position.z-Time.deltaTime*rotationSpeed);
        } else if(Input.GetButtonDown("Fire1")){
            // Instantiate(attack,new Vector3(transform.position.x + 2,transform.position.y,transform.position.z),Quaternion.identity);
            // Attack();
            Debug.Log("attacking");
            isAttacking = true;
            startingRotation = weapon.position.z;
            attackDuration = Time.time + attackSpeed;
        }
    }

    private void Attack() {
        float startingRotation = weapon.position.z;
        float rotated = 0f;
        while (rotated < 180f)
        {
            Debug.Log("attacking" + rotated + " " + weapon.position.z);
            rotated += Time.deltaTime*rotationSpeed;
            weapon.position = new Vector3(weapon.position.x, weapon.position.y, weapon.position.z-Time.deltaTime*rotationSpeed);        
        }
        weapon.position = new Vector3(weapon.position.x, weapon.position.y, startingRotation);
    }

    // private void Attack() {
    //     hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0f, attackableLayer);

    //     Debug.Log(hits.Length);
    //     for (int i = 0; i < hits.Length; i++)
    //     {
    //         IDamageable iDamageable = hits[i].collider.gameObject.GetComponent<IDamageable>();
    //         Debug.Log(hits[i].collider.gameObject.name);
    //         if(iDamageable != null)  {
    //             iDamageable.Damage(damageAmount);
    //         }
    //     }
    // }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(attackTransform.position, attackRange);
    }
}
