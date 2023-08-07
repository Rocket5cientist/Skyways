using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityBehavior : MonoBehaviour
{
    [SerializeField] private Button cityMarker;
    [SerializeField] private Canvas worldCanvas;

    [SerializeField] private GameObject earth;

    private void Start() {
        gameObject.SetActive(true);
    }

    private void Awake() {
        Vector3 newPosition = transform.position + (transform.position - earth.transform.position).normalized * 1;

        Button cityButton = Instantiate(cityMarker, newPosition, Quaternion.LookRotation(transform.position - earth.transform.position), worldCanvas.transform);
        cityButton.GetComponent<UIBehavior>().cityName = transform.name;
    }

}
