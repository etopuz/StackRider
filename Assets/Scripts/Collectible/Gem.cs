using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SimpleCollectibleScript : MonoBehaviour, ICollectible
{

	[Header("Rotation")]
	[SerializeField] private bool rotate; // do you want it to rotate?
	[SerializeField] private float rotationSpeed;
	

	void Update () {

		if (rotate)
			transform.Rotate (Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

	}

	public void OnCollect()
	{
		AudioManager.Instance.PlayCollectAudio(transform.position);
		Destroy(gameObject);
	}
}
