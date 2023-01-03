using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update


    private void Awake()
    {
    }
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void setHeatlh(float health)
    {
        slider.value = health;
    }
}
