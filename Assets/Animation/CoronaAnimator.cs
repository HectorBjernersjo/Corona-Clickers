using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoronaAnimator : MonoBehaviour
{
   float alphaSpeed = 0.8f;


   public Text TapAnimationText;

   List<Text> animationTextList = new List<Text>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (transform.localScale.x > 1)
      {
         this.transform.localScale -= new Vector3(1f, 1f, 1f) * Time.deltaTime * 0.3f;
      }

      foreach (Text animationText in animationTextList.ToArray())
      {
         var textAnimator = animationText.GetComponent<TextAnimationScript>();

         var transform = animationText.transform.localPosition;

         transform.Set(transform.x + textAnimator.SideSpeed, transform.y + textAnimator.UpwardsSpeed, transform.z);

         textAnimator.UpwardsSpeed -= Time.deltaTime * ScreenSize.SomePercentageOfTheScreen * 2;
         textAnimator.SideSpeed -= Time.deltaTime * ScreenSize.SomePercentageOfTheScreen;

         animationText.transform.localPosition = transform;


         var color = animationText.color;
         animationText.color = new Color(color.r,color.g,color.b, color.a - Time.deltaTime * alphaSpeed);

         if (animationText.color.a <= 0.1)
         {
            animationTextList.Remove(animationText);
            Destroy(animationText.gameObject);
         }
      }
    }

   public void ClickAnimation ()
   {
      transform.localScale = new Vector3(1.05f, 1.05f, 1.05f);

      var animationText = Instantiate(TapAnimationText, new Vector3(Input.mousePosition.x, Input.mousePosition.y - 50, 0), Quaternion.identity);
      animationText.transform.SetParent(this.transform.parent);
      animationTextList.Add(animationText);
      animationText.text = PengaNamn.FormateraMedEnhet(InfectedScript.GetInfectedPerTap(), true);
      animationText.transform.localScale = new Vector3(ScreenSize.SomePercentageOfTheScreen / 1.6f, ScreenSize.SomePercentageOfTheScreen / 1.6f, 1);
   }
}
