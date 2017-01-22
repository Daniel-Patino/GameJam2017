using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Transform playerTrans;
    private Rigidbody rigidB;
    private SpriteRenderer spriteRender;


    private Color colorBegin;
    private Color colorEnd;
    private float Delay;

    private bool isInAir;
    private float oldV;
    private float newV;

    public Image healthbar;
    public float max_health = 100f;
    public float cur_health = 1f;

    public float speed = 0.5f;
    public float jumpDist = 450f;
    public float walkDist = 25f;
    public int maxSpeed = 8;

    private int dmgd = -1;

    void Start()
    {
        if (healthbar != null)
            Debug.Log(healthbar.fillAmount);

        colorBegin = GetComponent<SpriteRenderer>().color;
        colorEnd = new Color(colorBegin.r, colorBegin.g, colorBegin.b, 0.1f);
        Delay = 5;

        cur_health = max_health;
        isInAir = false;
        spriteRender = GetComponent<SpriteRenderer>();
        playerTrans = GetComponent<Transform>();
        rigidB = GetComponent<Rigidbody>();
        float oldV = playerTrans.position.y;
    }

    void OnCollisionEnter(Collision other)
    {
        isInAir = false;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGERED!");
        GameObject.Destroy(other);
        decreaseHealthLarge();
    }

    void decreaseHealthFallDeath()
    {
        cur_health = (cur_health - 1f) / max_health;

        if (healthbar != null)
            healthbar.fillAmount += cur_health;
        if (dmgd == -1)
            dmgd = 0;
    }

    void decreaseHealthSmall()
    {
        cur_health = (cur_health - 5f) / max_health;
        SetHealth(cur_health);
    }

    void decreaseHealthLarge()
    {
        cur_health = (cur_health - 15f) / max_health;
        SetHealth(cur_health);
    }

    void SetHealth(float health)
    {
        if (healthbar != null)
            Debug.Log("health before: " + healthbar.fillAmount + ", DMG: " + dmgd);

        if (healthbar != null && health < healthbar.fillAmount && dmgd == -1)
        {
            Debug.Log("REMOVING: " + health);
            healthbar.fillAmount += cur_health;
            dmgd = 0;
        }
        else if (healthbar != null && health >= healthbar.fillAmount)
        {
            healthbar.fillAmount = 0;
            dmgd = 0;
        }

        if (healthbar != null)
            Debug.Log("health after: " + healthbar.fillAmount + ", DMG: " + dmgd);
    }

    void FixedUpdate()
    {
        if (dmgd != -1)
        {
            dmgd++;
            if (dmgd >= 150)
            {
                dmgd = -1;
            }
            if (dmgd % 10 > 5)
            {
                spriteRender.color = Color.Lerp(colorBegin, colorEnd, Delay * 0.1f);
            }
            else
            {
                spriteRender.color = Color.Lerp(colorBegin, new Color(colorBegin.r, colorBegin.g, colorBegin.b, 1f), 1f);
            }
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        oldV = playerTrans.position.y;
        //		Debug.Log((oldV - newV) + ", isInAir: "+ isInAir);
        Vector3 jumpForce = new Vector3(0.0f, jumpDist, 0.0f);

        if (!isInAir)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rigidB.AddForce(jumpForce);
                isInAir = true;
            }
        }
        if (moveHorizontal < 0)
        {

            spriteRender.flipX = true;
            if (isInAir)
            {
                Vector3 walkForce = new Vector3(-1 * walkDist, 0.0f, 0.0f);
                rigidB.AddForce(walkForce);
            }
            else
            {
                Vector3 walkForce = new Vector3(-2 * walkDist, 0.0f, 0.0f);
                rigidB.AddForce(walkForce);
            }
        }
        else if (moveHorizontal > 0)
        {

            spriteRender.flipX = false;
            if (isInAir)
            {
                Vector3 walkForce = new Vector3(1 * walkDist, 0.0f, 0.0f);
                rigidB.AddForce(walkForce);
            }
            else
            {
                Vector3 walkForce = new Vector3(2 * walkDist, 0.0f, 0.0f);
                rigidB.AddForce(walkForce);
            }

        }

        if (rigidB.velocity.magnitude > maxSpeed)
        {
            rigidB.velocity = Vector3.ClampMagnitude(rigidB.velocity, maxSpeed);
        }

        if (playerTrans.position.y < -20)
        {
            decreaseHealthFallDeath();
        }

		if (healthbar.fillAmount == 0) {
			LevelManager.Instance.LoadScene ("GameOver");
		}


        //		Debug.Log ("Y: "+rigidB.velocity.y);


        //		Debug.Log ("X: "+rigidB.velocity.x);

        newV = playerTrans.position.y;
    }
}
