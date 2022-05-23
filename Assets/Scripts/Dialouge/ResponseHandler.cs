using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class ResponseHandler : MonoBehaviour
{
    [SerializeField] private RectTransform responseBox;
    [SerializeField] private RectTransform responseButtonTemplate;
    [SerializeField] private RectTransform responseContainer;

    private DialougeManager dialougeManager;
    private ResponseEvent[] responseEvents; 

    private List<GameObject> tempResponseButtons = new List<GameObject>();

    private void Start()
    {
        dialougeManager = GetComponent<DialougeManager>(); 
    }

    public void AddResponseEvents(ResponseEvent[] responseEvents)
    {
        this.responseEvents = responseEvents; 
    }

    public void ShowResponses(Response[] responses)
    {
        float responseBoxHeigth = 0;

        for (int i = 0; i < responses.Length; i++) 
        {
            Response response = responses[i];
            int responseIndex = i; 

            GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, responseContainer);
            responseButton.gameObject.SetActive(true);
            responseButton.GetComponent<TMP_Text>().text = response.ResponseText;
            responseButton.GetComponent<Button>().onClick.AddListener(() => OnPickedResponse(response, responseIndex));

            tempResponseButtons.Add(responseButton);

            responseBoxHeigth += responseButtonTemplate.sizeDelta.y;
        }

        responseBox.sizeDelta = new Vector2(responseBox.sizeDelta.x, responseBoxHeigth);
        responseBox.gameObject.SetActive(true);
    }

    private void OnPickedResponse(Response response, int responseIndex)
    {
        responseBox.gameObject.SetActive(false);

        foreach (GameObject button in tempResponseButtons)
        {
            Destroy(button);
        }
        tempResponseButtons.Clear();

        if (responseEvents != null && responseIndex <= responseEvents.Length)
        {
            responseEvents[responseIndex].OnPickedResponse?.Invoke();
        }

        responseEvents = null;

        if (response.DialougeObject)
        {
            dialougeManager.ShowDialouge(response.DialougeObject);
        }
        else 
        {
            dialougeManager.CloseDialougeBox(); 
        }

        dialougeManager.ShowDialouge(response.DialougeObject);
    }
}