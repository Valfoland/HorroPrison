using System;
using System.Collections.Generic;
using UnityEngine;

public class Test
{
   private Dictionary<string, int> _d = new Dictionary<string, int>();
   private int _index = 0;
   private int _a = 1;
   private int _b = 2;
   
   
   public void Initialize()
   {
      _d.Add("a", 1);
      _d.Add("b", 2);
      _d.Add("c", 3);
      
      Step1();
   }

   public void Update()
   {
      Step2();
   }

   private void Step1()
   {
      foreach (var d in _d)
      {
         Debug.LogError($"{d.Key} {d.Value}");
      }
      
      Step2();
   }

   private void Step2()
   {
      if (_index == 0)
      {
         Step3(GetA(), GetB());
      }
      else
      {
         Step4();
      }
   }

   private void Step3(int a, int b)
   {
      Debug.LogError($"Step3 {a} {b}");
   }

   private void Step4()
   {
      Debug.LogError("Step4");
   }

   private int GetA()
   {
      return _a;
   }
   
   private int GetB()
   {
      return _b;
   }
}
