using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ RequireComponent(typeof(GameManager))]
public class GayListener : MonoBehaviour
{
    [SerializeField] private CameraRayanGossling component;

    private void Awake() 
    {
        GameManager gameManager = GetComponent<GameManager>();
        IGameListener[] listeners = GetComponentsInChildren<IGameListener>();

        foreach (var listener in listeners)
        {
            gameManager.AddListener(listener);
        }
        gameManager.AddListener(component.GetComponent<IGameStartListener>());
    }
}
