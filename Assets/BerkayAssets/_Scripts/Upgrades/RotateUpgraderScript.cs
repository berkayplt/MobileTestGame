using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateUpgraderScript : MonoBehaviour, Iinteractible
{
    public void Interact()
    {
        OpenUpgrader();
    }

    private void OpenUpgrader()
    {
        PlayerManager.Instance.OpenUpgradePart();
        Destroy(gameObject);
    }
}
