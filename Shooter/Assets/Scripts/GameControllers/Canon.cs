using UnityEngine;
using UnityEngine.InputSystem;

public class Canon : MonoBehaviour
{
    [SerializeField] GameManager    gameManager;
    [SerializeField] Camera         gameCamera;

    [SerializeField] float          damage = 10f;
    [SerializeField] int            range = 100;
    [SerializeField] int            gameDifficulty;


    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.inGame && Input.GetButtonDown("Fire1"))
            Fire();
    }


    void    Fire()
    {
        RaycastHit hit;

        if (Physics.Raycast(gameCamera.transform.position, gameCamera.transform.forward, out hit, range, 1 << 3))
                doDamage(hit.transform);
		else
			GameManager.instance.ReduceHealth();

    }

    void    doDamage(Transform targetTransform)
    {
        Target target = targetTransform.GetComponent<Target>();
        target.takeDamage(damage);
        gameManager.addPoints(target.type);
    }
}
