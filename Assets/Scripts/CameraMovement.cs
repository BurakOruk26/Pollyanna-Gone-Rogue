using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    
    public Transform player;
    public float margin;
    private float cameraSizeX = 16 / 2;
    private float cameraSizeY = 9 / 2;
    private float xMargin;
    private float yMargin;

    private float movementSpeed;
    public GameObject playerMovement; // the script
    private float xSpeed;
    private float ySpeed;
    private int sign;

    private const byte xAxis = 0;
    private const byte yAxis = 1;

    // Start is called before the first frame update
    void Start()
    {
        xMargin = margin;
        yMargin = margin * 9 / 16;

        movementSpeed = (playerMovement.GetComponent<PlayerMovement>()).movementSpeed;

        xSpeed = 0;
        ySpeed = 0;
        sign = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((cameraSizeX - Mathf.Abs(player.position.x - this.transform.position.x)) <= xMargin){
            this.FollowPlayer(xAxis);
        }
        else if ((cameraSizeY - Mathf.Abs(player.position.y - this.transform.position.y)) <= yMargin){
            this.FollowPlayer(yAxis);
        }
    }

    void FollowPlayer(byte axis){
        if (axis == xAxis){
            if (player.position.x < this.transform.position.x){
                sign = -1;
            }
            xSpeed = movementSpeed * sign;
            ySpeed = 0;
        }
        else{
            if (player.position.y < this.transform.position.y){
                sign = -1;
            }
            ySpeed = movementSpeed * sign;
            xSpeed = 0;
        }

        this.transform.position = this.transform.position + (new Vector3(xSpeed*Time.deltaTime,ySpeed*Time.deltaTime,0));

        xSpeed = 0;
        ySpeed = 0;
        sign = 1;
    }

    void OnTriggerEnter2D(Collider2D collision){
        
    }
}
