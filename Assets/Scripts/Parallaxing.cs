using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {

	public Transform[] backgrounds;			// Array (list) of all the back- and foregrounds to be parallaxed
	private float[] parallaxScales;			// The proportion of the camera's movement to move the backgrounds by
	public float smoothing = 1f;			// How smooth the parallax is going to be. Make sure to set this above 0

	private Transform cam;					// reference to the main cameras transform
	private Vector3 previousCamPos;			// the position of the camera in the previous frame

	// Is called before Start(). Great for references.
	void Awake () {
		// set up camera the reference
		cam = Camera.main.transform;
	}

	// Use this for initialization
	void Start () {
		// The previous frame had the current frame's camera position
		previousCamPos = cam.position;

		// asigning coresponding parallaxScales
		parallaxScales = new float[backgrounds.Length];
		for (int i = 0; i < backgrounds.Length; i++) {
			parallaxScales[i] = backgrounds[i].position.z*-1;
		}
	}
	
	// Update is called once per frame
	void Update () {

		// for each background
		for (int i = 0; i < backgrounds.Length; i++) {
			// the parallax is the opposite of the camera movement because the previous frame multiplied by the scale
			float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

			// set a target x position which is the current position plus the parallax
			float backgroundTargetPosX = backgrounds[i].position.x + parallax;

			// create a target position which is the background's current position with it's target x position
			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

			// fade between current position and the target position using lerp
			backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}

		// set the previousCamPos to the camera's position at the end of the frame
		previousCamPos = cam.position;
	}
}
