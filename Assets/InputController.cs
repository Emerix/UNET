using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class InputController : NetworkBehaviour {

	[Command]
	public void CmdJump()
	{   
		Debug.Log("running on server");
		GetComponent<Rigidbody>().AddForce(new Vector3(0,5,0),ForceMode.Impulse);
	}
	
	[ClientCallback]
	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			RaycastHit h;
			Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(r,out h))
			{
				if(h.transform == transform)
				{
					CmdJump();
				}
			}
		}
		
	}
}
