using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPlacement : MonoBehaviour
{
    public CardData currTower;
    [SerializeField]
    Camera mainCam;

    private void Start() {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public bool SpawnTowerAtPos(Vector3 touchPos) {
        if (currTower == null) {
            return false;
        }
        Ray ray = mainCam.ScreenPointToRay(touchPos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("TowerSpawn"))
            && !hit.transform.CompareTag("Tower")
            ) {
            GameObject tower = Instantiate(currTower.towerPrefab, hit.point, Quaternion.identity);
            tower.GetComponent<TowerController>().Setup(currTower.SetupHealth,currTower.SetupAmmo,currTower.range,currTower.fireRate,currTower.Damage,currTower.damageType,currTower.tier,currTower.rariety);
            //Destroy(currTower.gameObject);
            currTower = null;
            return true;
        } else {
            return false;
        }
    }
}

