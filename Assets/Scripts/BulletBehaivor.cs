using UnityEngine;

public class BulletBehaivor : MonoBehaviour
{

    public Animator anim;

    private bool shot;
    private float xSpeed;
    private float ySpeed;

    // Start is called before the first frame update
    void Start()
    {
        shot = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shot){
            this.transform.position += new Vector3 ( xSpeed*Time.deltaTime, ySpeed*Time.deltaTime, 0 );
        }
    }

    public void Shoot(float xSpeed, float ySpeed){
        this.xSpeed = xSpeed;
        this.ySpeed = ySpeed;

        this.transform.parent = null;

        shot = true;
        anim.SetBool("Shot",true);
    }

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Enemy"){
            Debug.Log("hit");
            Destroy(this);
        }
    }
}
