using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float movementSpeed;

    private float xSpeed;
    private float ySpeed;
    private float diagonalSpeed;

    private Vector3 cursorPosition;

    // Start is called before the first frame update
    void Start()
    {
        xSpeed = 0;
        ySpeed = 0;
        diagonalSpeed = movementSpeed / Mathf.Sqrt(2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // movement in Y axis
        if (Input.GetKey(KeyCode.W)){
            ySpeed += movementSpeed;
        }
        if (Input.GetKey(KeyCode.S)){
            ySpeed -=movementSpeed;
        }
        //movement in X axis
        if (Input.GetKey(KeyCode.D)){
            xSpeed += movementSpeed;
        }
        if (Input.GetKey(KeyCode.A)){
            xSpeed -= movementSpeed;
        }

        // if there is a diagonal movement
        if ( (xSpeed != 0) && (ySpeed != 0) ){
            // apply mathematics
            xSpeed = diagonalSpeed * (xSpeed / movementSpeed); // latter part is to determine the sign
            ySpeed = diagonalSpeed * (ySpeed / movementSpeed); // latter part is to determine the sign
        }

        this.transform.position = this.transform.position + new Vector3(xSpeed*Time.deltaTime,ySpeed*Time.deltaTime,0);

        xSpeed = 0;
        ySpeed = 0;
    }

}
