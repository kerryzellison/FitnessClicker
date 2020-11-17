using System.Collections;
using System.Collections.Generic;
using Clicker.Player;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
 public Slider slider;
 public Gradient gradient;
 public Image fill;

 public void SetMaxProgress(int progress)
 {
  slider.maxValue = progress;
  gradient.Evaluate(1f);
 }

 public void SetProgress(int progress)
 {
  slider.value = progress;
  fill.color = gradient.Evaluate(slider.normalizedValue);
 }

}
