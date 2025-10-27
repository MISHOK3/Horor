using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerController : MonoBehaviour
{

    [SerializeField] AudioClip jumping;
    [SerializeField] AudioSource sound;
    [SerializeField] AudioSource music;
    [SerializeField] float movementSpeed = 50f;
    [SerializeField] float shiftSpeed = 100f;
    [SerializeField] float jumpForce = 50f;
    [SerializeField] StaminaBar staminaBar;
    [SerializeField] Animator anim;
    bool isGrounded = true;
    float stamina = 5f;
    float currentSpeed;
    Rigidbody rb;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = movementSpeed;
        anim = GetComponent<Animator>();
        if (staminaBar != null)
        {
            staminaBar.SetMaxStamina(5f);
        }
        
        if (PlayerPrefs.HasKey("posX"))
        {
            float loadedX = PlayerPrefs.GetFloat("posX");
            float loadedY = PlayerPrefs.GetFloat("posY");
            float loadedZ = PlayerPrefs.GetFloat("posZ");
            transform.position = new Vector3(loadedX, loadedY, loadedZ);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        direction = new Vector3(moveHorizontal, 0.0f, moveVertical);
        direction = transform.TransformDirection(direction);

        if (direction.x != 0 || direction.z != 0)
        {
            if(!sound.isPlaying && isGrounded)
            {
                sound.Play();
            }
        }

        if (direction.x == 0 && direction.z == 0)
        {
            sound.Stop(); 
        }



        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGrounded = false;
            AudioSource.PlayClipAtPoint(jumping, transform.position);
        }



        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (stamina > 0)
            {
                stamina -= Time.deltaTime;
                currentSpeed = shiftSpeed;
            }
            else
            {
                currentSpeed = movementSpeed;
            }
        }

        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = movementSpeed;
        }

        if (stamina > 5f)
        {
            stamina = 5f;
        }
        else if (stamina < 0)
        {
            stamina = 0;
        }

        if (staminaBar != null)
        {
            staminaBar.SetStamina(stamina);;
        }

    }
    
    public void RestoreStamina(float amount)
    {
        stamina += amount;
        if (stamina > 5f) stamina = 5f;
    }

    void FixedUpdate()
    {
        Vector3 horizontalVelocity = new Vector3(direction.x, 0, direction.z) * currentSpeed;
        rb.velocity = new Vector3(horizontalVelocity.x, rb.velocity.y, horizontalVelocity.z);
    }

    void OnCollisionEnter (Collision collision)
    {
        isGrounded = true;
    }
}
