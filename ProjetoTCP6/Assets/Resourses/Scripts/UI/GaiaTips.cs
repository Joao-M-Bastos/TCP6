using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GaiaTips : MonoBehaviour, IInteractable
{
    Transform playerTransform;
    [SerializeField] TextMeshProUGUI dicasText;

    [SerializeField] string[] tips;

    public UnityAction<IInteractable> onInteractionComplete { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void EndInteraction()
    {

    }

    public void HasInteracted(Interactor interactor, out bool hasInteracted)
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
        if (playerTransform != null)
        {
            if (Vector3.Distance(this.transform.position, playerTransform.transform.position) < 5)
                dicasText.gameObject.SetActive(true);
            else
            {
                playerTransform = null;
                dicasText.gameObject.SetActive(false);
            }

        }
    }

    public void SetRandomText()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        dicasText.gameObject.SetActive(true);
        dicasText.text = tips[Random.Range(0, tips.Length)];
    }
}
