using UnityEngine;

public class WeaponBehaivor : MonoBehaviour
{

    public int noOfBullets;
    public float bulletSpeed;
    public float bulletDamage;
    
    private GameObject[] magazine;
    private int bulletsLoaded;

    private float xAxis;
    private float yAxis;
    private float sin;
    private float cos;
    private float hipotenus;

    // Start is called before the first frame update
    void Start()
    {
        bulletsLoaded = 0;
        this.setGun();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)){
            Reload();
        }
    }

    void setGun(){
        magazine = new GameObject[noOfBullets];
        Reload();
    }

    public void Shoot(Vector3 target){

        if (bulletsLoaded == 0){
            return;
        }

        Vector3 pos = this.transform.position;
        // calculate the xAxis and yAxis
        xAxis = target.x - pos.x;
        yAxis = target.y - pos.y;

        hipotenus = Mathf.Sqrt(xAxis*xAxis + yAxis*yAxis);
        sin = xAxis / hipotenus;
        cos = yAxis / hipotenus;

        // now the needed trigonometric values are known, 
        // so they can be multiplied with the bulletSpeed and the angle will be set

        // then call the Shoot() method for the next bullet in line, with the calculated parameters

        (magazine[bulletsLoaded-1].GetComponent<BulletBehaivor>()).Shoot( bulletSpeed*sin, bulletSpeed*cos );
        magazine[bulletsLoaded-1] = null;
        bulletsLoaded--;
    }

    void Reload(){
        for (int i = bulletsLoaded; i < noOfBullets; i++){
            magazine[i] = GameObject.Instantiate (Resources.Load ("Bullet"), this.transform) as GameObject;          
            bulletsLoaded++;  
        }
    }
}
