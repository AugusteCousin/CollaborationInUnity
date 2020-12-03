using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerStick : MonoBehaviour
{
    private GameObject handle1, handle2;
    private GameObject[] balloons;

    private Vector3 translateZ=new Vector3(0f, 0f, 0.6f);

    private bool displayMessage = false;
    private float displayTime = 3;
    private string message="what";
    private GameObject poppedMessage;
    private GameObject allPoppedMessage;

    // Start is called before the first frame update
    void Start()
    {
        handle1=GameObject.Find("handle1").gameObject;
        handle2=GameObject.Find("handle2").gameObject;
        poppedMessage=GameObject.Find("popped").gameObject;
        poppedMessage.SetActive(false);
        
        allPoppedMessage=GameObject.Find("allPopped").gameObject;
        allPoppedMessage.SetActive(false);
        //this.GetComponent<Rigidbody>().useGravity=false;
        balloons=GameObject.FindGameObjectsWithTag("Balloon");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition=new Vector3((handle1.transform.position.x+handle2.transform.position.x)/2, (handle1.transform.position.y+handle2.transform.position.y)/2, (handle1.transform.position.z+handle2.transform.position.z)/2);
        this.transform.LookAt(handle1.transform.position);

        if (displayMessage){
            displayTime-=Time.deltaTime;
            if (displayTime<=0.0){
                displayMessage=false;
                poppedMessage.SetActive(false);
            }

        }
        balloons=GameObject.FindGameObjectsWithTag("Balloon");
        if (balloons.Length<1){
            allPoppedMessage.SetActive(true);
        }
        
        
        //if handle1 has been caught by user
        // if (!this.transform.Find("handle1")){
        //     this.transform.position=handle1.transform.position;
        //     this.transform.Translate(new Vector3(0f, 0f, -3f));
        //     this.transform.rotation=handle1.transform.rotation;
        // }
        // if (!this.transform.Find("handle2")){
        //     this.transform.position=handle2.transform.position;
        //     this.transform.Translate(new Vector3(0f, 0f, 3f));
        //     this.transform.rotation=handle2.transform.rotation;
        // }
        
    }

    void OnTriggerEnter (Collider other) {

        if (other.gameObject.tag == "Balloon")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            print("STONKS");
            Destroy(other.gameObject);
            displayMessage=true;
            displayTime=3;
            if (balloons.Length>1){
                poppedMessage.SetActive(true);
            }
        }
	}
    
}
