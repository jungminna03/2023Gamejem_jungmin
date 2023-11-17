using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum PlanetName { MERCURY = 0, VENUS, EARTH, MARS, JUPITER, SATURN, URANUS, NEPTUNE, PLUTO, SPACEX }

public class GetPlanet : MonoBehaviour
{
    private Vector2 cosor_Position;
    private RaycastHit2D hit;

    [SerializeField]
    private Canvas fullCanvas;

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
        Debug.Log(planetName);
        
    }

    public void FinshBuying()
    {
        fullCanvas.gameObject.SetActive(false);
    }
}
