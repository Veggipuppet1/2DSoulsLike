using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] public bool damageable = true;
    [SerializeField] float health = 10;
    [SerializeField] private LayerMask deathTraps;

    Rigidbody2D body;

    public void Damage(float damageAmount)
    {
        if(damageable){
            health -= damageAmount;
        }
    }

    public void OnDeath(){
        SceneManager.LoadScene("testScene");
    }

    public void knockback(Vector2 knockback) {
        Debug.Log("knockback");
        body.AddForce(knockback);
    }

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) OnDeath();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log($"Collision with player: {collision.gameObject.name} layer: {deathTraps.value}");
        // if(collision.CompareTag("DeathTrap")) OnDeath();
    }
}
