using UnityEngine;
using UnityEngine.InputSystem;

public class Canon : MonoBehaviour
{
    [SerializeField] float          damage = 10f;
    [SerializeField] int            range = 100;
    [SerializeField] Camera         camera;
    [SerializeField] GameManager    gameManager;
    [SerializeField] int            gameDifficulty;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Fire();
    }


    void    Fire()
    {
        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range, 1 << 3))
                doDamage(hit.transform);
    }

    void    doDamage(Transform targetTransform)
    {
        Target target = targetTransform.GetComponent<Target>();
        target.takeDamage(damage);
        gameManager.addPoints(target.type);
    }
}
