using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductsForSale : MonoBehaviour
{
    public SelectProduct[] productForSale;
    SelectProduct[] selectProducts;

    public void DisableSelection(int productIndex)
    {
        for (int i = 0; i < productForSale.Length; i++)
        {
            if (i != productIndex)
            {
                productForSale[i].SelectOff();
            }
        }
    }
}
