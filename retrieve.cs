using UnityEngine;

public class retrieve : MonoBehaviour
{
    public void OnPointerEnter(){
    	movement[] allCollectibles = FindObjectsOfType<movement>();    	

    	foreach(movement c in allCollectibles){
    		c.AttractToPlayer();}}
	  public void OnPointerExit(){}
}
