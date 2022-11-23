using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    Rigidbody rb;
    // this calls the physics property, rigidbody, which was added in the unity game engine for the cube object
    // this has been set to be represented as "rb"

    public GameObject winText;
    // this global variable has been made to let the code know about the text that has been created in the unity game engine
    // to create the text, go into hierarchy, go to the dropdown menu, select UI, select Legacy, and select Text
    // go into the three vertical buttons in the rect transform, select reset to reset the x pos of the text, and change the contents inside the text to whatever you want
    // since this code wants the text to appear when something happens, make sure you uncheck the box on the very top of the inspector tab

    float xInput;
    // variable representing the left and right arrow keys
    float zInput;
    // variable representing the up and down arrow keys
    public float speed;
    // variable representing the speed the cube will go once the arrow keys are pressed
    // to set the speed, go into the inspector tab, go to the script, and set the speed to whatever you want

    // Start is called before the first frame update
    void Start(){
        // Destroy(gameObject, 3f);
        // this will destroy the cube object in three seconds (f representing float)

        rb = GetComponent<Rigidbody>();
        // this is how to access the rigidbody property
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            // Destroy(gameObject);
            // this function destroys the cube object when the user's spacebar input is detected

            // the higher the number, the higher up the object will go
            rb.AddForce(Vector3.up * 150);
            // this will make the cube shoot up with the force of 150 when the spacebar input has been detected
            // the cube will then return to its original spot due to the unity engine's realistic replication of gravity
        }

        // rb.velocity = Vector3.forward * 20f;
        // this will make the cube go forward with the velocity of 20
        // if you do not want the cube to rotate while going forward, go into the rigidbody property in the unity game engine, click constraints, and click the x position checkbox

        // *NOTE* - IF THE STARTING GAME OBJECT GETS DESTROYED, THIS IF STATEMENT WILL NOT WORK!!!
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene("Level 2");
            // after adding "using UnityEngine.SceneManagement;" on the top to access all the scenes added in the unity game engine, whenever the R key is detected,
            // the project will immediately go to the second scene
        }

        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        // make sure you constrain the x, y, and z axes so the cube doesn't uncontrollably fly out of the map
        rb.AddForce(xInput * speed, 0, zInput * speed);
        // this multiplies the left and arrow key inputs to the speed and the up and down arrow key inputs to the speed
        // 0 represents the force of the y-direction (WE DO NOT DO ANYTHING TO THE Y-AXIS)
        // this is how the speed will be implemented into the code
    }

    private void OnMouseDown(){
        Destroy(gameObject);
        // this function destroys the cube object when the user's mouse click is detected
    }

    private void OnCollisionEnter(Collision collision){
        // to give an object an enemy tag, click on the object in the hierarchy tab, go to the inspector tab, click the tag dropdown area on the top,
        // click add tag, and make sure you name it exactly as you named it in the code

        if(collision.gameObject.tag == "Enemy"){
            // Destroy(gameObject);
            // this will destroy the object hit by the other object

            Destroy(collision.gameObject);
            // this will destroy the object that hit the other object

            winText.SetActive(true);
            // as soon as the object has collided with the other object, the win text will appear
        }
    }
}