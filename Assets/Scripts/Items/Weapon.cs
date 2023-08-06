using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public Weapon(int code, int price, int honor, int grade, string name, string image, Recipe recipe) : base(code, price, honor, grade, name, image, recipe)
    {
    }
}
