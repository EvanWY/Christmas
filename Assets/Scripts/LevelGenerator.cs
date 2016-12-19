using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {

	public int RandomSeed;
	public GameObject[] BuildingPrefabs;
	public GameObject playerCharacter;

	List<GameObject> buildings = new List<GameObject>();
	public int GeneratedBuildingNum;
	public float BuildingDeleteOffset;
	public float SlopeTangent;
	public float MaxBuildingDistance;

	public Transform buildingBase;

	public float[] BuildingTypeRandomRange;

	int buildingIndex = 0;

	void generateBuilding() {
		
		GameObject newBuilding = Instantiate(BuildingPrefabs.RandElement());
		GameObject lastBuilding = buildings.Count > 0 ? buildings[buildings.Count - 1] : null;


		BuildingType newBuildingType;

		float rnd = Random.Range(0f, 1f);
		if (rnd < BuildingTypeRandomRange[0] || buildingIndex < 7) {
			newBuildingType = BuildingType.None;
		}
		else if (rnd < BuildingTypeRandomRange[1]) {
			newBuildingType = BuildingType.Smoke;
		}
		else {
			newBuildingType = BuildingType.Gift;
		}

		newBuilding.GetComponent<BuildingController>().Init(newBuildingType, 0);

		newBuilding.transform.SetParent(buildingBase);

		if (lastBuilding != null) {
			float minDist = Mathf.Max(
				0.5f * (newBuilding.GetComponent<BuildingController>().Width + lastBuilding.GetComponent<BuildingController>().Width),
				(1f / SlopeTangent) * Mathf.Abs(newBuilding.GetComponent<BuildingController>().Height - lastBuilding.GetComponent<BuildingController>().Height));

			float maxDist = minDist + MaxBuildingDistance;

			newBuilding.transform.localPosition = Vector3.right * (Mathf.Lerp(minDist, maxDist, Mathf.Clamp01(Random.Range(-3f, 1f))) + lastBuilding.transform.localPosition.x);
		}
		else {
			newBuilding.transform.localPosition = Vector3.zero;
		}
		
		buildings.Add(newBuilding);
		buildingIndex++;
	}

	void deleteBuilding() {
		var deletedBuilding = buildings[0];
		Destroy(deletedBuilding);
		buildings.RemoveAt(0);
	}

	void Start() {
		Random.InitState(RandomSeed);

		for (int i=0; i<GeneratedBuildingNum; i++) {
			generateBuilding();
		}
	}

	void Update() {
		if (buildings[0] != null && buildings[0].transform.position.x < playerCharacter.transform.position.x - BuildingDeleteOffset) {
			deleteBuilding();
			generateBuilding();
		}
	}
}
