using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SwipeEffect : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector3 cardInitialPosition;
    private float distanceMoved;
    private bool swipeLeft;
    //public event Action cardMoved;
    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition = new Vector2(transform.localPosition.x + eventData.delta.x, transform.localPosition.y);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        cardInitialPosition = transform.localPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        distanceMoved = Mathf.Abs(transform.localPosition.x - cardInitialPosition.x);
        if (distanceMoved < 0.4 * Screen.width)
        {
            transform.localPosition = cardInitialPosition;
        }
        else
        {
            if(transform.localPosition.x > cardInitialPosition.x)
            {
                swipeLeft = false;
            }
            else
            {
                swipeLeft = true;
            }
           // cardMoved?.Invoke();
            StartCoroutine(MovedCard());
        }
        
    }
    public void SwipedLeft(bool swipeLeft)
    {

    }

    private IEnumerator MovedCard()
    {
        float time = 0;
        while(GetComponent<Image>().color != new Color(1, 1, 1, 0))
        {
            time += Time.deltaTime;
            if (swipeLeft)
            {
                transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x, transform.localPosition.x-Screen.width, 4*time), 
                    transform.localPosition.y, 0);
            }
            else
            {
                transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x, transform.localPosition.x + Screen.width, 4 * time),
                    transform.localPosition.y, 0);
            }
            GetComponent<Image>().color = new Color(1, 1, 1, Mathf.SmoothStep(1,0,4*time));
            yield return null;
        }
   
        Destroy(gameObject);
    }
}
