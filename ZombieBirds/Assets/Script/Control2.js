#pragma strict
 
/* Slingshot physics by save
Description: Put this script on the slingshot object.
Creation date: 2012-12-10
Last updated: 2012-12-10
*/
 
static var power : float = 15.0; //Additional power to shot
static var radius : float = 2.0; //Radius of clamp circle
static var sensitivity : float = .2; //Sensitivity of movement
 
private var myTransform : Transform; //Cached component
private var myRigidbody : Rigidbody; //Cached component
private var initPos : Vector3; //Initial position of slingshot object
private var shot : boolean = false; //Is the object shot?
private var resting : boolean = true; //Is the object resting?
 
function Start () 
{
	myTransform = transform;
	myRigidbody = rigidbody;
	myRigidbody.isKinematic = true;
	initPos = myTransform.position;
}
 
function Update () 
{
	CheckInput();
}
 
function CheckInput () 
{
	if (shot) 
		return;
	if (Input.GetAxis("Fire1")) 
	{
		var inputAxis : Vector2 = Vector2(Input.GetAxis("Mouse X")*sensitivity, Input.GetAxis("Mouse Y")*sensitivity);
		var newPos : Vector3 = Vector3(myTransform.position.x+inputAxis.x, myTransform.position.y+inputAxis.y, initPos.z);
		myTransform.position = CircleClamp(newPos, initPos, radius);
	} 
	else 
	{
		if (!shot && !resting) 
		{
			myRigidbody.isKinematic = false;
			myRigidbody.AddForce((initPos-myTransform.position)*power, ForceMode.Impulse);
			shot = true;
		} 
		else 
		{
			Vector3.Lerp(myTransform.position, initPos, 10*Time.deltaTime);
		}
	}
}
 
function CircleClamp (pos : Vector3, center : Vector3, rad : float) : Vector3 
{
	var offset : Vector2 = pos - center;
	var distance : float = offset.magnitude;
	if (distance<rad*.2) 
	{
		resting = true;
	} 
	else 
	{
		resting = false;
	}
	if (rad<distance) 
	{
		var direction : Vector2 = offset/distance;
		pos = center+direction*rad;
	}
		return pos;
}