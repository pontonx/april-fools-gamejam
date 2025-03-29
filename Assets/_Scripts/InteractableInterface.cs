using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InteractableInterface
{
    void Interact();
    string InteractableText { get; set; }
    bool InteractableEnabled { get; set; }
}
