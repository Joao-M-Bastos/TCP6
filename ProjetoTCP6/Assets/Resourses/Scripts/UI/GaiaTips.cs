using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GaiaTips : MonoBehaviour, IInteractable
{
    [SerializeField] TextMeshProUGUI dicasText;

    [SerializeField] string[] tips;

    public UnityAction<IInteractable> onInteractionComplete { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void EndInteraction()
    {

    }

    public void HasInteracted(out bool hasInteracted)
    {
        hasInteracted = false;
    }

    public void Interact(Interactor interactor, out bool interactionSuccess)
    {
        SetRandomText();
        interactionSuccess = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        dicasText.gameObject.SetActive(false);
    }

    private void Update()
    {
        GameObject playerTransform = GameObject.FindGameObjectWithTag("Player");

        if(playerTransform != null)
        {
            if(Vector3.Distance(this.transform.position, playerTransform.transform.position) > 5)
            {
                dicasText.gameObject.SetActive(false);
            }
        }
        else
        {
            dicasText.gameObject.SetActive(false);
        }
    }

    public void SetRandomText()
    {
        dicasText.gameObject.SetActive(true);
        dicasText.text = tips[Random.Range(0, tips.Length)];
    }
}
