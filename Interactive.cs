using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace WasaaMP {
public class Interactive : MonoBehaviourPun {
    // Start is called before the first frame update

    MonoBehaviourPun support = null ;
    public Rigidbody rb;

    void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate () {
        rb.velocity=new Vector3(0, 0, 0);
        
    }
    void OnTriggerEnter (Collider other) {
        print (name + " : OnCollisionEnter") ;
		var hit = other.gameObject ;
		var cursor = hit.GetComponent<CursorTool> () ;
		if (cursor != null) {
			Renderer renderer = GetComponentInChildren <Renderer> () ;
		    renderer.material.color = Color.blue ;
		}
	}
    
    void OnTriggerExit (Collider other) {
        print (name + " : OnCollisionExit") ;
		var hit = other.gameObject ;
		var cursor = hit.GetComponent<CursorTool> () ;
		if (cursor != null) {
			Renderer renderer = GetComponentInChildren <Renderer> () ;
		    renderer.material.color = Color.white ;
		}
	}

    public void SetSupport (MonoBehaviourPun support) {
        this.support = support ;
        if (support != null) {
            transform.SetParent (support.transform) ;
        } else {
            transform.SetParent (null) ;
        }
    }

    public void RemoveSupport () {
        transform.SetParent (null) ;
        support = null ;
    }

    public MonoBehaviourPun GetSupport () {
        return support ;
    }
}

}
