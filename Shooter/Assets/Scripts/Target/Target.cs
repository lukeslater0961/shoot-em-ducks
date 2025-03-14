using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] float health = 10f;
    public int type = 0;

    public void    takeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            TargetSpawner.Instance.TargetDestroyed();
        }
    }
}
