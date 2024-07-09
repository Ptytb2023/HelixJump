using UnityEngine;

namespace ScavengerColector
{
	[RequireComponent(typeof(Collider))]
	public class Scavenger : MonoBehaviour
	{
		private void OnTriggerEnter(Collider other) => 
			Destroy(other.gameObject);
	}
}