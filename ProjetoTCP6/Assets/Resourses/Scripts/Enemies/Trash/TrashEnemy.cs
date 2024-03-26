using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrashEnemy : BaseEnemy
{
    [SerializeField] GameObject trashCorpse;

    public void GenerateCorpse()
    {
        Instantiate(trashCorpse, transform.position, transform.rotation);
    }
}
