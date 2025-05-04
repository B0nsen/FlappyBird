using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private float health;
    [SerializeField]
    private float force = 250f;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        health = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * force);
        }
        this.transform.eulerAngles = new Vector3 (0, 0, rb.linearVelocityY*3f);
        health -= Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Food"))
        {
            GameObject.Destroy(collision.gameObject);
            health += Mathf.Clamp(health + 50f, 0f, 100f);
        }
    }
}
