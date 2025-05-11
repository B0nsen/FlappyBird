using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public static float health;
    private float healthTimeout = 100.0f;
    [SerializeField]
    private float force = 250f;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        health = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * force);
        }
        this.transform.eulerAngles = new Vector3 (0, 0, rb.linearVelocityY*3f);
        health -= Time.deltaTime/healthTimeout;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Food"))
        {
            GameObject.Destroy(collision.gameObject);
            health = Mathf.Clamp01(health+10f/healthTimeout);
            CountScript.FoodCount--;
        }
        else if (collision.CompareTag("Food2"))
        {
            GameObject.Destroy(collision.gameObject);
            health = Mathf.Clamp01(health + 20f / healthTimeout);
            CountScript.FoodCount--;
        }
        else if (collision.CompareTag("Pipe"))
        {
            AlertScript.Show("Collision", "You hit an obstacle and lost a life");
        }
    }
}
