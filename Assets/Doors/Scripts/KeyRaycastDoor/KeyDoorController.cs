using System.Collections;
using UnityEngine;

public class KeyDoorController : MonoBehaviour
{
    private Animator doorAnim;
    private bool doorOpen = false;

    [Header("Animation Names")]
    [SerializeField] private string openAnimationName = "DoorOpen";
    [SerializeField] private string closeAnimationName = "DoorClose";

    [Header("Door Locked UI")]
    [SerializeField] private int timeToShowUI = 1;
    [SerializeField] private GameObject showDoorLockedUI = null;

    [Header("Key Inventory")]
    [SerializeField] private KeyDoorInventory keyInventory = null;

    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if (keyInventory.hasSkeletonKey)
        {
            if (!doorOpen)
            {
                doorAnim.Play(openAnimationName, 0, 0.0f);
                doorOpen = true;
            }

            else
            {
                doorAnim.Play(closeAnimationName, 0, 0.0f);
                doorOpen = false;
            }
        }

        else
        {
            StartCoroutine(ShowDoorLocked());
        }
    }

    IEnumerator ShowDoorLocked()
    {
        showDoorLockedUI.SetActive(true);
        yield return new WaitForSeconds(timeToShowUI);
        showDoorLockedUI.SetActive(false);
    }
}
