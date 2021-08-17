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
      //this.transform.Rotate(-Vector3.forward * Time.deltaTime * rotationSpeed);

      if (transform.localScale.x > 1)
      {
         this.transform.localScale -= new Vector3(1f, 1f, 1f) * Time.deltaTime * 0.3f;
      }

      foreach (Text animationText in animationTextList.ToArray())
      {
         var textAnimator = animationText.GetComponent<TextAnimationScript>();

         var transform = animationText.transform.localPosition;
         transform.Set(transform.x + textAnimator.SideSpeed, transform.y + textAnimator.UpwardsSpeed, transform.z);

         textAnimator.UpwardsSpeed -= Time.deltaTime;
         textAnimator.SideSpeed -= Time.deltaTime/3;

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
      this.transform.localScale = new Vector3(1.05f, 1.05f, 1.05f);

      var animationtext = Instantiate(TapAnimationText, new Vector3(Input.mousePosition.x + Random.Range(-50, 50), Input.mousePosition.y + Random.Range(-50, 50), 0), Quaternion.identity);
      animationtext.transform.SetParent(this.transform.parent);
      animationTextList.Add(animationtext);
      animationtext.text = PengaNamn.FormateraMedEnhet(InfectedScript.GetInfectedPerTap(), true);
   }
}
