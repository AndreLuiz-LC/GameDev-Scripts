using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [Header("Amounts")]
    public int currentWood; 
    public int carrots;
    public float currentWater;
    public int fishes;

    [Header("Limits")]
    public float woodLimit = 10;
    public float carrotsLimit = 5;
    public float waterLimit = 30;
    public float fishesLimit = 3f;
    // (abaixo é uma demonstração) mesma coisa que tornar as variáveis publicas:

    // public float WoodLimit {get => woodLimit; set => woodLimit = value;}
    // public float CarrotsLimit {get => carrotsLimit; set => carrotsLimit = value;}
    // public float WaterLimit {get => waterLimit; set => waterLimit = value;}

    public void WaterLimit(float water)
    {
       if(currentWater <= waterLimit)
       {
            currentWater += water;        
       }    
    }
}
