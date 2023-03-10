using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    private GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        weapon = this.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update(){

        if (Input.GetMouseButtonDown(0)){ // if left mouse button is clicked
            // pass the cursor's position relative to world, to the Shoot() method of the weapon
            weapon.GetComponent<WeaponBehaivor>().Shoot( Camera.main.ScreenToWorldPoint(Input.mousePosition) );
        }
    }
}
