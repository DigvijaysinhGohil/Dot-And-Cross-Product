using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour {
    public bool calculateDot = false;

    [SerializeField] private Transform dotGreen;
    [SerializeField] private Transform dotRed;
    
    [Space]
    [SerializeField] private TMP_Text tmpGreenPos;
    [SerializeField] private TMP_Text tmpGreenLength;
    [SerializeField] private TMP_Text tmpRedPos;
    [SerializeField] private TMP_Text tmpRedLength;
    [SerializeField] private TMP_Text tmpResult;

    [Space]
    [SerializeField] private DotAndCrossProducts dotAndCrossProducts;

    [Space]
    [SerializeField] private GameObject dotProductTip; 
    [SerializeField] private GameObject crossProductTip; 

    private void Update() {
        tmpGreenPos.text = $"Green's Position\n({dotGreen.position.x:0.00}, {dotGreen.position.y:0.00}, {dotGreen.position.z:0.00})";
        tmpGreenLength.text = $"Green's Length\n{dotGreen.position.magnitude:0.00}";
        
        tmpRedPos.text = $"Red's Position\n({dotRed.position.x:0.00}, {dotRed.position.y:0.00}, {dotRed.position.z:0.00})";
        tmpRedLength.text = $"Red's Length\n{dotRed.position.magnitude:0.00}";

        if (calculateDot) {
            tmpResult.text = $"Dot Product\n{dotAndCrossProducts.GetDotProduct(dotGreen.position, dotRed.position):0.00}";
        }
        else {
            Vector3 crossProduct = dotAndCrossProducts.GetCrossProduct(dotGreen.position, dotRed.position);
            tmpResult.text = $"Cross Product (Green X Red)\n({crossProduct.x:0.00}, {crossProduct.y:0.00}, {crossProduct.z:0.00})";
        }
    }

    public void ShouldCalculateDot(bool value) {
        calculateDot = value;

        if (calculateDot) {
            dotProductTip.SetActive(true);
            crossProductTip.SetActive(false);
        }
        else {
            dotProductTip.SetActive(false);
            crossProductTip.SetActive(true);
        }
    }
}