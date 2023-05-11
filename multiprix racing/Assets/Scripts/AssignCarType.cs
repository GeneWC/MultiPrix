using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignCarType : MonoBehaviour
{
    ButtonPressed bp = new ButtonPressed();
    
    // Start is called before the first frame update
    public int assignCarType() {
        switch (bp.name)
        {
            case "Blue":
                return 1;
            case "Red":
                return 2;
            case "Green":
                return 3;
            case "Pink":
                return 4;
            case "Black":
                return 5;
            case "White":
                return 6;

            default:
                return -1;
        }



    }
}
