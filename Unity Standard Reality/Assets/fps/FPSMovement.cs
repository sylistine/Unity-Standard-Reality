using UnityEngine;
using System.Collections;

public class FPSMovement : MonoBehaviour
{
	public float speed;
	
	private Camera hmd;
	private Transform hmdRoot;
	
	void Start ()
	{
		hmd = Camera.main;
		hmdRoot = hmd.transform.parent;
	}
	
	void Update ()
	{
		float v = Input.GetAxisRaw ("Vertical");
		float h = Input.GetAxisRaw ("Horizontal");
		
		Vector3 rootRight = hmdRoot.TransformDirection (Vector3.right);
		Vector3 rootForward = new Vector3(-rootRight.z, 0, rootRight.x);
		
		this.transform.position += (rootRight * h + rootForward * v).normalized * speed * Time.deltaTime;
	}
}
