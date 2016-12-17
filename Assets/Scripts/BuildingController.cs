using UnityEngine;
using System.Collections;

public class BuildingController : MonoBehaviour {

	public float Width;
	public float Height;

	public void Init(BuildingType type, int orderInLayer) {

	}
}

public enum BuildingType {
	None,
	Smoke,
	Gift,
}