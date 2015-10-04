using UnityEngine;
using System.Collections;

public class GroundGenerator : MonoBehaviour
{

	public GameObject player;
	public GameObject groundFeature;
	public Vector2 lastPosition;
	public float generateDistanceInterval = 5.0f;
	public int numberOfGroundObjects = 1;
	public int numberVariance = 5;
	public float featureDistance = 25f;
	private int zLayer = 1;

	void Update ()
	{
		if (player) {
			if (Vector2.Distance (lastPosition, player.transform.position) > generateDistanceInterval) {
				lastPosition = player.transform.position;
				CreateGround ();
			}
		}
	}

	void CreateGround ()
	{
		int numberOfNewObjects = numberOfGroundObjects + Random.Range (0, numberVariance);
		float angleBetweenEach = 360f / numberOfNewObjects;
		Vector2 direction = Random.insideUnitCircle.normalized;
		Vector2 playerPosition = player.transform.position;
		for (int i = 0; i < numberOfNewObjects; i++) {
			Vector3 featurePosition = (Vector3)playerPosition + (Vector3)direction * featureDistance + transform.position;
			featurePosition.z -= zLayer / 100f;
			zLayer++;
			if (zLayer > 16) {
				zLayer = 0;
			}
			direction = Quaternion.AngleAxis (angleBetweenEach, Vector3.forward) * direction;
			Factory.create.ByReference (groundFeature, featurePosition, Quaternion.AngleAxis (Random.Range (0, 360), Vector3.forward));
		}
	}
}
