using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] PlayerMovement move;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    void Attack()
    { 
        anim.SetTrigger("Attack");
    }
}
