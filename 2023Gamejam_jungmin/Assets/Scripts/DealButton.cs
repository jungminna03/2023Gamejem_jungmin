using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DealButton : MonoBehaviour
{
    private Vector2 cosor_Position;
    private RaycastHit2D hit;
    [SerializeField]GameObject fullCanvas;

    private void Update()
    {
        OnDealButton();
    }
    public void OnDealButton()
    {
        if (fullCanvas.gameObject.activeSelf != true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                cosor_Position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                hit = Physics2D.Raycast(cosor_Position, Vector2.zero);
                if (hit.collider != null && hit.collider.CompareTag("Planet"))
                {
                    fullCanvas.GetComponent<PurchaseWindow>().GetInfo(gameObject.GetComponent<Planet>());
                    fullCanvas.SetActive(true);
                }
            }
        }
    }
}
