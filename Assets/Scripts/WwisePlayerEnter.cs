using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwisePlayerEnter : AkTriggerBase
{

   public void enter()
   {
        if (triggerDelegate != null)

        {
            triggerDelegate(null);
        }
   }

}
