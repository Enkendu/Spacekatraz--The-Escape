#pragma strict

public var firstPerson : Camera;
public var thirdPerson : Camera;

function Update ()
{
	if (Input.GetKey(KeyCode.F1))
	{
		firstPerson.camera.enabled = true;
		thirdPerson.camera.enabled = false;
	}
	
	if (Input.GetKey(KeyCode.F2))
	{
		firstPerson.camera.enabled = false;
		thirdPerson.camera.enabled = true;
	}
}