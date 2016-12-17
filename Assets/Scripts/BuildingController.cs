using UnityEngine;
using System.Collections;

public class BuildingController : MonoBehaviour {

	public float Width;
	public float Height;

	public BuildingType buildingType;


	public void Init(BuildingType type, int orderInLayer) {
		buildingType = type;

		switch (type) {
			case BuildingType.None:
				transform.Find("Smoke").gameObject.SetActive(false);
				transform.Find("Gift").gameObject.SetActive(false);
				break;
			case BuildingType.Smoke:
				transform.Find("Smoke").gameObject.SetActive(true);
				transform.Find("Gift").gameObject.SetActive(false);
				break;
			case BuildingType.Gift:
				transform.Find("Smoke").gameObject.SetActive(false);
				transform.Find("Gift").gameObject.SetActive(true);
				break;
		}
	}
}

public enum BuildingType {
	None,
	Smoke,
	Gift,
}