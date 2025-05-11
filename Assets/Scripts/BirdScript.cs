using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdScript : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI triesTmp;
    private Rigidbody2D rb;
    public static float health;
    private float healthTimeout = 100.0f;
    [SerializeField]
    private float force = 250f;
    private int tries;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        health = 1.0f;
        tries = 3;
        triesTmp.text = tries.ToString();
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
        if (health < 0)
        {
            Lose();
            health = 1.0f;
        }
        
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
            Lose();
        }
    }

    private void Lose()
    {
        tries -= 1;
        if (tries > 0)
        {
            AlertScript.Show("Collision", "You hit an obstacle and lost a life", "Continue", DestroyerScript.ClearField);
        }
        else
        {
            AlertScript.Show("Collision", "Game over", "Restart", () => SceneManager.LoadScene(0));
        }
        triesTmp.text = tries.ToString();
    }
}
