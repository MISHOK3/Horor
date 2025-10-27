using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    [SerializeField] protected float attackDistance;  
    [SerializeField] float speed;
    [SerializeField] float detectionDistance;
    protected GameObject player;    
    protected Animator anim;
    protected Rigidbody rb;
    protected float distance;
    protected float timer;
    bool dead = false;
    float patrolTimer;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject; 
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (!dead)
        {
            
        }
    }
    
    private void FixedUpdate()
    {
        if (!dead)
        {
            Move();
        }
    }

    public void Move()
    {
        if (distance < detectionDistance && distance > attackDistance)
        {
            transform.LookAt(player.transform);
            Debug.Log("Run animation ON");
            anim.SetBool("Run", true);
            rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
        }
        else if (distance > detectionDistance)
        {
            anim.SetBool("Run", true);

            // Двигаем монстра вперёд
            rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);

            patrolTimer += Time.deltaTime;

            // Меняем направление каждые 10 секунд
            if (patrolTimer > 7)
            {
                // Поворот на 90 градусов по часовой стрелке
                transform.Rotate(new Vector3(0, 180, 0));
                patrolTimer = 0;
            }
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
