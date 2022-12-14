
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement2d : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float speed;
    private bool canJump;
    private Rigidbody rb;
    [SerializeField] GameObject gun;
    [SerializeField] private Transform spawnCheckPoint;
    private float facing; //usung it later to make the player rotate and look booth ways

    [SerializeField] private GameObject cmCam;
    [SerializeField] private GameObject cmCamHillShot;
    [SerializeField] private GameObject cmHillStay;
    [SerializeField] private GameObject FinalCamView;

     private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gun.SetActive(false);
    }

    private void Update()
    {
        Vector2 movement = new Vector2(Input.GetAxis ( "Horizontal") * speed, 0);
        rb.velocity = new Vector2(movement.x, rb.velocity.y);
        
        //using the player's Rigidbody to rotate it based on which way it is moving with its input\/
        if (movement.x != 0)//if at any time we use horizontal inputs
        {//then set our facing float to equal the angle at which the player is moving in.
            facing = Mathf.Atan2(movement.x, 0) * Mathf.Rad2Deg;//calculating our horizontal inputs with nothing. Therefore, our code will recognize what direction the player is moving in on its horizontal axis.
            rb.rotation = Quaternion.Euler(0,facing,0);//using the player's Rigidbody and rotate its Y axis to stay updated with what our facing value is, which is just the player's movement calculated into an angle.
        }

        
        //jumping w rules
        bool grounded = Physics.Linecast(transform.position, groundCheck.position, groundLayer); //(,,) >>>The starting point of the linecast, the end point, and what layer the linecast is looking to detect.
        Debug.DrawLine (transform.position, groundCheck.position, Color.red); //drawing a line based of the prev line26

        if (grounded == true)
        { canJump = true; }
        else
        { canJump = false; }

        JumpyJumpo();
    }
    
    private void JumpyJumpo()
    {
        if (Input.GetButtonDown("Jump") && canJump == true)
        {
            canJump = false;
            rb.AddForce(Vector3.up * jumpForce) ;
        }
    }

    [SerializeField] int orbAmount = 0;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("collect"))
        { 
            orbAmount += 1; 
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(2);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (orbAmount == 4 && col.gameObject.CompareTag("nextL"))
        {
            SceneManager.LoadScene("Level2");
        }
        else if (orbAmount < 4 && col.gameObject.CompareTag("nextL"))
        {
            Debug.Log("jump off and try again");
        }
        
        if (col.gameObject.CompareTag("Respawn"))
        {
            SceneManager.LoadScene("StartLevel");
        }
        if (col.gameObject.CompareTag("gunBox"))
        {
            cmCam.SetActive(false); //switching cameras for enemies encounter
            Destroy(col.gameObject);
            gun.SetActive(true);
        }
        if (col.gameObject.CompareTag("checkPoint"))
        {
            transform.position = spawnCheckPoint.position;
            jumpForce += 150;
        }

        if (col.gameObject.CompareTag("camChange2"))
        {
            Destroy(col.gameObject);
            cmCam.SetActive(true); //changing back to main cam for a bit
        }

        if (col.gameObject.CompareTag("camChangeHill"))
        {
            Destroy(col.gameObject);
            cmCamHillShot.SetActive(true);
        }

        if (col.gameObject.CompareTag("camChange3"))
        {
            Destroy(col.gameObject);
            cmCamHillShot.SetActive(false);
            cmHillStay.SetActive(true);
        }

        if (col.gameObject.CompareTag("camChange5"))
        {
            Destroy(col.gameObject);
            cmHillStay.SetActive(false);
            FinalCamView.SetActive(true);
        }

        
    }
    }

