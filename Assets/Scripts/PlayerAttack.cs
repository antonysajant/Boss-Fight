using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] PlayerMovement move;
    [SerializeField] float attackRange = 1f;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] Transform attackPoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack0();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Attack();
        }
    }

    void Attack0()
    { 
        anim.SetTrigger("Attack0");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("HIT!");
        }
    }

    void Attack()
    {
        anim.SetTrigger("Attack");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
