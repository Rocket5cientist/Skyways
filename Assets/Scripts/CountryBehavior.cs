using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class CountryBehavior : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countryText;

    Renderer rend;
    [SerializeField] private EarthMovement em;

    [SerializeField] private Material standard;
    [SerializeField] private Material selected;

    private void Start() {
        rend = GetComponent<Renderer>();
        rend.material = standard;
    }

    private void OnMouseEnter() {
        countryText.text = transform.name;
        rend.material = selected;      
    }

    private void OnMouseExit() {
        rend.material = standard;
    }

}
