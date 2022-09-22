using System;
using System.Text;
using UnityEngine;

public class AmmoSwitch : MonoBehaviour
{
    public GameObject changeAmmo;
    public GameObject player;
    public GameObject emptyMagazine;
    public GameObject fullMagazine;
    public GameObject interactZone;
    private PlayerMovement _playerMovement;
    [HideInInspector]
    public bool hasAmmo;

    [SerializeField] 
    private GameObject canvas;

    void Start()
    {
        _playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E) && !_playerMovement.gunLoaded)
        {
            interactZone.SetActive(false);
            changeAmmo.SetActive(true);
            emptyMagazine.SetActive(true);
            fullMagazine.SetActive(false);
            hasAmmo = true;
        }
    }
}
