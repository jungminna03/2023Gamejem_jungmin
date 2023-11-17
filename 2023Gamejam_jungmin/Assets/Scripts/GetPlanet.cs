using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public enum PlanetName { MERCURY = 0, VENUS, EARTH, MARS, JUPITER, SATURN, URANUS, NEPTUNE, PLUTO, SPACEX }

public class GetPlanet : MonoBehaviour
{
    private Vector2 cosor_Position;
    private RaycastHit2D hit;

    [SerializeField]
    private Canvas fullCanvas;


    [SerializeField]
    private TextMeshProUGUI textbuyPrice;
    [SerializeField]
    private TextMeshProUGUI textsellPrice;
    [SerializeField]
    private TextMeshProUGUI textCount;
    [SerializeField]
    private TextMeshProUGUI textCoin;

    private void Update()
    {
        if (fullCanvas.gameObject.activeSelf == true) return;

        GetPlanetByMouse();
    }

    private void GetPlanetByMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cosor_Position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            hit = Physics2D.Raycast(cosor_Position, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Planet"))
            {
                fullCanvas.gameObject.SetActive(true);
                PlanetName planetName = hit.collider.gameObject.GetComponent<Planet>().m_PlanetName;
                SelectedPlanet(planetName);
                //Debug.Log(click_obj);
            }
        }
    }

    private void SelectedPlanet(PlanetName planetName)
    {
        textCoin.text = $"{FindObjectOfType<PlanetSetting>().gold}$" ;
        for (int i=0; i<10; i++)
        {
            PlanetSet p = FindObjectOfType<PlanetSetting>().planets[i];
            if (p.planetName== planetName)
            {
                textbuyPrice.text = $"{p.Price}$";
                textsellPrice.text = $"{p.Price-1}$";
                textCount.text = $"{p.Count}C";
                
            }
        }
        
    }

    public void FinshBuying()
    {
        fullCanvas.gameObject.SetActive(false);
    }
}
